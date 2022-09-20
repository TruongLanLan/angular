using ApplicationLayer.Interfaces;
using DataAccessLayer.UnitOfworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Implementations
{
    public class CategoryApplicationLayer : ICategoryApplicationLayer
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryApplicationLayer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddCategory(Category category)
        {
           
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Category FindCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
