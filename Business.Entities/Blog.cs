using System.Runtime.Serialization;
using Core.Utilities;

namespace Business.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Blog : IExtensibleDataObject
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Owner { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}