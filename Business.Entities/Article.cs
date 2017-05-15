using System.Runtime.Serialization;
using Core.Utilities;

namespace Business.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Article : Base
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Contents { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public int BlogId { get; set; }

        public int ContentLength => Contents.Length;
    }
}