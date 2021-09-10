using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DLLAuthentication;
namespace NutriSenseAPI
{
    public class Authentication
    {
        public static bool IsValidUserAuthentication(int userLoginID)
        {
            if (HttpContext.Current.Request.Headers.GetValues("token") == null)
            {
                ServiceResponse.AuthenticationErrorResponse();
                return false;
            }
            else
            {
                PAL_Authentication pobj = new PAL_Authentication();
                pobj.userLoginID = userLoginID;
                pobj.userToken = HttpContext.Current.Request.Headers.GetValues("token").First();
                BAL_Authentication.IsValidUserAuthentication(pobj);
                if (!pobj.isException)
                {
                    return true;
                }
                else
                {
                    ServiceResponse.AuthenticationErrorResponse();
                    return false;
                }
            }
        }

        public static bool IsValidUserAuthentication(int userLoginID, int userID)
        {
            if (HttpContext.Current.Request.Headers.GetValues("token") == null)
            {
                ServiceResponse.AuthenticationErrorResponse();
                return false;
            }
            else
            {
                PAL_Authentication pobj = new PAL_Authentication();
                pobj.userLoginID = userLoginID;
                pobj.userID = userID;
                pobj.userToken = HttpContext.Current.Request.Headers.GetValues("token").First();
                BAL_Authentication.IsValidUserAuthenticationWithUserID(pobj);
                if (!pobj.isException)
                {
                    return true;
                }
                else
                {
                    ServiceResponse.AuthenticationErrorResponse();
                    return false;
                }
            }
        }

        public static bool IsValidOPDToken()
        {
            if (HttpContext.Current.Request.Headers.GetValues("token") == null)
            {
                ServiceResponse.AuthenticationErrorResponse();
                return false;
            }
            else
            {
                PAL_Authentication pobj = new PAL_Authentication();
                pobj.userToken = HttpContext.Current.Request.Headers.GetValues("token").First();
                BAL_Authentication.IsValidOPDToken(pobj);
                if (!pobj.isException)
                {
                    return true;
                }
                else
                {
                    ServiceResponse.AuthenticationErrorResponse();
                    return false;
                }
            }
        }

        public static bool IsValidSmartTableToken()
        {
            if (HttpContext.Current.Request.Headers.GetValues("token") == null)
            {
                ServiceResponse.AuthenticationErrorResponse();
                return false;
            }
            else
            {
                string token = HttpContext.Current.Request.Headers.GetValues("token").First();
                if (token == "ABHGDCFR4568954327BJHHC564HY565YKOLPQ")
                {
                    return true;
                }
                else
                {
                    ServiceResponse.AuthenticationErrorResponse();
                    return false;
                }
            }
        }
    }
}