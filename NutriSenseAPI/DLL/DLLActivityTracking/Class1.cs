using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLActivityTracking
{
    public class PAL_ActivityTracking : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
        public int PID { get; set; }
        public int pmID { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
    public class DAL_ActivityTracking
    {
        public static void ReturnTable(PAL_ActivityTracking pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_ActivityTracking", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@PID", pobj.PID);
                sqlCmd.Parameters.AddWithValue("@pmID", pobj.pmID);
                sqlCmd.Parameters.AddWithValue("@fromDate", pobj.fromDate);
                sqlCmd.Parameters.AddWithValue("@toDate", pobj.toDate);
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
    public class BAL_ActivityTracking
    {
        public static void getActivityTracking(PAL_ActivityTracking pobj)
        {
            pobj.opCode = 41;
            DAL_ActivityTracking.ReturnTable(pobj);
        }
    }
}
