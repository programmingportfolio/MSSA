
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareStore.Models.Abstract
{
    public abstract class Product
    {
        //public <IdentityUser> UserName { get; set; }
        internal int managerId
        {
            get
            {
                return managerId;
            }
            set
            {
                if (managerId != 0)
                {
                    OnChange();
                    this.managerId = value;
                }
                else
                {
                    this.managerId = value;
                }
            }
        }

        public static double productCount { get; set; }
        internal string productName { get; set; }
        internal string productCategory { get; set; }
        internal static string shortDescription { get; set; }
        internal static string longDescription { get; set; }
        internal decimal price { get; set; }
        internal int quantity { get; set; }
        internal string easyUrl { get; set; }
        internal string videoUrl { get; set; }
        internal string pictureUrl1 { get; set; }
        internal string pictureUrl2 { get; set; }
        internal string pictureUrl3 { get; set; }
        internal string pictureUrl4 { get; set; }
        internal string pictureUrl5 { get; set; }
        internal string pictureUrl6 { get; set; }
        internal string pictureUrl7 { get; set; }
        internal string pictureUrl8 { get; set; }

        //internal List<string> pictureUrls = new List<string>();
        //internal static int pictureCount { get; set; }
        //internal bool hasPictures { get; set; }
        internal bool hasVideo
        {
            get
            {
                return this.hasVideo;
            }
            set
            {
                if (videoUrl != null)
                {
                    this.hasVideo = true;
                }
                else
                {
                    this.hasVideo = false;
                }
            }
        }
        //internal int productCount { get; set; }




        internal Product(int managerId, string productName, string productCategory,
            string shortDescription, decimal price, int quantity, string pictureUrl1,
            string longDescription = null, string videoUrl = null, string pictureUrl2 = null,
            string pictureUrl3 = null, string pictureUrl4 = null, string pictureUrl5 = null,
            string pictureUrl6 = null, string pictureUrl7 = null, string pictureUrl8 = null)
        {

            //(List<string> pics, int pictureCount) = CheckOrTruncatePictureLength(HasVideo(hasVideo, pictureUrls));
            this.pictureUrl1 = pictureUrl1;
            this.managerId = managerId;
            this.productName = productName;
            this.productCategory = productCategory;
            this.price = price;
            this.quantity = quantity;
            this.videoUrl = videoUrl;
            this.pictureUrl2 = pictureUrl2;
            this.pictureUrl3 = pictureUrl3;
            this.pictureUrl4 = pictureUrl4;
            this.pictureUrl5 = pictureUrl5;
            this.pictureUrl6 = pictureUrl6;
            this.pictureUrl7 = pictureUrl7;
            this.pictureUrl8 = pictureUrl8;
            this.easyUrl = CreateEasyURL(productCategory, productName);

        }
        internal static string CreateEasyURL(string productCategory, string productName)
        {
            string easyUrl = $"{productCategory}/{productName}/";
            return easyUrl;
        }

        internal static void OnChange()
        {
            Product.productCount++;
        }

        public override string ToString()
        {
            return $"Item Addition = {Product.productCount}, {productCategory} with Attributes: Name = {productName}, Price = {price}, Quantity = {quantity}, Manager ID = {managerId}," +
                $" Contains Video = {hasVideo}, EasyURL = {easyUrl}, Picture 1: {pictureUrl1}, Video URL: {videoUrl}";
        }
    }
}