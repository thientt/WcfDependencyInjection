using System.Runtime.Serialization;
using Core.Utilities;

namespace Business.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Blog : Base
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Owner { get; set; }
    }
}