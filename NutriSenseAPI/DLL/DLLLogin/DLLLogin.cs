using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;

namespace DLLLogin
{
    public class PAL_Login : Utility
    {
        public string CallingCodeId { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public int userLoginID { get; set; }
        public string ipAddress { get; set; }
        public string deviceToken { get; set; }
        public string userToken { get; set; }
        public string appVersion { get; set; }
        public int appType { get; set; }
    }
    public class DAL_Login {
        public static void ReturnTable(PAL_Login pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_Login", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@CallingCodeId", pobj.CallingCodeId);
                sqlCmd.Parameters.AddWithValue("@mobileNo", pobj.userName);
                sqlCmd.Parameters.AddWithValue("@password", pobj.userPwd);
                sqlCmd.Parameters.AddWithValue("@oldPassword", pobj.oldPassword);
                sqlCmd.Parameters.AddWithValue("@newPassword", pobj.newPassword);
                sqlCmd.Parameters.AddWithValue("@ipAddress", pobj.ipAddress);
                sqlCmd.Parameters.AddWithValue("@userLoginID", pobj.userLoginID);
                sqlCmd.Parameters.AddWithValue("@deviceToken", pobj.deviceToken);
                sqlCmd.Parameters.AddWithValue("@userToken", pobj.userToken);
                sqlCmd.Parameters.AddWithValue("@appVersion", pobj.appVersion);
                sqlCmd.Parameters.AddWithValue("@appType", pobj.appType);
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
    public class BAL_Login
    {
        public static void LoginAuthentication(PAL_Login pobj)
        {
            pobj.opCode = 41;
            DAL_Login.ReturnTable(pobj);
        }
        public static void ForgetPassword(PAL_Login pobj)
        {
            pobj.opCode = 42;
            DAL_Login.ReturnTable(pobj);
        }
        public static void CheckVersion(PAL_Login pobj)
        {
            pobj.opCode = 43;
            DAL_Login.ReturnTable(pobj);
        }
        public static void GetMenuList(PAL_Login pobj)
        {
            pobj.opCode = 44;
            DAL_Login.ReturnTable(pobj);
        }
        public static void ChangePassword(PAL_Login pobj)
        {
            pobj.opCode = 21;
            DAL_Login.ReturnTable(pobj);
        }
        public static void Logout(PAL_Login pobj)
        {
            pobj.opCode = 22;
            DAL_Login.ReturnTable(pobj);
        }
    }
}
