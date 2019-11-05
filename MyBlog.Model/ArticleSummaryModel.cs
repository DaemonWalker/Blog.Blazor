using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Blog.Model
{
    [DataContract]
    public class ArticleSummaryModel
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public List<TagModel> Tags { get; set; }

        [DataMember]
        public string Href { get; set; }

        [DataMember]
        public string TitleEn { get; set; }
    }
}
