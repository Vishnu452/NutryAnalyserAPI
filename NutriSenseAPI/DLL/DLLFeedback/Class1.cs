using System;
using System.Data;
using System.Data.SqlClient;
using DLLUtility;

namespace DLLFeedback
{
    public class PAL_Feedback : Utility
    {
        public int userID { get; set; }
        public string feedback { get; set; }
        public int feedbackCategoryID { get; set; }
    }

    public class DAL_Feedback
    {
        public static void returnTable(PAL_Feedback pobj)
        {
            Config connect = new Config();
            SqlCommand cmd = new SqlCommand("usp_Feedback", connect.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@opCode", pobj.opCode);
            cmd.Parameters.AddWithValue("@userID", pobj.userID);
            cmd.Parameters.AddWithValue("@feedback", pobj.feedback);
            cmd.Parameters.AddWithValue("@feedbackCategoryID", pobj.feedbackCategoryID);
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
    public class BAL_Feedback
    {
        public static void GetFeedbackCategory(PAL_Feedback pobj)
        {
            pobj.opCode = 41;
            DAL_Feedback.returnTable(pobj);
        }
        public static void SubmitFeedback(PAL_Feedback pobj)
        {
            pobj.opCode = 11;
            DAL_Feedback.returnTable(pobj);
        }
    }
}