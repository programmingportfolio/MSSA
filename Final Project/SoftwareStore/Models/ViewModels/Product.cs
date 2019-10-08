using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareStore.Models.ViewModels
{
    public class Product : Abstract.Product
    {
        public Product(int managerId, string productName, string productCategory,
            string shortDescription, decimal price, int quantity, string pictureUrl1,
            string longDescription = null, string videoUrl = null, string pictureUrl2 = null,
            string pictureUrl3 = null, string pictureUrl4 = null, string pictureUrl5 = null,
            string pictureUrl6 = null, string pictureUrl7 = null, string pictureUrl8 = null)

            : base(managerId, productName, productCategory, shortDescription, price, quantity, pictureUrl1, longDescription, videoUrl, pictureUrl2, pictureUrl3, pictureUrl4, pictureUrl5, pictureUrl6, pictureUrl7, pictureUrl8)
        {

        }
    }
}
