using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Blog.Model
{
    [DataContract]
    public class TagModel
    {
        [DataMember]
        public string Name { get; set; }
    }
}
