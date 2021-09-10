using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLSmartTable
{
    public class PAL_SmartTable : Utility
    {
        public string smartTableName { get; set; }
        public int sessionID { get; set; }
        public int idNo { get; set; }
        public int foodID { get; set; }
        public int combinationID { get; set; }
        public decimal foodQuantity { get; set; }
        public string intakeDateTime { get; set; }
        public string queryParam { get; set; }
        public int memberID { get; set; }
        public int smartTableID { get; set; }
        public int userLoginID { get; set; }
        public DataTable combinationList { get; set; }
        public DataTable participantDetail { get; set; }
        public DataTable containerDetail { get; set; }
    }
    public class CombinationList
    {
        public string combinationName { get; set; }
        public int ingredientID { get; set; }
    }
    public class DAL_SmartTable
    {
        public static void ReturnTable(PAL_SmartTable pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_SmartTable", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@smartTableName", pobj.smartTableName);
                sqlCmd.Parameters.AddWithValue("@sessionID", pobj.sessionID);
                sqlCmd.Parameters.AddWithValue("@idNo", pobj.idNo);
                sqlCmd.Parameters.AddWithValue("@foodID", pobj.foodID);
                sqlCmd.Parameters.AddWithValue("@combinationID", pobj.combinationID);
                sqlCmd.Parameters.AddWithValue("@foodQuantity", pobj.foodQuantity);
                sqlCmd.Parameters.AddWithValue("@intakeDateTime", pobj.intakeDateTime);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@smartTableID", pobj.smartTableID);
                sqlCmd.Parameters.AddWithValue("@userLoginID", pobj.userLoginID);
                sqlCmd.Parameters.AddWithValue("@combinationList", pobj.combinationList);
                sqlCmd.Parameters.AddWithValue("@participantDetail", pobj.participantDetail);
                sqlCmd.Parameters.AddWithValue("@containerDetail", pobj.containerDetail);
                sqlCmd.Parameters.AddWithValue("@queryParam", pobj.queryParam);
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
    public class BAL_SmartTable
    {
        public static void AddSmartTableIntakeDetail(PAL_SmartTable pobj)
        {
            pobj.opCode = 11;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void UpdateRecipeCombination(PAL_SmartTable pobj)
        {
            pobj.opCode = 12;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void StartNewSession(PAL_SmartTable pobj)
        {
            pobj.opCode = 13;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void StopSession(PAL_SmartTable pobj)
        {
            pobj.opCode = 14;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetSmartTableSessionDetail(PAL_SmartTable pobj)
        {
            pobj.opCode = 41;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetActiveSessionDetailByMemberID(PAL_SmartTable pobj)
        {
            pobj.opCode = 42;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetContainerDetailByTableID(PAL_SmartTable pobj)
        {
            pobj.opCode = 43;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetRecipeCombinationList(PAL_SmartTable pobj)
        {
            pobj.opCode = 44;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetLiveMemberFoodDetail(PAL_SmartTable pobj)
        {
            pobj.opCode = 45;
            DAL_SmartTable.ReturnTable(pobj);
        }
        public static void GetRecipeIngredientList(PAL_SmartTable pobj)
        {
            pobj.opCode = 46;
            DAL_SmartTable.ReturnTable(pobj);
        }
    }
}
