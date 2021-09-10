using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;
namespace DLLRegistration
{
    public class PAL_Registration : Utility
    {
        public string CallingCodeId { get; set; }
        public string mobileNo { get; set; }
        public string emailId { get; set; }
        public string name { get; set; }
        public Int32 gender { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
        public decimal height { get; set; }
        public decimal weight { get; set; }
        public Int32 countryId { get; set; }
        public Int32 activity { get; set; }
        public int isPregnant { get; set; }
        public int pregnantCondition { get; set; }
        public int islactation { get; set; }
        public int lactationCondition { get; set; }
        public Int32 mobileOTPId { get; set; }
        public Int32 otp { get; set; }
        public string ipAddress { get; set; }
        public string regToken { get; set; }
    }
    public class DAL_Registration
    {
        public static void ReturnTable(PAL_Registration pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_Registration", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@CallingCodeId", pobj.CallingCodeId);
                sqlCmd.Parameters.AddWithValue("@mobileNo", pobj.mobileNo);
                sqlCmd.Parameters.AddWithValue("@password", pobj.password);
                sqlCmd.Parameters.AddWithValue("@emailId", pobj.emailId);
                sqlCmd.Parameters.AddWithValue("@name", pobj.name);
                sqlCmd.Parameters.AddWithValue("@gender", pobj.gender);
                if (pobj.dob > DateTime.MinValue)
                    sqlCmd.Parameters.AddWithValue("@dob", pobj.dob);
                sqlCmd.Parameters.AddWithValue("@countryId", pobj.countryId);
                sqlCmd.Parameters.AddWithValue("@height", pobj.height);
                sqlCmd.Parameters.AddWithValue("@weight", pobj.weight);
                sqlCmd.Parameters.AddWithValue("@activity", pobj.activity);
                sqlCmd.Parameters.AddWithValue("@isPregnant", pobj.isPregnant);
                sqlCmd.Parameters.AddWithValue("@pregnantCondition", pobj.pregnantCondition);
                sqlCmd.Parameters.AddWithValue("@islactation", pobj.islactation);
                sqlCmd.Parameters.AddWithValue("@lactationCondition", pobj.lactationCondition);
                sqlCmd.Parameters.AddWithValue("@mobileOTPId", pobj.mobileOTPId);
                sqlCmd.Parameters.AddWithValue("@otp", pobj.otp);
                sqlCmd.Parameters.AddWithValue("@ipAddress", pobj.ipAddress);
                sqlCmd.Parameters.AddWithValue("@regToken", pobj.regToken);
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
    public class BAL_Registration
    {
        public static void SendMobileOTP(PAL_Registration pobj)
        {
            pobj.opCode = 11;
            DAL_Registration.ReturnTable(pobj);
        }
        public static void ReGenerateMobileOTP(PAL_Registration pobj)
        {
            pobj.opCode = 12;
            DAL_Registration.ReturnTable(pobj);
        }
        public static void NewRegistration(PAL_Registration pobj)
        {
            pobj.opCode = 13;
            DAL_Registration.ReturnTable(pobj);
        }
        public static void MobileOTPVerification(PAL_Registration pobj)
        {
            pobj.opCode = 21;
            DAL_Registration.ReturnTable(pobj);
        }
        public static void CheckExistMobile(PAL_Registration pobj)
        {
            pobj.opCode = 41;
            DAL_Registration.ReturnTable(pobj);
        }
    }
}
