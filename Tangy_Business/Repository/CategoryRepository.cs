using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public CategoryDto Create(CategoryDto objDTO)
        {
            var obj = _mapper.Map<CategoryDto, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
            var addedObject = _db.Categories.Add(obj);
            _db.SaveChanges();

            return _mapper.Map<Category, CategoryDto>(addedObject.Entity);
        }

        public int Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if(category != null) {
                _db.Categories.Remove(category);
                return _db.SaveChanges();
            }

            return 0;

        }

        public CategoryDto Get(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if(category != null) {
                return _mapper.Map<Category, CategoryDto>(category);
            }

            //TODO: Should this really return a new CategoryDto? Should it not return null?
            return new CategoryDto();
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(_db.Categories);
        }

        public CategoryDto Update(CategoryDto objDTO)
        {
            var categoryFromDb = _db.Categories.FirstOrDefault(x => x.Id == objDTO.Id);

            if(categoryFromDb != null) {
                categoryFromDb.Name = objDTO.Name;
                _db.Categories.Update(categoryFromDb);
                _db.SaveChanges();
                return _mapper.Map<Category, CategoryDto>(categoryFromDb);
            }
            return (objDTO);
        }
    }
}
