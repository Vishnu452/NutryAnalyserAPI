using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using DLLStudent;
using Newtonsoft.Json;
namespace NutriSenseAPI.API
{
    /// <summary>
    /// Summary description for StudentNutritionAnalyzer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class StudentNutritionAnalyzer : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SaveStudentIntakeDetails(string studentId,string dietDate,string intakeDetails)
        {
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.studentId = studentId;
                pobj.dietDate = Convert.ToDateTime(dietDate);
                pobj.intakeDetails= JsonConvert.DeserializeObject<DataTable>(intakeDetails);
                BAL_Student.SaveStudentIntakeDetails(pobj);
                if (!pobj.isException)
                {
                    ServiceResponse.ResponseWithoutValue(1, "Success!");
                }
                else
                {
                    ServiceResponse.ResponseWithoutValue(0, pobj.exceptionMessage);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.ResponseWithoutValue(0, exception.Message);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetStudentDetails(string studentId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.studentId = studentId;
                BAL_Student.GetStudentDetails(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetIntakeDetails(string memberId,string userId,string dietDate)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.memberId = Convert.ToInt32(memberId);
                pobj.userId = Convert.ToInt32(userId);
                pobj.dietDate = Convert.ToDateTime(dietDate);
                BAL_Student.GetIntakeDetails(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    List<StudentIntakeDetails> IntakeDetails = new List<StudentIntakeDetails>();
                    for (int i = 0; i < pobj.DS.Tables[0].Rows.Count; i++)
                    {
                        List<FoodUnits> FoodUnits = new List<FoodUnits>();
                        for (int j = 0; j < pobj.DS.Tables[1].Rows.Count; j++)
                        {
                            if(pobj.DS.Tables[0].Rows[i]["foodID"].ToString() == pobj.DS.Tables[1].Rows[j]["foodID"].ToString())
                            {
                                FoodUnits.Add(new FoodUnits
                                {
                                    id = pobj.DS.Tables[1].Rows[j]["id"].ToString(),
                                   unitName= pobj.DS.Tables[1].Rows[j]["unitName"].ToString()
                                });
                            }
                        }
                        IntakeDetails.Add(new StudentIntakeDetails
                        {
                            foodId = Convert.ToInt32(pobj.DS.Tables[0].Rows[i]["foodID"].ToString()),
                            foodName= pobj.DS.Tables[0].Rows[i]["foodName"].ToString(),
                            foodQuantity = Convert.ToDecimal(pobj.DS.Tables[0].Rows[i]["foodQuantity"].ToString()),
                            tblUnit= FoodUnits
                        });
                    }
                    ServiceResponse.GeneralResponseObject(1, "Success!", IntakeDetails);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodByPrefixText(string prefixText)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.prefixText = prefixText;
                BAL_Student.GetFoodByPrefixText(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetFoodUnitByFoodId(string foodId)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.foodId = Convert.ToInt32(foodId);
                BAL_Student.GetFoodUnitByFoodId(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetNutritionResult(string intakeDetails)
        {
            DataTable returnTable = new DataTable();
            try
            {
                PAL_Student pobj = new PAL_Student();
                pobj.intakeDetails = JsonConvert.DeserializeObject<DataTable>(intakeDetails);
                BAL_Student.GetNutritionResult(pobj);
                if (!pobj.isException)
                {
                    returnTable = pobj.DS.Tables[0];
                    ServiceResponse.GeneralResponse(1, "Success!", returnTable);
                }
                else
                {
                    ServiceResponse.GeneralResponse(0, pobj.exceptionMessage, returnTable);
                }
            }
            catch (Exception exception)
            {
                ServiceResponse.GeneralResponse(0, exception.Message, returnTable);
            }
        }
    }
}
