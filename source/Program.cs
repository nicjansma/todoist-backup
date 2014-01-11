// <copyright file="Program.cs" company="Nic Jansma">
//  Copyright (c) Nic Jansma 2014 All Right Reserved
// </copyright>
// <author>Nic Jansma</author>
// <email>nic@nicj.net</email>
namespace TodoistBackup
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Todoist backup program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Web connection timeout
        /// </summary>
        private const int HttpTimeout = 60000;

        /// <summary>
        /// Also process completed items?
        /// </summary>
        private static bool processCompleted = true;
    
        /// <summary>
        /// Todoist command line
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>True on success</returns>
        public static int Main(string[] args)
        {
            int returnCode = 0;

            try
            {
                //
                // check arguments
                //
                if (args.Length == 0)
                {
                    Console.WriteLine("Todoist.exe [token] [output.xml] [\"false\" to not get completed items]");
                    Console.WriteLine("\t[output.xml] is optional");
                    return 1;
                }

                // token is the first argument
                string token = args[0];

                //
                // determine where the writer is going to, console or a file
                //
                XmlWriter writer;
                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.Indent = true;

                // second argument (optional) is the output file
                if (args.Length > 1)
                {
                    writer = XmlWriter.Create(args[1], writerSettings);
                }
                else
                {
                    writer = XmlWriter.Create(Console.OpenStandardOutput(), writerSettings);
                }

                // third argument (optional) is the parameter for downloading completed items
                if (args.Length > 2)
                {
                    if (args[2] == "false")
                    {
                        processCompleted = false;
                    }
                    else
                    {
                        throw new Exception("Third parameter not recognized!");
                    }
                }
                
                // backup!
                returnCode = BackupTodoistItems(token, writer);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: {0}", e);
                return 1;
            }

            return returnCode;
        }

        /// <summary>
        /// Backup Todoist.com items
        /// </summary>
        /// <param name="token">API token</param>
        /// <param name="writer">Xml writer</param>
        /// <returns>0 on success</returns>
        private static int BackupTodoistItems(string token, XmlWriter writer)
        {
            Console.WriteLine("Getting projects...");

            try
            {
                // ready serializer
                XmlSerializerNamespaces serializerNameSpace = new XmlSerializerNamespaces();
                serializerNameSpace.Add(String.Empty, String.Empty);
                XmlSerializer projectSerializer = new XmlSerializer(typeof(TodoistProject));

                // start the XML document
                //
                // <todoist>
                //   <projects>
                //   ...
                writer.WriteStartDocument(true);
                writer.WriteStartElement("todoist");
                writer.WriteStartElement("projects");

                //
                // find all of the projects
                //
                // get an array of objects back from the API
                List<TodoistProject> projects = JsonWebRequestToArray<TodoistProject>(BuildQueryUrl(token, "getProjects"));

                //
                // get all tasks for each project
                //
                foreach (TodoistProject project in projects)
                {
                    Console.WriteLine("\t{0}", project.Name);

                    // get uncomplete tasks
                    Dictionary<string, string> getUncompletedItemsParameters = new Dictionary<string, string>()
                    {
                        { "project_id", project.Id.ToString(CultureInfo.InvariantCulture) }
                    };

                    List<TodoistItem> items = JsonWebRequestToArray<TodoistItem>(BuildQueryUrl(token, "getUncompletedItems",  getUncompletedItemsParameters));
                    foreach (TodoistItem item in items)
                    {
                        CheckForNotes(item, token);
                        project.Items.Add(item);
                    }
         
                    // get complete tasks
                    int offset = 0;
                    bool haveAllCompletedItems = false;

                    if (processCompleted)
                    {
                        while (!haveAllCompletedItems)
                        {
                            // get uncomplete tasks
                            Dictionary<string, string> getCompletedItemsParameters = new Dictionary<string, string>()
                            {
                                { "project_id", project.Id.ToString(CultureInfo.InvariantCulture) },
                                { "offset", offset.ToString(CultureInfo.InvariantCulture) }
                            };

                            items = JsonWebRequestToArray<TodoistItem>(BuildQueryUrl(token, "getCompletedItems", getCompletedItemsParameters));

                            if (items.Count == 0) 
                            {
                                haveAllCompletedItems = true;
                            }
                            else
                            {
                                // still things to get
                                foreach (TodoistItem item in items)
                                {
                                    CheckForNotes(item, token);
                                    project.Items.Add(item);
                                }

                                offset += items.Count;
                            }
                        }
                    }
                    
                    // write XML
                    projectSerializer.Serialize(writer, project, serializerNameSpace);
                }

                // </projects>
                writer.WriteEndElement();

                // </todoist>
                writer.WriteEndElement();

                //
                // end XML, flush and close
                //
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch (WebException)
            {
                Console.WriteLine("ERROR: Problem communicating with http://todoist.com.");
                Console.WriteLine("Please check your token and / or try again.");

                return 1;
            }            

            return 0;
        }

        /// <summary>
        /// Checks and retrieves notes for an item
        /// </summary>
        /// <param name="item">Todoist item</param>
        /// <param name="token">API token</param>
        private static void CheckForNotes(TodoistItem item, string token)
        {
            int noteCount;
            if (Int32.TryParse(item.NoteCount, out noteCount) && noteCount > 0)
            {
                Dictionary<string, string> getNotesParameters = new Dictionary<string, string>()
                {
                    { "item_id", item.Id.ToString(CultureInfo.InvariantCulture) }
                };

                item.Notes = JsonWebRequestToArray<TodoistItemNote>(BuildQueryUrl(token, "getNotes", getNotesParameters));
            }
        }

        /// <summary>
        /// Populates an array of JavaScript objects from a web API
        /// </summary>
        /// <param name="url">URL of API</param>
        /// <returns>List of objects</returns>
        /// <typeparam name="T">Type of objects to deserialize to</typeparam>
        private static List<T> JsonWebRequestToArray<T>(string url)
        {
            // create web request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Timeout = HttpTimeout;
            webRequest.AllowAutoRedirect = false;

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            // read the input stream via the serializer
            string response;
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }   
             
            // deserialize stream into an array of objects
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            List<T> returnList = JsonConvert.DeserializeObject<List<T>>(response, settings);

            return returnList;
        }

        /// <summary>
        /// Build Todoist.com API query URL
        /// </summary>
        /// <param name="token">API token</param>
        /// <param name="action">API action</param>
        /// <returns>Url string</returns>
        private static string BuildQueryUrl(string token, string action)
        {
            return BuildQueryUrl(token, action, null);
        }
    
        /// <summary>
        /// Build Todoist.com API query URL
        /// </summary>
        /// <param name="token">API token</param>
        /// <param name="action">API action</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns>Url string</returns>
        private static string BuildQueryUrl(string token, string action, Dictionary<string, string> parameters)
        {
            StringBuilder parametersQuery = new StringBuilder();

            // begin with todoist.com API URL
            parametersQuery.AppendFormat(
                CultureInfo.InvariantCulture,
                "http://todoist.com/API/{0}?token={1}", 
                action,
                token);

            // add extra parameters
            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    parametersQuery.AppendFormat("&{0}={1}", key, parameters[key]);
                }
            }

            Debugger.Log(1, null, parametersQuery.ToString() + "\n");

            return parametersQuery.ToString();
        }
    }
}
