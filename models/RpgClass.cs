


using System.Text.Json.Serialization;

namespace web_api.models{

  [JsonConverter(typeof(JsonStringEnumConverter))]
   public enum RpgClass
    {
         
         Knight =0,
         Mage = 2,
         Cleric =3
    }
}