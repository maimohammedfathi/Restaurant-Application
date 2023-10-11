using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VersionOfProject.Entity;

namespace VersionOfProject.PL
{
    public class EmployePL
    {
        WFContext Context;
        public EmployePL()
        {
            Context = new WFContext();
        }
        public List<Employe> GetAll()
        {
            return Context.Employies.ToList();
        }
        public bool Add(Employe data)
        {
            if (data == null)
                throw new Exception("Data must Be not Null");

            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.Salary < 4000 )
                throw new Exception("Salary must be postive and greater than or equal 4000 ");
            if (data.JobDescription == null || data.JobDescription.Length > 50)
                throw new Exception("JobDescription must be  lessthan   50 char ");
            if (data.Address == null || data.Address.Length > 70)
                throw new Exception("Adress must be  lessthan   70 char ");
            bool isPhoneNumberValid = Regex.IsMatch(data.PhoneNumber, @"^\d{11}$");
            if (isPhoneNumberValid == false)
            {
                throw new Exception(" Invalid Phone Number  ");
            }

            try
            {
                var falag = Context.Employies.SingleOrDefault(e => e.Name == data.Name);
                if (falag == null)
                {
                    Context.Employies.Add(data);
                    if (Context.SaveChanges() > 0)
                    {
                        Context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        return true;
                    }
                    
                }
                else
                {
                    throw new Exception("employee is exist");

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        public bool Edit(Employe data)
        {
            if (data == null)
                throw new Exception("Data must Be not Null");
            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.Salary < 4000)
                throw new Exception("Salary must be postive and greater than or equal 4000 ");
            if (data.JobDescription == null || data.JobDescription.Length > 50)
                throw new Exception("JobDescription must be  lessthan   50 char ");
            if (data.Address == null || data.Address.Length > 70)
                throw new Exception("Adress must be  lessthan   70 char ");
            bool isPhoneNumberValid = Regex.IsMatch(data.PhoneNumber, @"^\d{11}$");
            if (isPhoneNumberValid == false)
            {
                throw new Exception(" Invalid Phone Number  ");
            }

            try
            {
                var falag = Context.Employies.SingleOrDefault(E => E.Id == data.Id);
                if (falag == null)
                {
                    throw new Exception("Invaild Id");
                }
                falag.Name = data.Name;
                falag.Salary = data.Salary;
                falag.Address = data.Address;
                falag.JobDescription = data.JobDescription;
                falag.PhoneNumber = data.PhoneNumber;
                Context.Entry(falag).State= Microsoft.EntityFrameworkCore.EntityState.Modified ;
                if(Context.SaveChanges() > 0 )
                {
                    Context.Entry(falag).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return false;
        }

        public bool Delete(Employe data)
        {
            try
            {
                Context.Employies.Remove(data);
                return Context.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
