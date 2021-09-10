using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;

namespace NutriSenseAPI
{
    public class ServiceResponse
    {
        public static void GeneralResponseObject(int responseCode, string responseMessage, object responseValue)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue
            });
            Response(json);
        }
        public static void GeneralResponseObjectWithIsExists(int responseCode, string responseMessage, object responseValue, int isExists)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue,
                isExists = isExists
            });
            Response(json);
        }
        public static void GeneralResponse(int responseCode, string responseMessage, DataTable responseValue)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue
            });
            Response(json);
        }
        public static void ResponseWithEnergyValues(int responseCode, string responseMessage, DataTable responseValue, string energyConsumed, string energyTarget, int energyAchievedRDAPercentage, string energyColorCode)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue,
                energyConsumed = energyConsumed,
                energyTarget = energyTarget,
                energyAchievedRDAPercentage = energyAchievedRDAPercentage,
                energyColorCode = energyColorCode
            });
            Response(json);
        }
        public static void GeneralResponseDataSet(int responseCode, string responseMessage, DataSet responseValue)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue
            });
            Response(json);
        }

        public static void GeneralResponseDataset(int responseCode, string responseMessage, DataSet responseValue)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue
            });
            Response(json);
        }
        public static void ExistsResponse(int responseCode, string responseMessage, DataSet responseValue, int isExists)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue,
                isExists = isExists
            });
            Response(json);
        }
        public static void ResponseWithoutValue(int responseCode, string responseMessage)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
            });
            Response(json);
        }
        public static void TokenResponse(int responseCode, string responseMessage, DataTable responseValue, string token)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue,
                token = token
            });
            Response(json);
        }
        public static void TokenResponseWithUserCount(int responseCode, string responseMessage, DataSet responseValue, int usercount, string token)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue,
                usercount = usercount,
                token = token
            });
            Response(json);
        }

        public static void AuthenticationErrorResponse()
        {
            DataTable returnTable = new DataTable();
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = 0,
                responseMessage = "Not Authorized!",
                responseValue = returnTable
            });
            Response(json);
        }
        public static void AuthenticationErrorTokenResponse()
        {
            DataTable returnTable = new DataTable();
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = 0,
                responseMessage = "Not Authorized!",
                responseValue = returnTable,
                token = ""
            });
            Response(json);
        }
        public static void AuthenticationExistResponse()
        {
            DataTable returnTable = new DataTable();
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = 0,
                responseMessage = "Not Authorized!",
                responseValue = returnTable,
                isExist = 0
            });
            Response(json);
        }
        public static void GeneralResponseObjectPost(int responseCode, string responseMessage, object responseValue)
        {
            string json = JsonConvert.SerializeObject(new
            {
                responseCode = responseCode,
                responseMessage = responseMessage,
                responseValue = responseValue
            });
            PostResponse(json);
        }
        private static void Response(string json)
        {
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.ContentType = "application/json";
            //HttpContext.Current.Response.AddHeader("content-length", json.Length.ToString());
            HttpContext.Current.Response.Write(json);
            //HttpContext.Current.Response.Flush();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        private static void PostResponse(string json)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/json";
            HttpContext.Current.Response.AddHeader("content-length", json.Length.ToString());
            HttpContext.Current.Response.Write(json);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}