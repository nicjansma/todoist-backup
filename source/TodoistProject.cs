// <copyright file="TodoistProject.cs" company="Nic Jansma">
//  Copyright (c) Nic Jansma 2014 All Right Reserved
// </copyright>
// <author>Nic Jansma</author>
// <email>nic@nicj.net</email>
namespace TodoistBackup
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Todoist project
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRootAttribute(ElementName = "project")]
    public class TodoistProject
    {
        /// <summary>
        /// Initializes a new instance of the TodoistProject class.
        /// </summary>
        public TodoistProject()
        {
            Items = new List<TodoistItem>();
        }

        /// <summary>
        /// Gets or sets the project's Id
        /// </summary>
        /// <value>Project's Id</value>
        [JsonProperty("id")]
        [XmlAttribute]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user's Id
        /// </summary>
        /// <value>User's Id number</value>
        [JsonProperty("user_id")]
        [XmlAttribute]
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's name
        /// </summary>
        /// <value>Project's name</value>
        [JsonProperty("name")]
        [XmlAttribute]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's color
        /// </summary>
        /// <value>Project's color</value>
        [JsonProperty("color")]
        [XmlAttribute]
        public string Color
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the project is collapsed
        /// </summary>
        /// <value>Whether or not the project is collapsed</value>
        [JsonProperty("collapsed")]
        [XmlAttribute]
        public int Collapsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's order
        /// </summary>
        /// <value>Project's order</value>
        [JsonProperty("item_order")]
        [XmlAttribute]
        public int ItemOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's indent level
        /// </summary>
        /// <value>Project's indent level</value>
        [JsonProperty("indent")]
        [XmlAttribute]
        public int Indent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's cached count of items
        /// </summary>
        /// <value>Cached count of items</value>
        [JsonProperty("cache_count")]
        [XmlAttribute]
        public int CacheCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's last updated time
        /// </summary>
        /// <value>Last Updated time</value>
        [JsonProperty("last_updated")]
        [XmlAttribute]
        public string LastUpdated
        {
            get;
            set;
        }
                
        /// <summary>
        /// Gets or sets a value indicating whether or not the Project is archived
        /// </summary>
        /// <value>Project is archived</value>
        [JsonProperty("is_archived")]
        [XmlAttribute]
        public bool IsArchived
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Project's archived date
        /// </summary>
        /// <value>Project's archived date</value>
        [JsonProperty("archived_date")]
        [XmlAttribute]
        public string ArchivedDate
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the Project's archived timestamp
        /// </summary>
        /// <value>Project's archived timestamp</value>
        [JsonProperty("archived_timestamp")]
        [XmlAttribute]
        public string ArchivedTimestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the project's items
        /// </summary>
        /// <value>Project's items</value>
        [XmlArray("items")]
        [XmlArrayItem("item")]
        public List<TodoistItem> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not this is the Inbox project
        /// </summary>
        [JsonProperty("inbox_project")]
        [XmlAttribute]
        public bool InboxProject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the project is deleted
        /// </summary>
        [JsonProperty("is_deleted")]
        [XmlAttribute]
        public int IsDeleted
        {
            get;
            set;
        }
    }
}
