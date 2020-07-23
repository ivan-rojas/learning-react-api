using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public interface IValidationService
    {
        /// <summary>
        /// Verifies if the product name is no longer than 150 characters 
        /// and it's cost is lower or equal than the price. If any of this happens, 
        /// it will throw an exception specifying the error.
        /// </summary>
        /// <param name="product"></param>
        void ValidateProduct(Product product);
    }
}
