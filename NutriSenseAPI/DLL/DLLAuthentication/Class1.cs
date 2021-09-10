using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLAuthentication
{
    public class PAL_Authentication : Utility
    {
        public int userLoginID { get; set; }
        public int userID { get; set; }
        public string userToken { get; set; }
    }

    public class DAL_Authentication
    {
        public static void returnTable(PAL_Authentication pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_Authentication", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@userLoginID", pobj.userLoginID);
            cmd.Parameters.AddWithValue("@userId", pobj.userID);
            cmd.Parameters.AddWithValue("@userToken", pobj.userToken);
            cmd.Parameters.Add("@isException", SqlDbType.Bit);
            cmd.Parameters["@isException"].Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@exceptionMessage", SqlDbType.VarChar, 500);
            cmd.Parameters["@exceptionMessage"].Direction = ParameterDirection.Output;
            SqlDataAdapter sqlAdp = new SqlDataAdapter(cmd);
            pobj.DS = new DataSet();
            sqlAdp.Fill(pobj.DS);
            pobj.isException = Convert.ToBoolean(cmd.Parameters["@isException"].Value);
            pobj.exceptionMessage = cmd.Parameters["@exceptionMessage"].Value.ToString();
        }
    }
    public class BAL_Authentication
    {
        public static void IsValidUserAuthentication(PAL_Authentication pobj)
        {
            pobj.opCode = 41;
            DAL_Authentication.returnTable(pobj);
        }
        public static void IsValidUserAuthenticationWithUserID(PAL_Authentication pobj)
        {
            pobj.opCode = 42;
            DAL_Authentication.returnTable(pobj);
        }
        public static void IsValidOPDToken(PAL_Authentication pobj)
        {
            pobj.opCode = 43;
            DAL_Authentication.returnTable(pobj);
        }
    }
}
