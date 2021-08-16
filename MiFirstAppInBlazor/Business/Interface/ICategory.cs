using Entities;
using System.Collections.Generic;

namespace Business
{
    public interface IB_Category
    {
        IList<CategoryEntity> CategoryList();
    }
}
