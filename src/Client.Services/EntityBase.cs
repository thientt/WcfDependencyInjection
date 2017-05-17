using System.Runtime.Serialization;
using Core.Common;
using Core.Utilities;

namespace Client.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class EntityBase : Validatable, IExtensibleDataObject
    {
        [DataMember]
        public int Id { get; set; }

        [IgnoreDataMember]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}