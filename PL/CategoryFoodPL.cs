using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;

namespace VersionOfProject.PL
{
    public class CategoryFoodPL
    {
        WFContext Context;
        public CategoryFoodPL()
        {
            Context = new WFContext();
        }
        // 
        public List<FoodCategory> GetAll()
        {
            return Context.FoodCategories.OrderBy(F=>F.Id).ToList();
            
        }
        public bool Add(FoodCategory data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == "" || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
           
            try
            {
                var falag = Context.FoodCategories.SingleOrDefault(d => d.Name == data.Name);
                if (falag == null)
                {
                    Context.FoodCategories.Add(data);
                    if (Context.SaveChanges() > 0)
                    {
                        Context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        return true;
                    }
                }
                else
                {
                    throw new Exception($"{data.Name} oready Exists");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }

        public bool Edit(FoodCategory data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == "" || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");

            try
            {
                var objFromDB = Context.FoodCategories.SingleOrDefault(d => d.Id == data.Id);
                if (objFromDB != null)
                {
                   if ( Context.FoodCategories.SingleOrDefault(d => d.Name == data.Name) == null )
                    {
                        objFromDB.Name = data.Name;
                        Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        if (Context.SaveChanges() > 0)
                        {
                            Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                            return true;
                        }
                        else
                        {
                            throw new Exception($"{data.Name} oready Exists");
                        }
                    }   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public bool Delete(FoodCategory data)
        {
            if (data != null)
            {
                var count = Context.Foods.Where(f => f.CategoryID == data.Id).Count();
                if(count > 0 )
                {
                     throw new Exception($" Category  {data.Name} can not deleted becase assign to {count}  Product ");
                }

                try
                {
                    Context.FoodCategories.Remove(data);
                    return Context.SaveChanges() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                
            }
            return false;
        }

        public List<Food> GetFoodsByCategoryId(int categoryId)
        {
            return Context.Foods.Where(d => d.CategoryID == categoryId).ToList();
        }

    }
}
