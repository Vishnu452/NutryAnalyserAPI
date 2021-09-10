using DLLUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLDeficientNutrientReport
{
    public class PAL_DeficientNutrientReport : Utility
    {
        public Int32 userId { get; set; }
        public Int32 memberId { get; set; }
        public DateTime intakeFromDate { get; set; }
        public DateTime intakeToDate { get; set; }
        public string nutrientType { get; set; }

    }

    public class DAL_DeficientNutrientReport
    {
        public static void returnTable(PAL_DeficientNutrientReport pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_DeficientNutritionReport", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@memberId", pobj.memberId);
            cmd.Parameters.AddWithValue("@intakeFromDate", pobj.intakeFromDate);
            cmd.Parameters.AddWithValue("@intakeToDate", pobj.intakeToDate);
            cmd.Parameters.AddWithValue("@userId", pobj.userId);
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
    public class BAL_DeficientNutrientReport
    {
        public static void GetDeficientNutrientBetweenTwoDates(PAL_DeficientNutrientReport pobj)
        {
            pobj.opCode = 41;
            DAL_DeficientNutrientReport.returnTable(pobj);
        }
        public static void GetNutrientAverageDeficiencyBetweenTwoDates(PAL_DeficientNutrientReport pobj)
        {
            pobj.opCode = 42;
            DAL_DeficientNutrientReport.returnTable(pobj);
        }

    }
}
