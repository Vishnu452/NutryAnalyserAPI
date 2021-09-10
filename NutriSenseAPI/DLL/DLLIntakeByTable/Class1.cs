using DLLUtility;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DLLIntakeByTable
{
    public class PALIntakeByTable : Utility
    {
        public int diningTableID { get; set; }
        public string diningTableName { get; set; }
        public string foodContainerName { get; set; }
        public decimal foodQuantity { get; set; }
        public int unitID { get; set; }
        public int foodID { get; set; }
        public int recipeCombinationMainID { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
        public DataTable foodContainerDetails { get; set; }
        public int diningTableSessionMainID { get; set; }
        public string ladleName { get; set; }
        public int buttonData { get; set; }
        public string bluetoothBandName { get; set; }
        public int type { get; set; }
    }
    public class DALIntakeByTable
    {
        public static void ReturnTable(PALIntakeByTable pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_IntakeByTable", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@diningTableName", pobj.diningTableName);
                sqlCmd.Parameters.AddWithValue("@diningTableID", pobj.diningTableID);
                sqlCmd.Parameters.AddWithValue("@foodContainerName", pobj.foodContainerName);
                sqlCmd.Parameters.AddWithValue("@diningTableSessionMainID", pobj.diningTableSessionMainID);
                sqlCmd.Parameters.AddWithValue("@foodQuantity", pobj.foodQuantity);
                sqlCmd.Parameters.AddWithValue("@foodContainerDetails", pobj.foodContainerDetails);
                sqlCmd.Parameters.AddWithValue("@unitID", pobj.unitID);
                sqlCmd.Parameters.AddWithValue("@foodID", pobj.foodID);
                sqlCmd.Parameters.AddWithValue("@intakeID", pobj.recipeCombinationMainID);
                sqlCmd.Parameters.AddWithValue("@memberID", pobj.memberID);
                sqlCmd.Parameters.AddWithValue("@userID", pobj.userID);
                sqlCmd.Parameters.AddWithValue("@ladleName", pobj.ladleName);
                sqlCmd.Parameters.AddWithValue("@buttonData", pobj.buttonData);
                sqlCmd.Parameters.AddWithValue("@bluetoothBandName", pobj.bluetoothBandName);
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
    public class BALIntakeByTable
    {
        public static void StartDiningTableSession(PALIntakeByTable pobj)
        {
            pobj.opCode = 11;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void StartTakingDish(PALIntakeByTable pobj)
        {
            pobj.opCode = 12;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void InsertTableFoodQuantity(PALIntakeByTable pobj)
        {
            pobj.opCode = 13;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void InsertDiningTableIntake(PALIntakeByTable pobj)
        {
            pobj.opCode = 14;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void LadleBiometricData(PALIntakeByTable pobj)
        {
            pobj.opCode = 15;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void LadleButtonData(PALIntakeByTable pobj)
        {
            pobj.opCode = 16;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void EndDiningTableSession(PALIntakeByTable pobj)
        {
            pobj.opCode = 21;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void GetDiningTableList(PALIntakeByTable pobj)
        {
            pobj.opCode = 41;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void CheckDiningTableSession(PALIntakeByTable pobj)
        {
            pobj.opCode = 42;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void GetConsumedFoodListByMember(PALIntakeByTable pobj)
        {
            pobj.opCode = 43;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void GetIntakeListByFoodID(PALIntakeByTable pobj)
        {
            pobj.opCode = 44;
            DALIntakeByTable.ReturnTable(pobj);
        }
        public static void GetConsumedFoodQuantity(PALIntakeByTable pobj)
        {
            pobj.opCode = 45;
            DALIntakeByTable.ReturnTable(pobj);
        }
    }
}