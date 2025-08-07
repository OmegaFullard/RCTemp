using RCTemp.xsRCTempTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using static RCTemp.xsRCTemp;


namespace RCTemp.Classes
{
    public class clsRCTemp
    {
        public bool EmpID { get; private set; }

        public DataTable GetEmployeeList()
        {
            try
            {

                EmployeesTableAdapter adpEmpList = new EmployeesTableAdapter();
                EmployeesDataTable tblEmpList = adpEmpList.GetData();

                return tblEmpList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetEmployees(int EmpID)
        {
            try
            {
                EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
                EmployeesDataTable tblEmployee = adpEmployee.GetDataByEmpID(EmpID);
                return tblEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public string AddEmployee(clsEmployee thisEmployee)
        {
            EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
            try
            {
                adpEmployee.InsertQuery(thisEmployee.FN, thisEmployee.LN, thisEmployee.Phone, thisEmployee.Email, thisEmployee.Available);
                return "Success";
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void UpdateEmployee(clsEmployee thisEmployee)
        {
            EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
            try
            {
                adpEmployee.UpdateQuery(thisEmployee.EmpID, thisEmployee.FN, thisEmployee.LN, thisEmployee.Phone, thisEmployee.Email, thisEmployee.Available, thisEmployee.Original_EmpID);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteEmployee (clsEmployee thisEmployee)
        {
            EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();

            try
            {

                if (true)
                {
                    var withBlock = thisEmployee;
                    adpEmployee.DeleteQuery(withBlock.EmpID);
                }
            }
            catch (Exception)
            {
                throw;

            }

        }
        public DataTable GetEmpID()
        {
            try
            {
                EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
                EmployeesDataTable tblEmployee = adpEmployee.GetData();
                return tblEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetEmployeeDetailByEmpID(ref int EmpID)
        {
            try
            {
                EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
                EmployeesDataTable tblEmployee = adpEmployee.GetDataByEmpID(EmpID);
                return tblEmployee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetEmployeeByIDandLN(ref int EmpID, ref string LN)
        {
            try
            {
                EmployeesTableAdapter adpEmployee = new EmployeesTableAdapter();
                EmployeesDataTable tblEmployee = adpEmployee.GetDataByEmpIDandLN(EmpID, LN);

                return tblEmployee;
            }


            catch (Exception)
            {
                throw;
            }
        }

public DataTable GetEmpList()
{
    try
    {
        EmpIDTableAdapter adpEmp = new EmpIDTableAdapter();
        EmpIDDataTable tblEmp = adpEmp.GetData();

        return tblEmp;
    }
    catch (Exception)
    {
        throw;
    }
}

public DataTable GetLNList()
{
    try
    {
        LNTableAdapter adpLN = new LNTableAdapter();
        LNDataTable tblLN = adpLN.GetData();

        return tblLN;
    }
    catch (Exception)
    {
        throw;
    }
}
    }
}