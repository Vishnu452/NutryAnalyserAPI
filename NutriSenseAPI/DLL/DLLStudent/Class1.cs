using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;
namespace DLLStudent
{
    public class PAL_Student:Utility
    {
       
        public string studentId { get; set; }
        public Int32 userId { get; set; }
        public Int32 foodId { get; set; }
        public Int32 memberId { get; set; }
        public string prefixText { get; set; }
        public DateTime dietDate { get; set; }
        public DataTable intakeDetails { get; set;}
    }

    public class DAL_Student
    {
        public static void returnTable(PAL_Student pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_StudentDietDetails", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@studentId", pobj.studentId);
            cmd.Parameters.AddWithValue("@foodId", pobj.foodId);
            cmd.Parameters.AddWithValue("@userId", pobj.userId);
            cmd.Parameters.AddWithValue("@memberId", pobj.memberId);
            cmd.Parameters.AddWithValue("@prefixText", pobj.prefixText);
            if(pobj.dietDate>System.DateTime.MinValue)
            cmd.Parameters.AddWithValue("@dietDate", pobj.dietDate);
            cmd.Parameters.AddWithValue("@intakeDetails", pobj.intakeDetails);
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
    public class BAL_Student
    {
        public static void SaveStudentIntakeDetails(PAL_Student pobj)
        {
            pobj.opCode = 11;
            DAL_Student.returnTable(pobj);
        }
        public static void GetStudentDetails(PAL_Student pobj)
        {
            pobj.opCode = 41;
            DAL_Student.returnTable(pobj);
        }
        public static void GetIntakeDetails(PAL_Student pobj)
        {
            pobj.opCode = 42;
            DAL_Student.returnTable(pobj);
        }
        public static void GetFoodByPrefixText(PAL_Student pobj)
        {
            pobj.opCode = 43;
            DAL_Student.returnTable(pobj);
        }
        public static void GetFoodUnitByFoodId(PAL_Student pobj)
        {
            pobj.opCode = 44;
            DAL_Student.returnTable(pobj);
        }

        public static void GetNutritionResult(PAL_Student pobj)
        {
            pobj.opCode = 45;
            DAL_Student.returnTable(pobj);
        }
    }
}
