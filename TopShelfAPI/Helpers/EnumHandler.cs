using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Helpers
{
    internal static class EnumHandler
    {
        private static Dictionary<Type, Dictionary<object, string>> enumMap = new Dictionary<Type, Dictionary<object, string>>()
        {
            [typeof(DocumentType)] = new Dictionary<object, string>()
            {
                [DocumentType.PurchaseOrder] = "Purchase Order",
                [DocumentType.SalesOrder] = "Sales Order"
            },
            [typeof(StatusName)] = new Dictionary<object, string>()
            {
                [StatusName.Canceled] = "CANCELED",
                [StatusName.Open] = "OPEN",
                [StatusName.PickedComplete] = "PICKED COMPLETE",
                [StatusName.PickedIncomplete] = "PICKED INCOMPLETE",
                [StatusName.ShippedComplete] = "SHIPPED COMPLETE",
                [StatusName.ShippedIncomplete] = "SHIPPED INCOMPLETE",
                [StatusName.ReceivedComplete] = "RECEIVED COMPLETE",
                [StatusName.ReceivedIncomplete] = "RECEIVED INCOMPLETE"
            }
        };

        internal static string ConvertEnum<T>(this T value)
        {
            if (enumMap.ContainsKey(typeof(T)) && enumMap[typeof(T)].ContainsKey(value))
                return enumMap[typeof(T)][value];
            else
                return string.Empty;
        }

        internal static T ConvertString<T>(this string value)
        {
            if (enumMap.ContainsKey(typeof(T)) && enumMap[typeof(T)].Values.Contains(value))
                return (T)enumMap[typeof(T)].Where(KeyValue => KeyValue.Value == value).FirstOrDefault().Key;
            else
                throw new KeyNotFoundException($"Error, could not find a matching enum for type [{typeof(T).Name}] with value [{value}]");
        }
    }
}
