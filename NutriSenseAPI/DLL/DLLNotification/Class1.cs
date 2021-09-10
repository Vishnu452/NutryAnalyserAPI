using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLNotification
{
    public class PAL_Notification : Utility
    {
        public int notificationID { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
        public string deviceToken { get; set; }
        public string messageID { get; set; }
    }

    public class DAL_Notification
    {
        public static void ReturnTable(PAL_Notification pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_Notification", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@notificationID", pobj.notificationID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
                sqlCmd.Parameters.AddWithValue("@deviceToken", pobj.deviceToken);
                sqlCmd.Parameters.AddWithValue("@messageID", pobj.messageID);
                sqlCmd.Parameters.Add("@isException", SqlDbType.Bit);
                sqlCmd.Parameters["@isException"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@exceptionMessage", SqlDbType.VarChar, 500);
                sqlCmd.Parameters["@exceptionMessage"].Direction = ParameterDirection.Output;
                SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd);
                pobj.DS = new DataSet();
                sqlAdp.Fill(pobj.DS);
                pobj.isException = Convert.ToBoolean(sqlCmd.Parameters["@isException"].Value);
                pobj.exceptionMessage = sqlCmd.Parameters["@exceptionMessage"].Value.ToString();
            }
            catch (Exception ex)
            {
                pobj.isException = true;
                pobj.exceptionMessage = ex.Message;
            }
        }
    }

    public class BAL_Notification
    {
        public static void InsertFCMDeviceToken(PAL_Notification pobj)
        {
            pobj.opCode = 11;
            DAL_Notification.ReturnTable(pobj);
        }
        public static void UpdateNotificationSentStatus(PAL_Notification pobj)
        {
            pobj.opCode = 22;
            DAL_Notification.ReturnTable(pobj);
        }
        public static void UpdateNotificationStatus(PAL_Notification pobj)
        {
            pobj.opCode = 23;
            DAL_Notification.ReturnTable(pobj);
        }
        public static void GetNotificationList(PAL_Notification pobj)
        {
            pobj.opCode = 41;
            DAL_Notification.ReturnTable(pobj);
        }
        public static void GetNotificationDetails(PAL_Notification pobj)
        {
            pobj.opCode = 42;
            DAL_Notification.ReturnTable(pobj);
        }
        public static void GetUnreadNotificationCount(PAL_Notification pobj)
        {
            pobj.opCode = 44;
            DAL_Notification.ReturnTable(pobj);
        }
    }
}