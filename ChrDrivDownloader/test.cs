using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromeDriverDownloader
{

    // Примечание. Для запуска созданного кода может потребоваться NET Framework версии 4.5 или более поздней версии и .NET Core или Standard версии 2.0 или более поздней.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://doc.s3.amazonaws.com/2006-03-01")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://doc.s3.amazonaws.com/2006-03-01", IsNullable = false)]
    public partial class ListBucketResult
    {

        private string nameField;

        private object prefixField;

        private object markerField;

        private bool isTruncatedField;

        private ListBucketResultContents[] contentsField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object Prefix
        {
            get
            {
                return this.prefixField;
            }
            set
            {
                this.prefixField = value;
            }
        }

        /// <remarks/>
        public object Marker
        {
            get
            {
                return this.markerField;
            }
            set
            {
                this.markerField = value;
            }
        }

        /// <remarks/>
        public bool IsTruncated
        {
            get
            {
                return this.isTruncatedField;
            }
            set
            {
                this.isTruncatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Contents")]
        public ListBucketResultContents[] Contents
        {
            get
            {
                return this.contentsField;
            }
            set
            {
                this.contentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://doc.s3.amazonaws.com/2006-03-01")]
    public partial class ListBucketResultContents
    {

        private string keyField;

        private ulong generationField;

        private byte metaGenerationField;

        private System.DateTime lastModifiedField;

        private string eTagField;

        private uint sizeField;

        /// <remarks/>
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public ulong Generation
        {
            get
            {
                return this.generationField;
            }
            set
            {
                this.generationField = value;
            }
        }

        /// <remarks/>
        public byte MetaGeneration
        {
            get
            {
                return this.metaGenerationField;
            }
            set
            {
                this.metaGenerationField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LastModified
        {
            get
            {
                return this.lastModifiedField;
            }
            set
            {
                this.lastModifiedField = value;
            }
        }

        /// <remarks/>
        public string ETag
        {
            get
            {
                return this.eTagField;
            }
            set
            {
                this.eTagField = value;
            }
        }

        /// <remarks/>
        public uint Size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }
    }




}
