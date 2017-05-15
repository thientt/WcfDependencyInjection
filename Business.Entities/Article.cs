using System.Runtime.Serialization;
using Core.Utilities;

namespace Business.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Article : IExtensibleDataObject
    {
        [DataMember]
        public int Id { get; set; }

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

        [DataMember]
        public int ContentLength => Contents.Length;

        public ExtensionDataObject ExtensionData { get; set; }
    }
}