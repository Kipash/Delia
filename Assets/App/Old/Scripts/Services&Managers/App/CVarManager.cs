using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Skyrise
{
    [Serializable]
    public class CVarManager
    {
        ConsoleVariables cvars = new ConsoleVariables();

        public void Initialize()
        {
            //Log.Console.Add("Set", this, "SetCvar");
            //Log.Console.Add("Get", this, "GetCvar");
            //Log.Console.Add("Cvars", this, "ListScvars");
        }

        bool boolResult;
        float floatResult;
        int intResult;

        public void SetCvar(string name, string val)
        {
            PropertyInfo[] props = typeof(ConsoleVariables).GetProperties();
            PropertyInfo prop = props
                        .Where(x => x.Name.ToLower() == name.ToLower())
                        .FirstOrDefault();
            
            if (prop != null)
            {
                if (prop.CanWrite && prop.CanRead)
                {
                    if (prop.PropertyType == typeof(System.String))
                    {
                        prop.SetValue(cvars, val, null);
                    }
                    else if (prop.PropertyType == typeof(System.Int32))
                    {
                        
                        if (int.TryParse(val, out intResult))
                        {
                            prop.SetValue(cvars, intResult, null);
                        }
                        else
                        {
                            Debug.LogError($"value: {val} ; is not a whole number");
                            return;
                        }
                    }
                    else if (prop.PropertyType == typeof(System.Single))
                    {

                        if (float.TryParse(val, out floatResult))
                        {
                            prop.SetValue(cvars, floatResult, null);
                        }
                        else
                        {
                            Debug.LogError($"value: {val} ; is not a number with decimal point");
                            return;
                        }
                    }
                    else if (prop.PropertyType == typeof(System.Boolean))
                    {
                        if(val == "1" || val == "0")
                        {
                            boolResult = val == "1" ? true : false;
                        }
                        else if(val == "true" || val == "false")
                        {
                            boolResult = val == "true" ? true : false;
                        }
                        else if (val == "on" || val == "off")
                        {
                            boolResult = val == "on" ? true : false;
                        }
                        else
                        {
                            Debug.LogError($"value: {val} ; is not a on/off information");
                            return;
                        }

                        prop.SetValue(cvars, boolResult, null);
                    }
                    else
                    {
                        Debug.LogError($"value: {val} ; is of unknown type");
                        return;
                    }

                    Debug.Log("Setting " + name + " to " + prop.GetValue(cvars, null));
                }
                else
                {
                    Debug.LogError("Access denied!");
                    return;
                }
            }
            else
            {
                Debug.LogError("Wrong name!");
                return;
            }
        }
        public void GetCvar(string name)
        {
            var props = typeof(ConsoleVariables).GetProperties();
            var prop = props
                        .Where(x => x.Name.ToLower() == name.ToLower())
                        .FirstOrDefault();

            if (prop != null)
            {
                if(prop.CanRead)
                    Debug.Log(name + " = " + prop.GetValue(cvars, null));
                else
                    Debug.LogError("Access denied!");
            }
            else
                Debug.LogError("Wrong name!");
        }
        public void ListScvars()
        {
            var props = typeof(ConsoleVariables).GetProperties();

            Debug.Log(" - Available Cvars - ");
            Debug.Log(string.Format("{0,-20}   {1}", "Key", "Access"));
            Debug.Log(@"---------------------*------------------------");
            foreach (var x in props)
            {
                Debug.Log(string.Format(
                    "{0,-20}   {1}",
                    x.Name,
                    (x.CanRead ? "Read " : "") + (x.CanWrite ? "Write " : "")));
            }
            Debug.Log(@"---------------------*------------------------");
            Debug.Log("");
        }
    }
}