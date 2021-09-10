using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System;

namespace DLLUtility
{
    public class Utility
    {
        public DataSet DS { get; set; }
        public int opCode { get; set; }
        public bool isException { get; set; }
        public string exceptionMessage { get; set; }
        public static bool SendMessage(string message, string mobileno)
        {
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://138.201.192.131/http-api.php?username=erauniversity&password=eras4567&senderid=ERAHMS&route=1&number=" + mobileno + "&message=" + message);
                HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();
                myResp.Close();
                if (responseString.Contains("msg-id"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
    public class Config
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
    }
}
