using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONFunction
{
    public class JSONFunction
    {
        public static string getJSONFirstName(JObject js, string def)
        {
            try
            {
                //JProperty jp = js.Value()
                //js.Property(name).Value(name).ToString();
                JValue jv = (JValue)((Newtonsoft.Json.Linq.JProperty)(js.First)).Name.ToString();
                return (String)jv.Value;
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public static string getJSONString(JObject js, string name, string def)
        {
            try
            {
                //JProperty jp = js.Value()
                //js.Property(name).Value(name).ToString();
                JValue jv = (JValue)js.Property(name).Value;
                return (String)jv.Value;
            }
            catch (Exception e)
            {
                return def;
            }
        }

        public static JObject getJSONObject(JObject js, String name)
        {
            JObject res = new JObject();
            try
            {
                JProperty np = js.Property(name);
                res = np.Value as JObject;

            }
            catch (Exception e)
            {

            }
            return res;
        }

        public static int getJSONInteger(JObject js, string name, int def)
        {
            try
            {
                //JProperty jp = js.Value()
                //js.Property(name).Value(name).ToString();
                JValue jv = (JValue)js.Property(name).Value;
                return Convert.ToInt16(jv.Value);
            }
            catch (Exception e)
            {
                return def;
            }
        }
        public static float getJSONFloat(JObject js, string name, float def)
        {
            try
            {
                //JProperty jp = js.Value()
                //js.Property(name).Value(name).ToString();
                JValue jv = (JValue)js.Property(name).Value;
                return Convert.ToSingle(jv.Value);
            }
            catch (Exception e)
            {
                return def;
            }
        }
        public static double getJSONDouble(JObject js, string name, double def)
        {
            try
            {
                //JProperty jp = js.Value()
                //js.Property(name).Value(name).ToString();
                JValue jv = (JValue)js.Property(name).Value;
                return Convert.ToDouble(jv.Value);
            }
            catch (Exception e)
            {
                return def;
            }
        }
        public static DateTime getJSONDateTime(JObject js, string name, DateTime dt)
        {
            try
            {

                JValue jv = (JValue)js.Property(name).Value;
                return Convert.ToDateTime(jv.Value);
            }
            catch (Exception e)
            {
                return dt;
            }
        }
        public static JArray getJSONArray(JObject js, string name)
        {
            JArray result = new JArray();

            result = js.Property(name).Value as JArray;
            return result;
        }

        public static JObject getJSONObject(String value)
        {
            JObject res = new JObject();
            try
            {
                res = JObject.Parse(value);
            }
            catch (Exception e)
            {

            }

            return res;
        }
        public static JArray getJSONArray(String value)
        {
            JArray res = new JArray();
            try
            {
                res = JArray.Parse(value);
            }
            catch (Exception e)
            {

            }

            return res;
        }
        public static JObject getJSONObject(JArray js, int idx)
        {
            JObject jo = new JObject();
            try
            {
                jo = (JObject)js[idx];
            }
            catch (Exception e)
            {

            }
            return jo;

        }
        public static string getJSONString(JArray js, int idx, string def)
        {
            try
            {
                JValue jv = (JValue)(js[idx]);
                return (String)jv.Value;
            }
            catch (Exception e)
            {
                return def;
            }
        }
        public static JObject Add(JObject inJson, String code, String value)
        {
            inJson.Add(code, new JValue(value));
            return inJson;
        }
        public static JObject Add(JObject inJson, String code, JObject value)
        {
            inJson.Add(code, value );
            return inJson;
        }
        public static string SerializeJson(object obj)
        {
            string JsonString = "";
            if (obj == null)
            { return JsonString; }
            try
            {
                JsonString = JsonConvert.SerializeObject(obj);
            }
            catch (Exception e)
            {
                // Logger.LogError("对象解析成Json出错", e);

            }
            return JsonString;
        }
        public static object DeserializeObject(string jsonString, object obj)
        {
            try
            {
                object res = JsonConvert.DeserializeObject(jsonString, obj.GetType());
                return res;
            }
            finally
            {

            }

            return null;
        }

    }
}
