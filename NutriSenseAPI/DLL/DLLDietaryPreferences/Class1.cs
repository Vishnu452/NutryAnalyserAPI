using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLDietaryPreferences
{
    public class PAL_DietaryPreferences : Utility
    {
        public int userId { get; set; }
        public int memberId { get; set; }
        public int foodTypeID { get; set; }
        public DataTable dtDietFoodPreffered { get; set; }
        public DataTable dtDietFoodAvoid { get; set; }
        public DataTable diseaseList { get; set; }
    }
    public class DAL_DietaryPreferences
    {
        public static void ReturnTable(PAL_DietaryPreferences pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_DietaryDetails", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userId", pobj.userId);
                sqlCmd.Parameters.AddWithValue("@memberId", pobj.memberId);
                sqlCmd.Parameters.AddWithValue("@foodTypeID", pobj.foodTypeID);
                sqlCmd.Parameters.AddWithValue("@dtDietFoodPreffered", pobj.dtDietFoodPreffered);
                sqlCmd.Parameters.AddWithValue("@dtDietFoodAvoid", pobj.dtDietFoodAvoid);
                sqlCmd.Parameters.AddWithValue("@diseaseList", pobj.diseaseList);
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
    public class BAL_DietaryPreferences
    {
        public static void InsertUserDietaryPrefferedFood(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 11;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void InsertUserDietaryAvoidFood(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 12;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void InsertUserDisease(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 13;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void GetFoodType(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 41;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void GetFoodByFoodType(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 42;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void GetRestrictedFood(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 43;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void GetAllergicFood(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 44;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
        public static void GetDiseaseList(PAL_DietaryPreferences pobj)
        {
            pobj.opCode = 45;
            DAL_DietaryPreferences.ReturnTable(pobj);
        }
    }
}