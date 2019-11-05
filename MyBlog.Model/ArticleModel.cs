using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blog.Model
{
    [DataContract]
    public class ArticleModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public string TitleEn { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Summary { get; set; }
    }
}
