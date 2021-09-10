using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLIntakeByDiningTable
{
    public class PALIntakeByDiningTable : Utility
    {
        public int diningTableID { get; set; }
        public string diningTableName { get; set; }
        public string foodContainerName { get; set; }
        public decimal foodQuantity { get; set; }
        public decimal finalFoodQuantity { get; set; }
        public string intakeDateTime { get; set; }
        public int status { get; set; }
        public int unitID { get; set; }
        public int foodID { get; set; }
        public int recipeCombinationMainID { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
        public DataTable foodContainerDetails { get; set; }
        public int diningTableSessionMainID { get; set; }
        public int biometricID { get; set; }
        public int ladleID { get; set; }
        public string ladleName { get; set; }
        public int buttonData { get; set; }
        public string bluetoothBandName { get; set; }
        public int foodUnitId { get; set; }
        public int type { get; set; }
    }
    public class DALIntakeByDiningTable
    {
        public static void ReturnTable(PALIntakeByDiningTable pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_IntakeByDiningTable", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@diningTableName", pobj.diningTableName);
                sqlCmd.Parameters.AddWithValue("@diningTableID", pobj.diningTableID);
                sqlCmd.Parameters.AddWithValue("@foodContainerName", pobj.foodContainerName);
                sqlCmd.Parameters.AddWithValue("@diningTableSessionMainID", pobj.diningTableSessionMainID);
                sqlCmd.Parameters.AddWithValue("@foodQuantity", pobj.foodQuantity);
                sqlCmd.Parameters.AddWithValue("@finalFoodQuantity", pobj.finalFoodQuantity);
                sqlCmd.Parameters.AddWithValue("@foodContainerDetails", pobj.foodContainerDetails);
                sqlCmd.Parameters.AddWithValue("@unitID", pobj.unitID);
                sqlCmd.Parameters.AddWithValue("@foodID", pobj.foodID);
                sqlCmd.Parameters.AddWithValue("@intakeID", pobj.recipeCombinationMainID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@ladleID", pobj.ladleID);
                sqlCmd.Parameters.AddWithValue("@ladleName", pobj.ladleName);
                sqlCmd.Parameters.AddWithValue("@buttonData", pobj.buttonData);
                sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
                sqlCmd.Parameters.AddWithValue("@bluetoothBandName", pobj.bluetoothBandName);
                sqlCmd.Parameters.AddWithValue("@intakeDateTime", pobj.intakeDateTime);
                sqlCmd.Parameters.AddWithValue("@foodUnitId", pobj.foodUnitId);
                sqlCmd.Parameters.AddWithValue("@type", pobj.type);
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
    public class BALIntakeByDiningTable
    {
        public static void InsertDiningTableFoodQuantity(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 11;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void StartDiningTableSession(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 12;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void LadleBiometricData(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 13;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void LadleButtonData(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 14;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void InsertDiningTableIntake(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 15;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void InsertDiningTableIntakeData(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 16;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void EndDiningTableSession(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 21;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void GetDiningTableList(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 41;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void CheckDiningTableSession(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 42;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void GetContainerSessionData(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 43;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void GetDiningTableSessionDetails(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 44;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
        public static void GetDiningTableSessionFoodData(PALIntakeByDiningTable pobj)
        {
            pobj.opCode = 45;
            DALIntakeByDiningTable.ReturnTable(pobj);
        }
    }
}













