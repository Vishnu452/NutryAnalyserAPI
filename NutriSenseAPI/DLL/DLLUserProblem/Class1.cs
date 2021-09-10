using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;

namespace DLLUserProblem
{
    public class PAL_UserProblem : Utility
    {
        public string searchText { get; set; }
        public int problemID { get; set; }
        public int userProblemID { get; set; }
        public string problemDate { get; set; }
        public string problemTimeFrom { get; set; }
        public string problemTimeTo { get; set; }
        public int memberID { get; set; }
        public int userID { get; set; }
    }

    public class DAL_UserProblem
    {
        public static void returnTable(PAL_UserProblem pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_UserProblem", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@searchText", pobj.searchText);
            cmd.Parameters.AddWithValue("@problemID", pobj.problemID);
            cmd.Parameters.AddWithValue("@userProblemID", pobj.userProblemID);
            cmd.Parameters.AddWithValue("@problemDate", pobj.problemDate);
            cmd.Parameters.AddWithValue("@problemTimeFrom", pobj.problemTimeFrom);
            cmd.Parameters.AddWithValue("@problemTimeTo", pobj.problemTimeTo);
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
    public class BAL_UserProblem
    {
        public static void AddUserProblem(PAL_UserProblem pobj)
        {
            pobj.opCode = 11;
            DAL_UserProblem.returnTable(pobj);
        }
        public static void UpdateUserProblem(PAL_UserProblem pobj)
        {
            pobj.opCode = 21;
            DAL_UserProblem.returnTable(pobj);
        }
        public static void RemoveUserProblem(PAL_UserProblem pobj)
        {
            pobj.opCode = 31;
            DAL_UserProblem.returnTable(pobj);
        }
        public static void GetProblemListBySearchText(PAL_UserProblem pobj)
        {
            pobj.opCode = 41;
            DAL_UserProblem.returnTable(pobj);
        }
        public static void GetUserProblemListByProblemDate(PAL_UserProblem pobj)
        {
            pobj.opCode = 42;
            DAL_UserProblem.returnTable(pobj);
        }
    }
}