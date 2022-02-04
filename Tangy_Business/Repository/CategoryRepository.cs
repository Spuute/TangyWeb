using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public CategoryDto Create(CategoryDto objDTO)
        {
            Category category = new Category()
            {
                Id = objDTO.Id,
                Name = objDTO.Name,
                CreatedDate = DateTime.Now
            };

            _db.Categories.Add(category);
            _db.SaveChanges();

            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryDto Update(CategoryDto objDTO)
        {
            throw new NotImplementedException();
        }
    }
}
