using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLNutriAnalyser
{
    public class PAL_NutriAnalyser : Utility
    {
        public int userID { get; set; }
        public int memberID { get; set; }
        public string intakeDate { get; set; }
        public string queryType { get; set; }
		public int PID { get; set; }
        public DataTable foodList { get; set; }
        public DataTable ingredientList { get; set; }
        public DataTable nutrientIDList { get; set; }
        public DataTable nutrientPriorityList { get; set; }
    }

    public class NutriAnalyserValues
    {
        public List<FoodList> foodList { get; set; }
        public List<Nutrients> nutrients { get; set; }
    }

    public class FoodList
    {
        public int dietID { get; set; }
        public int foodID { get; set; }
        public int brandID { get; set; }
        public string foodName { get; set; }
        public decimal foodQuantity { get; set; }
        public int minFoodQuantity { get; set; }
        public int maxFoodQuantity { get; set; }
        public decimal step { get; set; }
        public int unitID { get; set; }
        public string unitName { get; set; }
        public string dietTime { get; set; }
        public int isCooked { get; set; }
        public int dietType { get; set; }
        public List<IngredientList> ingredientList { get; set; }
    }

    public class IngredientList
    {
        public int ingredientID { get; set; }
        public string ingredientName { get; set; }
        public decimal ingredientQuantity { get; set; }
        public int minIngredientQuantity { get; set; }
        public int maxIngredientQuantity { get; set; }
        public decimal step { get; set; }
        public int ingredientUnitID { get; set; }
        public string ingredientUnitName { get; set; }
        public decimal percentageRatio { get; set; }
    }

    public class Nutrients
    {
        public string nutrientCategory { get; set; }

        public List<NutrientList> nutrientList { get; set; }
    }
    public class NutrientList
    {
        public int nutrientID { get; set; }
        public string nutrientName { get; set; }
        public string target { get; set; }
        public string achievedNutrientValue { get; set; }
        public int achievedRDAPercentage { get; set; }
        public string achievedRDAColorCode { get; set; }
        public string extraNutrientValue { get; set; }
        public int extraRDAPercentage { get; set; }
        public string extraRDAColorCode { get; set; }
        public string totalNutrientValue { get; set; }
        public int totalRDAPercentage { get; set; }
        public string unitName { get; set; }
        public string graphCategory { get; set; }
        public string isRequired { get; set; }
    }

    public class DAL_NutriAnalyser
    {
        public static void returnTable(PAL_NutriAnalyser pobj)
        {
            Config connect = new Config();
            SqlCommand sqlCmd = new SqlCommand("usp_NutriAnalyser", connect.con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
            sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            sqlCmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
			sqlCmd.Parameters.AddWithValue("@PID", pobj.PID);
            sqlCmd.Parameters.AddWithValue("@foodList", pobj.foodList);
            sqlCmd.Parameters.AddWithValue("@ingredientList", pobj.ingredientList);
            sqlCmd.Parameters.AddWithValue("@nutrientIDList", pobj.nutrientIDList);
            sqlCmd.Parameters.AddWithValue("@nutrientPriorityList", pobj.nutrientPriorityList);
            sqlCmd.Parameters.AddWithValue("@queryType", pobj.queryType);
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
    }
    public class BAL_NutriAnalyser
    {
        public static void GetNutriAnalyserValues(PAL_NutriAnalyser pobj)
        {
            pobj.opCode = 41;
            DAL_NutriAnalyser.returnTable(pobj);
        }
        public static void NutrientPriorityWiseFood(PAL_NutriAnalyser pobj)
        {
            pobj.opCode = 42;
            DAL_NutriAnalyser.returnTable(pobj);
        }
		public static void getWhatToEat(PAL_NutriAnalyser pobj)
        {
            pobj.opCode = 43;
            DAL_NutriAnalyser.returnTable(pobj);
        }
    }
}