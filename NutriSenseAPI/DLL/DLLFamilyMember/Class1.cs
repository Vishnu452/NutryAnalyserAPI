using System;
using DLLUtility;
using System.Data.SqlClient;
using System.Data;
namespace DLLFamilyMember
{
    public class PALFamilyMember:Utility
    {
        public string memberName { get; set; }
        public string address { get; set; }
        public int gender { get; set; }
        public DateTime dob { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int userId { get; set; }
        public int activity { get; set; }
        public int isPregnant { get; set; }
        public int pregnantCondition { get; set; }
        public int isLactation { get; set; }
        public int lactationCondition { get; set; }
        public int memberId { get; set; }
        public int PID { get; set; }
        public string memberType { get; set; }
        public string diagnosis { get; set; }
    }
    public class DALFamilyMember
    {
        public static void ReturnTable(PALFamilyMember pobj)
        {
            try
            {
                Config connect = new Config();
                SqlCommand sqlCmd = new SqlCommand("usp_FamilyMember", connect.con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@opCode", pobj.opCode);
                sqlCmd.Parameters.AddWithValue("@memberName", pobj.memberName);
                sqlCmd.Parameters.AddWithValue("@gender", pobj.gender);
                if (pobj.dob > DateTime.MinValue)
                    sqlCmd.Parameters.AddWithValue("@dob", pobj.dob);
                sqlCmd.Parameters.AddWithValue("@userId", pobj.userId);
                sqlCmd.Parameters.AddWithValue("@height", pobj.height);
                sqlCmd.Parameters.AddWithValue("@weight", pobj.weight);
                sqlCmd.Parameters.AddWithValue("@activity", pobj.activity);
                sqlCmd.Parameters.AddWithValue("@isPregnant", pobj.isPregnant);
                sqlCmd.Parameters.AddWithValue("@pregnantCondition", pobj.pregnantCondition);
                sqlCmd.Parameters.AddWithValue("@isLactation", pobj.isLactation);
                sqlCmd.Parameters.AddWithValue("@lactationCondition ", pobj.lactationCondition);
                sqlCmd.Parameters.AddWithValue("@memberId", pobj.memberId);
                sqlCmd.Parameters.AddWithValue("@address", pobj.address);
                sqlCmd.Parameters.AddWithValue("@PID", pobj.PID);
                sqlCmd.Parameters.AddWithValue("@memberType", pobj.memberType);
                sqlCmd.Parameters.AddWithValue("@diagnosis", pobj.diagnosis);
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
    public class BALFamilyMember
    {
        public static void InsertMemberDetails(PALFamilyMember pobj)
        {
            pobj.opCode = 11;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void AddNutriAnalyserProfile(PALFamilyMember pobj)
        {
            pobj.opCode = 12;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void UpdateMemberDetails(PALFamilyMember pobj)
        {
            pobj.opCode = 21;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void AddPatientToNutritionalPanel(PALFamilyMember pobj)
        {
            pobj.opCode = 22;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void RemovePatientFromNutritionalPanel(PALFamilyMember pobj)
        {
            pobj.opCode = 23;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void DeleteMemberDetails(PALFamilyMember pobj)
        {
            pobj.opCode = 31;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void GetMemberDetails(PALFamilyMember pobj)
        {
            pobj.opCode = 41;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void GetMemberDetailsById(PALFamilyMember pobj)
        {
            pobj.opCode = 42;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void GetNutritionalPanelPatientList(PALFamilyMember pobj)
        {
            pobj.opCode = 43;
            DALFamilyMember.ReturnTable(pobj);
        }
        public static void GetUserProfileByPID(PALFamilyMember pobj)
        {
            pobj.opCode = 44;
            DALFamilyMember.ReturnTable(pobj);
        }
    }
}
