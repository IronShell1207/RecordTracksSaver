using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace ChromeDriverDownloader
{
    [XmlRoot("ListBucketResult")]
    public  class ListBucketResult1
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Prefix")]
        public string Prefix { get; set; }
        [XmlElement("Marker")]
        public string Marker { get; set; }
        [XmlElement("IsTruncated")]
        public bool IsTruncated { get; set; }
        [XmlArrayItem(typeof(Contents))]
        public Contents[] Vers { get; set; }

    }

    [Serializable()]
    public  class Contents
    {
        [XmlElement("Key")]
        public string Key { get; set; }
        [XmlElement("Generation")]
        public int Generation { get; set; }
        [XmlElement("MetaGeneration")]
        public int MetaGeneration { get; set; }
        [XmlElement("LastModified")]
        public int LastModified { get; set; }
        [XmlElement("ETag")]
        public int ETag { get; set; }
        [XmlElement("Size")]
        public int Size { get; set; }
    }
}
