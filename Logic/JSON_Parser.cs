using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TV_Slideshow_Config_Editor
{
    struct JSON_Parser
    {
        public static List<Control> JSONParameterIntoControl(JToken token)
        {
            var controls = new List<Control>();
            foreach (var parameter in token.Children())
            {
                Console.WriteLine(parameter.GetType());
                if (parameter.GetType() == typeof(JProperty))
                    controls.Add(ControlMaker(parameter as JProperty));
                else
                {
                    var container = new TableLayoutPanel()
                    {
                        GrowStyle = TableLayoutPanelGrowStyle.AddColumns,
                        AutoSize = true,
                        BorderStyle = BorderStyle.FixedSingle,
                    };
                    container.Controls.AddRange(JSONParameterIntoControl(parameter).ToArray());
                    controls.Add(container);
                }
            }
            return controls;
        }

        private static Control ControlMaker(JProperty PropJSON)
        {
            Console.WriteLine(PropJSON);
            var type = PropJSON.Value.Type.ToString();
            switch (type)
            {
                case "Integer":
                    return new JSON_Number(PropJSON);
                case "String":
                    return new JSON_String(PropJSON);
                default:
                    Console.WriteLine(String.Format("Wasn't able to understand \"{0}\":\n{1}", PropJSON.Name, PropJSON));
                    return null;
            }
            
            ;
        }
    }
}
