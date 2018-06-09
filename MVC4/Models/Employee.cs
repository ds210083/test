using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC4.EntityModel;

namespace MVC4.Models
{
    public class Employee : Emp
    {
        #region DataMember

        public bool Status { get; set; }
        public string mesage { get; set; }

        #endregion

        #region Methods

        public List<Employee> GetAllList()
        {
            List<Employee> EmpList = new List<Employee>();
            try
            {
                tempdbEntities a = new tempdbEntities();
                EmpList = a.Emps.ToList().ConvertAll(o => new Employee
                {
                    Id = o.Id,
                    Name = o.Name,
                    City = o.City
                });
            }
            catch (Exception)
            {}            
            return EmpList;
        }
       
        public Employee AddUpdate(Employee objEmp)
        {
            Employee Result = new Employee();
            if (objEmp.Id != 0)
            {
                try
                {
                    tempdbEntities objdb = new tempdbEntities();
                    var empData = objdb.Emps.Where(x => x.Id == objEmp.Id).FirstOrDefault();
                    if (empData != null)
                    {
                        empData.Name = objEmp.Name;
                        empData.City = objEmp.City;
                        objdb.SaveChanges();
                        objdb.Dispose();
                        Result.Status = true;
                        Result.mesage = "success";
                    }
                    else
                    {
                        Result.Status = false;
                        Result.mesage = "no record found";
                    }
                }
                catch (Exception)
                {
                    Result.Status = true;
                    Result.mesage = "success";
                }
            }
            else
            {
                try
                {
                    tempdbEntities objdb = new tempdbEntities();
                    Emp objemployee = new Emp();
                    objemployee.Name = objEmp.Name;
                    objemployee.City = objEmp.City;
                    objdb.Emps.Add(objemployee);
                    objdb.SaveChanges();
                    objdb.Dispose();
                    Result.Status = true;
                    Result.mesage = "success";
                }
                catch (Exception)
                {
                    Result.Status = false;
                    Result.mesage = "Falied";
                }
            }
            return Result;
        }
        public Employee Delete(int id)
        {
            Employee Result = new Employee();
            try
            {
                if (id > 0)
                {
                    tempdbEntities objdb = new tempdbEntities();
                    var empdata = objdb.Emps.Where(x => x.Id == id).FirstOrDefault();
                    if (empdata != null)
                    {
                        objdb.Emps.Remove(empdata);
                        objdb.SaveChanges();
                        Result.Status = true;
                        Result.mesage = "Done!";
                    }
                    else
                    {
                        Result.Status = false;
                        Result.mesage = "Record Not Found!";
                    }
                }
                else
                {
                    Result.Status = false;
                    Result.mesage = "Invalid Id!";
                }
               
            }              
            catch (Exception)
            {
                Result.Status = false;
                Result.mesage = "Exception";
            }
             return Result;
        }
        public Employee GetList(int id)
        {
            Employee objEmployee = new Employee();
            try
            {
                tempdbEntities objdb = new tempdbEntities();
                var empData = objdb.Emps.Where(x => x.Id == id).FirstOrDefault();
                if (empData != null)
                {
                    objEmployee.City = empData.City;
                    objEmployee.Name = empData.Name;
                    objEmployee.mesage = "Done";
                    objEmployee.Status = true;
                }
                else
                {
                    objEmployee.mesage = "Bad Request";
                    objEmployee.Status = false;
                }
            }
            catch (Exception ex)
            {
                objEmployee.mesage = "Exception!";
                objEmployee.Status = false;
            }
            return objEmployee;
        }

        #endregion



    }
}