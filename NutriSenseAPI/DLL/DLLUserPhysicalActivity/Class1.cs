using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLUserPhysicalActivity
{
    public class PAL_UserPhysicalActivity : Utility
    {
        public string searchText { get; set; }
        public int activityID { get; set; }
        public int userActivityID { get; set; }
        public int rating { get; set; }
        public string activityDate { get; set; }
        public string activityTimeFrom { get; set; }
        public string activityTimeTo { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
    }

    public class DAL_UserPhysicalActivity
    {
        public static void returnTable(PAL_UserPhysicalActivity pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_UserPhysicalActivity", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@searchText", pobj.searchText);
            cmd.Parameters.AddWithValue("@activityID", pobj.activityID);
            cmd.Parameters.AddWithValue("@userActivityID", pobj.userActivityID);
            cmd.Parameters.AddWithValue("@rating", pobj.rating);
            cmd.Parameters.AddWithValue("@activityDate", pobj.activityDate);
            cmd.Parameters.AddWithValue("@activityTimeFrom", pobj.activityTimeFrom);
            cmd.Parameters.AddWithValue("@activityTimeTo", pobj.activityTimeTo);
            cmd.Parameters.AddWithValue("@memberID", pobj.memberID);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
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
    public class BAL_UserPhysicalActivity
    {
        public static void AddUserActivity(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 11;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
        public static void UpdateUserActivity(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 21;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
        public static void RemoveUserActivity(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 31;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
        public static void GetActivityListBySearchText(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 41;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
        public static void GetUserActivityListByActivityDate(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 42;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
        public static void GetActivityList(PAL_UserPhysicalActivity pobj)
        {
            pobj.opCode = 43;
            DAL_UserPhysicalActivity.returnTable(pobj);
        }
    }
}