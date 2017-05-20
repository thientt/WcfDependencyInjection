using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Core.Common
{
    public class Extensions
    {
        public static object GetExtensionDataMemberValue(IExtensibleDataObject extensibleObject, string dataMemberName)
        {
            var membersProperty = typeof(ExtensionDataObject).GetProperty("Members",
                BindingFlags.NonPublic | BindingFlags.Instance);

            var members = (IList)membersProperty.GetValue(extensibleObject.ExtensionData, null);

            return (from object member in members
                    let nameProperty = member.GetType().GetProperty("Name")
                    let name = (string)nameProperty.GetValue(member, null)
                    where name == dataMemberName
                    let valueProperty = member.GetType().GetProperty("Value")
                    select valueProperty.GetValue(member, null) into value
                    let innerValueProperty = value.GetType().GetProperty("Value")
                    select innerValueProperty.GetValue(value, null)).FirstOrDefault();
        }
    }
}