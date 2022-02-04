using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public CategoryDto Create(CategoryDto objDTO);
        public int Delete(int id);
        public CategoryDto Get(int id);
        public IEnumerable<CategoryDto> GetAll();
        public CategoryDto Update(CategoryDto objDTO);
    }
}