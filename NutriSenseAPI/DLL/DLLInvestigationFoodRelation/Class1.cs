using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLInvestigationFoodRelation
{
    public class PAL_InvestigationFoodRelation : Utility
    {
        public int pid { get; set; }
        public Int32 userId { get; set; }
        public Int32 memberId { get; set; }
        public Int32 foodId { get; set; }
        public Int32 diseaseID { get; set; }
        public Int32 nutrientID { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
    public class DAL_InvestigationFoodRelation
    {
        public static void returnTable(PAL_InvestigationFoodRelation pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_InvestigationFoodRelation", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@pid", pobj.pid);
            cmd.Parameters.AddWithValue("@userID", pobj.userId);
            cmd.Parameters.AddWithValue("@memberId", pobj.memberId);
            cmd.Parameters.AddWithValue("@foodId", pobj.foodId);
            cmd.Parameters.AddWithValue("@nutrientID", pobj.nutrientID);
            cmd.Parameters.AddWithValue("@diseaseID", pobj.diseaseID);
            cmd.Parameters.AddWithValue("@fromDate", pobj.fromDate);
            cmd.Parameters.AddWithValue("@toDate", pobj.toDate);
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
    public class BAL_InvestigationFoodRelation
    {
        public static void getInvestigationFoodRelation(PAL_InvestigationFoodRelation pobj)
        {
            pobj.opCode = 41;
            DAL_InvestigationFoodRelation.returnTable(pobj);
        }
        
    }
}
