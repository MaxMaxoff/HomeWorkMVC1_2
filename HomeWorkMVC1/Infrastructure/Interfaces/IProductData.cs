using HomeWorkMVC1.Domain.Entities;
using HomeWorkMVC1.Domain.Filters;
using System.Collections.Generic;

namespace HomeWorkMVC1.Entities.Base.Interfaces
{
    /// <summary>
    /// Public Interface
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// Section list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Section> GetSections();

        /// <summary>
        /// Brand list
        /// </summary>
        /// <returns></returns>
        IEnumerable<Brand> GetBrands();

        /// <summary>
        /// Product list
        /// </summary>
        /// <param name="filter">Product filter</param>
        /// <returns></returns>
        IEnumerable<Product> GetProducts(ProductFilter filter);

        /// <summary>
        /// Product by ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Сущность Product, если нашёл, иначе null</returns>
        Product GetProductById(int id);
    }
}
