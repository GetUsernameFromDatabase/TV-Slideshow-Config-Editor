using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using TV_Slideshow_Config_Editor.ConfigInterface;

namespace TV_Slideshow_Config_Editor.Logic
{
    struct ConfigJSON_Parser
    {
        readonly static public JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        };

        public static string Serialize(Configurations Config)
        {
            return JsonConvert.SerializeObject(Config,
               Formatting.Indented, SerializerSettings);
        }

        public static Configurations DeSerialize(string source)
        {
            return JsonConvert.DeserializeObject<Configurations>(
                source, SerializerSettings); ;
        }
    }
}
