using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLIdealNutrientGraph
{
    public class PAL_IdealNutrientGraph : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
        public int nutrientID { get; set; }
        public string intakeDate { get; set; }
        public string searchText { get; set; }
    }

    public class DAL_IdealNutrientGraph
    {
        public static void returnTable(PAL_IdealNutrientGraph pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_IdealNutrientGraph", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            cmd.Parameters.AddWithValue("@nutrientID", pobj.nutrientID);
            cmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
            cmd.Parameters.AddWithValue("@searchText", pobj.searchText);
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
    public class BAL_IdealNutrientGraph
    {
        public static void GetNutrientSerachList(PAL_IdealNutrientGraph pobj)
        {
            pobj.opCode = 41;
            DAL_IdealNutrientGraph.returnTable(pobj);
        }
        public static void GetIdealNutrientIntakeGraphData(PAL_IdealNutrientGraph pobj)
        {
            pobj.opCode = 42;
            DAL_IdealNutrientGraph.returnTable(pobj);
        }
        public static void GetIdealSupplementIntakeGraphData(PAL_IdealNutrientGraph pobj)
        {
            pobj.opCode = 43;
            DAL_IdealNutrientGraph.returnTable(pobj);
        }
    }
}