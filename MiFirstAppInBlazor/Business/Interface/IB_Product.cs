using Entities;
using System.Collections.Generic;

namespace Business
{
    public interface IB_Product
    {
        void CreateProduct(ProductEntity productEntity);
        IList<ProductEntity> ListProduct();
        ProductEntity ProductById(string id);
        void UpdateProduct(ProductEntity product);
    }
}
