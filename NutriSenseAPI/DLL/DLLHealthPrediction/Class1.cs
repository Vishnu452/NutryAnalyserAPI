using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLHealthPrediction
{
    public class PAL_HealthPrediction : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
    }

    public class DAL_HealthPrediction
    {
        public static void ReturnTable(PAL_HealthPrediction pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_HealthPrediction", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
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
    public class BAL_HealthPrediction
    {
        public static void GetTodaysHealthPrediction(PAL_HealthPrediction pobj)
        {
            pobj.opCode = 41;
            DAL_HealthPrediction.ReturnTable(pobj);
        }
    }
}