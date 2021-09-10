using System;
using System.Data.SqlClient;
using System.Data;
using DLLUtility;

namespace DLLRecipeMaster
{
    public class PALRecipeMaster:Utility
    {
        public Int32 userId { get; set; }
        public Int32 memberId { get; set; }
        public Int32 foodId { get; set; }
        public Int32 recipeMainId { get; set; }
        public string newDish { get; set; }
        public string prefixText {get; set; }
        public Int32 foodGroupId { get; set; }
        public decimal cookedFoodQty { get; set; }
        public Int32 cookedFoodQtyUnit { get; set; }
        public DataTable tblIngredient { get; set; }
    }

    public class DALRecipeMaster
    {
        public static void ReturnTable(PALRecipeMaster pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_RecipeMaster", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userId", pobj.userId);
                sqlCmd.Parameters.AddWithValue("@memberId", pobj.memberId);
                sqlCmd.Parameters.AddWithValue("@foodId", pobj.foodId);
                sqlCmd.Parameters.AddWithValue("@recipeMainId", pobj.recipeMainId);
                sqlCmd.Parameters.AddWithValue("@newDish", pobj.newDish);
                sqlCmd.Parameters.AddWithValue("@prefixText", pobj.prefixText);
                sqlCmd.Parameters.AddWithValue("@foodGroupId", pobj.foodGroupId);
                sqlCmd.Parameters.AddWithValue("@cookedFoodQty", pobj.cookedFoodQty);
                sqlCmd.Parameters.AddWithValue("@cookedFoodQtyUnit", pobj.cookedFoodQtyUnit);
                sqlCmd.Parameters.AddWithValue("@tblIngredient", pobj.tblIngredient);
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
            catch(Exception ex)
            {
                pobj.isException = true;
                pobj.exceptionMessage = ex.Message;
            }
        }
    }
    public class BALRecipeMster
    {
        public static void InsertRecipeDetails(PALRecipeMaster pobj)
        {
            pobj.opCode = 11;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void InsertNewDish(PALRecipeMaster pobj)
        {
            pobj.opCode = 12;
            DALRecipeMaster.ReturnTable(pobj);
        }
        //public static void UpdateRecipeDetails(PALRecipeMaster pobj)
        //{
        //    pobj.opCode = 21;
        //    DALRecipeMaster.ReturnTable(pobj);
        //}
        public static void DeleteRecipeDetails(PALRecipeMaster pobj)
        {
            pobj.opCode = 31;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetRecipeList(PALRecipeMaster pobj)
        {
            pobj.opCode = 41;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetRecipeListByUserId(PALRecipeMaster pobj)
        {
            pobj.opCode = 42;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetIngredientsByPrefixtext(PALRecipeMaster pobj)
        {
            pobj.opCode = 43;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetIngredientsByfoodId(PALRecipeMaster pobj)
        {
            pobj.opCode = 44;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void CheckRecipeExistence(PALRecipeMaster pobj)
        {
            pobj.opCode = 45;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetFoodGroup(PALRecipeMaster pobj)
        {
            pobj.opCode = 46;
            DALRecipeMaster.ReturnTable(pobj);
        }
        //public static void GetIngredientsByUserRecipeMainID(PALRecipeMaster pobj)
        //{
        //    pobj.opCode = 47;
        //    DALRecipeMaster.ReturnTable(pobj);
        //}
        public static void GetCookedFoodListByPrefixText(PALRecipeMaster pobj)
        {
            pobj.opCode = 47;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetFoodListByPrefixText(PALRecipeMaster pobj)
        {
            pobj.opCode = 48;
            DALRecipeMaster.ReturnTable(pobj);
        }
        public static void GetIntakeListByPrefixText(PALRecipeMaster pobj)
        {
            pobj.opCode = 50;
            DALRecipeMaster.ReturnTable(pobj);
        }
    }
}
