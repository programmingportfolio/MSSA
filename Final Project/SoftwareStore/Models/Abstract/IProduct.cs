using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareStore.Models.Abstract
{
    interface IProduct
    {
        string UserName { get; set; }

        string ProductName { get; set; }
        string ProductCategory { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
        string EasyUrl { get; set; }
        string VideoUrl { get; set; }
        string PictureUrl1 { get; set; }
        string PictureUrl2 { get; set; }
        string PictureUrl3 { get; set; }
        string PictureUrl4 { get; set; }
        string PictureUrl5 { get; set; }
        string PictureUrl6 { get; set; }
        string PictureUrl7 { get; set; }
        string PictureUrl8 { get; set; }
    }
}
        /*
        // List<string> pictureUrls = new List<string>();
        // static int pictureCount { get; set; }
        // bool hasPictures { get; set; }
        bool hasVideo { get; set; }
        // int productCount { get; set; }





        string CreateEasyURL(string productCategory, string productName);

        void OnChange();

        string ToString();
        */
