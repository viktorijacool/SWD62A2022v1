using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoriesFileRepository : ICategoriesRepository
    {
        //FileInfo is a built-in class representing a file 

        private FileInfo fi;
        public CategoriesFileRepository(FileInfo _fi)
        {
            fi  = _fi;
        }
        public IQueryable<Category> GetCategories()
        {
            //sr.Peek() returns next index of what's to be read next
            //meaning that if it returns -1: there's nothing more to read

            List<Category> categories = new List<Category>();

            string line = "";

            using (StreamReader sr = fi.OpenText())
            {
                while(sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    categories.Add(new Category()
                    {
                        Id = Convert.ToInt32(line.Split(';')[0]),
                        Title = (line.Split(';')[1]).ToString()
                    });
                        
                }
            }

            return categories.AsQueryable();
        }
    }
}
