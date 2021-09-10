using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLIntake
{
    public class PAL_Intake : Utility
    {
        public int userId { get; set; }
        public int entryUserID { get; set; }
        public int isIntakeGiven { get; set; }
        public int dietId { get; set; }
        public int foodId { get; set; }
        public int foodTimeId { get; set; }
        public string foodTime { get; set; }
        public int memberId { get; set; }
        public decimal foodQuantity { get; set; }
        public int foodUnitId { get; set; }
        public DateTime intakeDate { get; set; }
        public string prefixText { get; set; }
        public string nutrientType { get; set; }
        public int isFoodList { get; set; }
        public int isSupplementList { get; set; }
        public int isImmediateEffect { get; set; }
        public int dietType { get; set; }
        public DataTable nutrientNameList { get; set; }
        public int nutrientId { get; set; }
        public int diseaseID { get; set; }
        public int isGraphCategory { get; set; }
        public int isChartNutrients { get; set; }
        public DataTable intakeConsumption { get; set; }
        public int isConsumption { get; set; }
        public string searchBy { get; set; }
        public int PID { get; set; }
        public string queryType { get; set; }
        public string dietTime { get; set; }
        public int nutrientCombinationID { get; set; }
        public bool isRDARequired { get; set; }
        public int id { get; set; }
        public string intakeDateTime { get; set; }
        public int isSupplement { get; set; }
        public string entryType { get; set; }
        public bool isActualDiet { get; set; }
    }

    public class AllNutrientValuesCombinedByFoodTimeId
    {
        public List<FoodList> FoodList { get; set; }
        public List<Nutrients> Nutrients { get; set; }
        public List<SupplementList> SupplementList { get; set; }
        public List<ImmediateEffect> ImmediateEffect { get; set; }
        public List<GraphCategory> GraphCategory { get; set; }
        public List<ChartNutrients> ChartNutrients { get; set; }

    }
    public class FoodList
    {
        public int dietID { get; set; }
        public int foodID { get; set; }
        public string foodName { get; set; }
        public decimal foodQuantity { get; set; }
        public int unitID { get; set; }
        public string unitName { get; set; }
        public int dietTimeId { get; set; }
        public string dietTiming { get; set; }
        public int dietType { get; set; }
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
        public int achievedRDAPercentageFood { get; set; }
        public int achievedRDAPercentageSupplement { get; set; }
        public string achievedRDAColorCode { get; set; }
        public string achievedRDAColorCodeFood { get; set; }
        public string achievedRDAColorCodeSupplement { get; set; }
        public string extraNutrientValue { get; set; }
        public int extraRDAPercentage { get; set; }
        public int extraRDAPercentageFood { get; set; }
        public int extraRDAPercentageSupplement { get; set; }
        public string extraRDAColorCode { get; set; }
        public string extraRDAColorCodeFood { get; set; }
        public string extraRDAColorCodeSupplement { get; set; }
        public string totalNutrientValue { get; set; }
        public int totalRDAPercentage { get; set; }
        public string unitName { get; set; }
        public string graphCategory { get; set; }
        public string customizedPercentage { get; set; }
        public string investigationResult { get; set; }
    }

    public class SupplementList
    {
        public string nutrientName { get; set; }
        public string nutrientValue { get; set; }
        public string rda { get; set; }
        public string requiredQuantity { get; set; }
        public List<SupplementDetails> supplementDetails { get; set; }
    }

    public class SupplementDetails
    {
        public string supplementName { get; set; }
        public string supplementDose { get; set; }
    }

    public class ImmediateEffect
    {
        public string nutrientName { get; set; }
        public string nutrientLevel { get; set; }
        public string symptom { get; set; }
    }
    public class GraphCategory
    {
        public string graphCategory { get; set; }
        public string unitName { get; set; }
    }
    public class ChartNutrients
    {
        public int nutrientID { get; set; }
        public string tagName { get; set; }
        public string target { get; set; }
        public string totalNutrientValue { get; set; }
        public int totalRDAPercentage { get; set; }
        public string unitName { get; set; }
        public string nutrientCategory { get; set; }
    }

    public class NutrientRatio
    {
        public int dietID { get; set; }
        public string foodName { get; set; }
        public decimal foodQuantity { get; set; }
        public string foodUnit { get; set; }
        public decimal nutrientValue { get; set; }
        public string nutrientUnit { get; set; }
        public int nutrientPercentage { get; set; }
        public string foodTiming { get; set; }
        public List<IngredientNutrientValue> ingredientNutrientValue { get; set; }
    }

    public class IngredientNutrientValue
    {
        public string ingredientName { get; set; }
        public decimal nutrientValue { get; set; }
        public string unitName { get; set; }
    }


    public class DAL_Intake
    {
        public static void ReturnTable(PAL_Intake pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_UserIntake", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@userId", pobj.userId);
                sqlCmd.Parameters.AddWithValue("@entryUserID", pobj.entryUserID);
                sqlCmd.Parameters.AddWithValue("@isIntakeGiven", pobj.isIntakeGiven);
                sqlCmd.Parameters.AddWithValue("@dietid", pobj.dietId);
                sqlCmd.Parameters.AddWithValue("@dietType", pobj.dietType);
                sqlCmd.Parameters.AddWithValue("@foodId", pobj.foodId);
                sqlCmd.Parameters.AddWithValue("@foodTimeId", pobj.foodTimeId);
                sqlCmd.Parameters.AddWithValue("@foodTime", pobj.foodTime);
                sqlCmd.Parameters.AddWithValue("@foodQuantity", pobj.foodQuantity);
                sqlCmd.Parameters.AddWithValue("@foodUnitId", pobj.foodUnitId);
                sqlCmd.Parameters.AddWithValue("@memberId", pobj.memberId);
                sqlCmd.Parameters.AddWithValue("@nutrientId", pobj.nutrientId);
                sqlCmd.Parameters.AddWithValue("@nutrientType", pobj.nutrientType);
                sqlCmd.Parameters.AddWithValue("@nutrientNameList", pobj.nutrientNameList);
                sqlCmd.Parameters.AddWithValue("@isFoodList", pobj.isFoodList);
                sqlCmd.Parameters.AddWithValue("@isSupplementList", pobj.isSupplementList);
                sqlCmd.Parameters.AddWithValue("@isImmediateEffect", pobj.isImmediateEffect);
                sqlCmd.Parameters.AddWithValue("@isGraphCategory", pobj.isGraphCategory);
                sqlCmd.Parameters.AddWithValue("@isChartNutrients", pobj.isChartNutrients);
                sqlCmd.Parameters.AddWithValue("@prefixText", pobj.prefixText);
                sqlCmd.Parameters.AddWithValue("@diseaseID", pobj.diseaseID);
                if (pobj.intakeDate > DateTime.MinValue)
                    sqlCmd.Parameters.AddWithValue("@intakeDate", pobj.intakeDate);
                sqlCmd.Parameters.AddWithValue("@isConsumption", pobj.isConsumption);
                sqlCmd.Parameters.AddWithValue("@dtIntakeConsumption", pobj.intakeConsumption);
                sqlCmd.Parameters.AddWithValue("@searchBy", pobj.searchBy);
                sqlCmd.Parameters.AddWithValue("@PID", pobj.PID);
                sqlCmd.Parameters.AddWithValue("@dietTime", pobj.dietTime);
                sqlCmd.Parameters.AddWithValue("@queryType", pobj.queryType);
                sqlCmd.Parameters.AddWithValue("@nutrientCombinationID", pobj.nutrientCombinationID);
                sqlCmd.Parameters.AddWithValue("@isRDARequired", pobj.isRDARequired);
                sqlCmd.Parameters.AddWithValue("@id", pobj.id);
                sqlCmd.Parameters.AddWithValue("@intakeDateTime", pobj.intakeDateTime);
                sqlCmd.Parameters.AddWithValue("@isSupplement", pobj.isSupplement);
                sqlCmd.Parameters.AddWithValue("@entryType", pobj.entryType);
                sqlCmd.Parameters.AddWithValue("@isActualDiet", pobj.isActualDiet);
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
    public class BAL_Intake
    {
        public static void AddIntakeDetails(PAL_Intake pobj)
        {
            pobj.opCode = 11;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void RepeatLastDayIntake(PAL_Intake pobj)
        {
            pobj.opCode = 12;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void CompleteIntake(PAL_Intake pobj)
        {
            pobj.opCode = 21;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void UpdateIntakeConsumption(PAL_Intake pobj)
        {
            pobj.opCode = 22;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void UpdateIntakeTimeByDietID(PAL_Intake pobj)
        {
            pobj.opCode = 23;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void UpdateIntakeDateTimeByIntakeID(PAL_Intake pobj)
        {
            pobj.opCode = 24;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void UpdateIsGivenFoodSupplementByIntakeID(PAL_Intake pobj)
        {
            pobj.opCode = 25;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void DeleteIntakeDetails(PAL_Intake pobj)
        {
            pobj.opCode = 31;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void DeleteAllFoodByDate(PAL_Intake pobj)
        {
            pobj.opCode = 32;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetFoodTimeing(PAL_Intake pobj)
        {
            pobj.opCode = 41;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetFoodList(PAL_Intake pobj)
        {
            pobj.opCode = 42;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetIntakeByFoodTimeId(PAL_Intake pobj)
        {
            pobj.opCode = 43;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetRecentFoodItems(PAL_Intake pobj)
        {
            pobj.opCode = 44;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientValuesByFood(PAL_Intake pobj)
        {
            pobj.opCode = 45;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientValuesByFoodTimeId(PAL_Intake pobj)
        {
            pobj.opCode = 46;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientRatioByNutrientId(PAL_Intake pobj)
        {
            pobj.opCode = 47;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientListByIntake(PAL_Intake pobj)
        {
            pobj.opCode = 48;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetAchievedRDAPercentageColor(PAL_Intake pobj)
        {
            pobj.opCode = 49;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetCurrentTimeWithTimeID(PAL_Intake pobj)
        {
            pobj.opCode = 410;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientByPrefixText(PAL_Intake pobj)
        {
            pobj.opCode = 411;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetDiseaseList(PAL_Intake pobj)
        {
            pobj.opCode = 412;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientListByDiseaseID(PAL_Intake pobj)
        {
            pobj.opCode = 413;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientRatioWithDetailsByNutrientId(PAL_Intake pobj)
        {
            pobj.opCode = 414;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetCutomizedRDAList(PAL_Intake pobj)
        {
            pobj.opCode = 415;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void checkPreference(PAL_Intake pobj)
        {
            pobj.opCode = 416;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientCombinationList(PAL_Intake pobj)
        {
            pobj.opCode = 417;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetNutrientListByCombination(PAL_Intake pobj)
        {
            pobj.opCode = 418;
            DAL_Intake.ReturnTable(pobj);
        }
        public static void GetIntakeByFoodTimeIdWithoutEnergy(PAL_Intake pobj)
        {
            pobj.opCode = 419;
            DAL_Intake.ReturnTable(pobj);
        }
    }
}
