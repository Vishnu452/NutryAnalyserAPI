using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLNutrientAchievementReport
{
    public class PAL_NutrientAchievementReport : Utility
    {
        public string intakeFromdate { get; set; }
        public string intakeToDate { get; set; }
        public DataTable dateList { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
    }
    public class DAL_NutrientAchievementReport
    {
        public static void returnTable(PAL_NutrientAchievementReport pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_NutrientAchievementReport", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@intakeFromdate", pobj.intakeFromdate);
            cmd.Parameters.AddWithValue("@intakeToDate", pobj.intakeToDate);
            cmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@dateList", pobj.dateList);
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
    public class BAL_NutrientAchievementReport
    {
        public static void GetDateListBetweenDates(PAL_NutrientAchievementReport pobj)
        {
            pobj.opCode = 41;
            DAL_NutrientAchievementReport.returnTable(pobj);
        }
        public static void GetNutrientAverageBySelectedDates(PAL_NutrientAchievementReport pobj)
        {
            pobj.opCode = 42;
            DAL_NutrientAchievementReport.returnTable(pobj);
        }
    }
}