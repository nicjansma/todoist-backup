// <copyright file="TodoistItem.cs" company="Nic Jansma">
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
    /// Todoist item
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [XmlRootAttribute(ElementName = "item")]
    public class TodoistItem
    {
        /// <summary>
        /// Initializes a new instance of the TodoistItem class.
        /// </summary>
        public TodoistItem()
        {
        }

        /// <summary>
        /// Gets or sets the item's Id
        /// </summary>
        /// <value>Item's Id number</value>
        [JsonProperty("id")]
        [XmlAttribute]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's user Id
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
        /// Gets or sets the project's Id
        /// </summary>
        /// <value>Project Id number</value>
        [JsonProperty("project_id")]
        [XmlAttribute]
        public int ProjectId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's due date
        /// </summary>
        /// <value>Item's due date</value>
        [JsonProperty("due_date")]
        [XmlAttribute]
        public string DueDate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the item is collapsed
        /// </summary>
        [JsonProperty("collapsed")]
        [XmlAttribute]
        public int Collapsed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the item is completed (in history)
        /// </summary>
        [JsonProperty("in_history")]
        [XmlAttribute]
        public int InHistory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's priority
        /// </summary>
        [JsonProperty("priority")]
        [XmlAttribute]
        public int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's order
        /// </summary>
        [JsonProperty("item_order")]
        [XmlAttribute]
        public int ItemOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's indentation level
        /// </summary>
        [JsonProperty("indent")]
        [XmlAttribute]
        public int Indent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's content
        /// </summary>
        [JsonProperty("content")]
        [XmlAttribute]
        public string Content
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the item is checked
        /// </summary>
        [JsonProperty("checked")]
        [XmlAttribute]
        public int IsChecked
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's date (string form)
        /// </summary>
        [JsonProperty("date_string")]
        [XmlAttribute]
        public string DateString
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the item's labels
        /// </summary>
        [JsonProperty("labels")]
        [XmlAttribute]
        public List<string> Labels
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the item is in the DST time zone
        /// </summary>
        [JsonProperty("is_dst")]
        [XmlAttribute]
        public int IsDst
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not the item has notifications
        /// </summary>
        [JsonProperty("has_notifications")]
        [XmlAttribute]
        public int HasNotifications
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the children task Ids
        /// </summary>
        [JsonProperty("children")]
        [XmlAttribute]
        public string Children
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Todoist unknown mm_offset attribute
        /// </summary>
        [JsonProperty("mm_offset")]
        [XmlAttribute]
        public int MmOffset
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the chains attribute
        /// </summary>
        [JsonProperty("chains")]
        [XmlAttribute]
        public string Chains
        {
            get;
            set;
        }
    }
}
