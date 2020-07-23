using LearningReactAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningReactAPI.Services
{
    public class ValidationService : IValidationService
    {
        public void ValidateProduct(Product product)
        {
            if (!this.VerifyCostAndPrice(product))
                throw new ApplicationException("The cost cannot be higher than the price.");
                
            if (!this.VerifyNameLength(product.Name))
                throw new ApplicationException("The name cannot have more than 150 characters.");
        }

        #region Private methods
        /// <summary>
        /// Verifies if the cost is lower or equal than the price of the product.
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="price"></param>
        /// <returns>If the cost is lower or equal, returns true. Else, false.</returns>
        private bool VerifyCostAndPrice(Product product)
        {
            return product.Cost <= product.Price;
        }

        /// <summary>
        /// Verifies if the name length is lower than 150 characters.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>If the name it's valid, returns true.</returns>
        private bool VerifyNameLength(string name)
        {
            return name.Length < 150;
        }
        #endregion
    }
}
