﻿using Core.Utilities;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract(Namespace = Proxy.Namespace)]
    public class Base : IExtensibleDataObject
    {
        [DataMember]
        public int Id { get; set; }

        [IgnoreDataMember]
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
