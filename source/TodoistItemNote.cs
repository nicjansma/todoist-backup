// <copyright file="TodoistItemNote.cs" company="Nic Jansma">
//  Copyright (c) Nic Jansma 2012 All Right Reserved
// </copyright>
// <author>Nic Jansma</author>
// <email>nic@nicj.net</email>
namespace TodoistBackup
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Todoist Note item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRootAttribute(ElementName = "note")]
    public class TodoistItemNote
    {
        /// <summary>
        /// Initializes a new instance of the TodoistItemNote class.
        /// </summary>
        public TodoistItemNote()
        {            
        }

        /// <summary>
        /// Gets or sets the item's Content
        /// </summary>
        /// <value>Item's Content number</value>
        [JsonProperty("content")]
        [XmlAttribute]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's id
        /// </summary>
        /// <value>Item's id number</value>
        [JsonProperty("item_id")]
        [XmlAttribute]
        public int ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the note's id
        /// </summary>
        /// <value>Note's id number</value>
        [JsonProperty("id")]
        [XmlAttribute]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's posted date
        /// </summary>
        /// <value>Item's posted date</value>
        [JsonProperty("posted")]
        [XmlAttribute]
        public string Posted
        {
            get;
            set;
        }
    }
}
