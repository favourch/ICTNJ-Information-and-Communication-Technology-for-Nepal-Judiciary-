using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

using PCS.SECURITY.ATT;
using PCS.SECURITY.DLL;
using PCS.FRAMEWORK;
namespace PCS.SECURITY.BLL
{
    public class BLLUsers
    {

        public static ObjectValidation Validate(ATTUsers objUsers)
        {
            ObjectValidation OV = new ObjectValidation();

            if (objUsers.Username=="")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Username cannot be Blank.";
                return OV;
            }

            if (objUsers.Password=="")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Password cannot be Blank";
                return OV;
            }

            if (objUsers.Password != objUsers.RePassword)
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Password Mismatched";
                return OV;
            }

            if (objUsers.ValidUpto.ToShortDateString() == "01/01/0001")
            {
                OV.IsValid = false;
                OV.ErrorMessage = "Valid Upto Can't Be Left Blank";
                return OV;
            }

            

            //if (ValidateDate(objUsers.ValidUpto)==false  )
            //{
            //    OV.IsValid = false;
            //    OV.ErrorMessage = "Invalid Date Format. Date should be in DD/MM/YYYY Format";
            //    return OV;
            //}
            

            return OV;
        }

        public List<ATTUsers> GetUsers(string   Username)
        {
            return (GetUserList (PCS.SECURITY.DLL.DLLUsers.GetUsersTable (Username )));
        }


        public static List<ATTUsers> GetUserList(DataTable tbl)
        {
            List<ATTUsers> UserLST = new List<ATTUsers>();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    ATTUsers UserObj = new ATTUsers(
                                                        (string)row["USER_NAME"].ToString(),
                                                        (string)row["PASSWORD"].ToString(),
                                                        "",
                                                        (string)row["CREATEDBY"].ToString(),
                                                        (DateTime)row["CREATED_DATE"],
                                                        (DateTime)row["VALID_UPTO"],
                                                        (string)row["ACTIVE"].ToString(),
                                                        "E",
                                                        (row["P_ID"]== System.DBNull.Value) ? 0 : double.Parse(row["P_ID"].ToString())
                                                    );

                                                   

                    UserObj.LSTUserRoles = new BLLUserRoles().GetUserRoles((string)row["USER_NAME"].ToString());
                    UserLST.Add(UserObj);
                }
                return UserLST;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public  static  bool  ValidateDate(string  validUpto)
        {
            string    Year;
            string   Month;
            string   Day;
            //string Date = validUpto.ToShortDateString ();
            string[] DateSplit= validUpto.Split('/');
            Year = DateSplit[2];
            Month = DateSplit[1];
            Day = DateSplit[0];

            if ((Year.Length!=4) || (Month.Length!=2) || (Day.Length!=2) || (int.Parse (Month)<1 || (int.Parse(Month)>12)) || (int.Parse(Day)<1 || int.Parse(Day)>32))
            {
                return false;
            }
            else
            {
                return true;
            }

            
        }

        //    for (var i = 0; i < ControlCollection.length; i++)
        //    {
        //        if (ControlCollection[i].id.toUpperCase().indexOf("_RDT") != -1 || ControlCollection[i].id.toUpperCase().indexOf("_DT") != -1)
        //        {
        //            if (ControlCollection[i].id.toUpperCase().indexOf("_DT") != -1 && ControlCollection[i].value.trim() == "")
        //            {
        //                ErrorMsg = ErrorMsg + "";
        //            }
        //            else
        //            {
        //                DateElement = ControlCollection[i].value.split("/");

        //                if (DateElement.length == 3)
        //                {
        //                    Day = DateElement[0];
        //                    Month = DateElement[1];
        //                    Year = DateElement[2];
        //                    //alert(isNaN(Year));
        //                    if ((Year.length != 4) || (Month.length != 2) || (Day.length != 2) || (Month < 1 || Month > 12) || (Day < 1 || Day > 32) || (isNaN(Year) == true) || (isNaN(Month) == true) || (isNaN(Day) == true))
        //                    {
        //                        ErrorMsg = ErrorMsg + GetControlName(ControlCollection[i].id) + ":  -  INVALID DATE. DATE FORMAT DD/MM/YYYY.\n";
        //                        ErrorControl.push(ControlCollection[i]);
        //                    }
        //                }
        //                else
        //                {
        //                    ErrorMsg = ErrorMsg + GetControlName(ControlCollection[i].id) + ":  -  DATE MUST BE YYYY/MM/DD FORMAT.\n";
        //                    ErrorControl.push(ControlCollection[i]);
        //                }
        //            }
        //        }
        //    }

        //    if (ErrorMsg != "")
        //    {
        //        alert("DATE ERROR::\n\n" + ErrorMsg);
        //        ErrorControl[0].focus();
        //        ErrorControl[0].select();
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}



        //public List<ATTUsers> GetUserApplRoles(string Username)
        //{
        //    return (GetUserList(PCS.SECURITY.DLL.DLLUsers.GetUsersTable(Username)));
        //}


        //public static List<ATTUsers> GetUserApplRolesList(DataTable tbl)
        //{
        //    List<ATTUsers> UserLST = new List<ATTUsers>();
        //    try
        //    {
        //        foreach (DataRow row in tbl.Rows)
        //        {
        //            ATTUsers UserObj = new ATTUsers(
        //                                                (string)row["USER_NAME"].ToString(),
        //                                                (string)row["PASSWORD"].ToString(),
        //                                                "",
        //                                                (string)row["CREATEDBY"].ToString(),
        //                                                (DateTime)row["CREATED_DATE"],
        //                                                (DateTime)row["VALID_UPTO"],
        //                                                (string)row["ACTIVE"].ToString(),
        //                                                "E"

        //                                           );

        //            UserObj.LSTUserRoles = new BLLUserRoles().GetUserRoles((string)row["USER_NAME"].ToString());
        //            UserLST.Add(UserObj);
        //        }
        //        return UserLST;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




        
    }
}
