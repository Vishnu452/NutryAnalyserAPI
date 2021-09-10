using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;

namespace DLLWaterIntake
{
    public class PAL_WaterIntake : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
        public string date { get; set; }
    }

    public class DAL_WaterIntake
    {
        public static void returnTable(PAL_WaterIntake pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_WaterIntake", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            cmd.Parameters.AddWithValue("@date", pobj.date);
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
    public class BAL_WaterIntake
    {
        public static void GetWaterIntakeDetail(PAL_WaterIntake pobj)
        {
            pobj.opCode = 41;
            DAL_WaterIntake.returnTable(pobj);
        }
        public static void IntakeWaterGlass(PAL_WaterIntake pobj)
        {
            pobj.opCode = 11;
            DAL_WaterIntake.returnTable(pobj);
        }
        public static void RemoveWaterGlass(PAL_WaterIntake pobj)
        {
            pobj.opCode = 21;
            DAL_WaterIntake.returnTable(pobj);
        }
    }
}