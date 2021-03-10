using EcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApp.Utility
{
    public static class SD
    {
        public const string DefaultFoodImage = "default_food.png";

        public const string ManagerUser = "Manager";
        public const string StockUser = "StockUser";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";

        public const string ssShoppingCartCount = "ssCartCount";
        public const string ssCouponCode= "ssCouponCode";

        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Processing";
        public const string StatusReady = "Ready for Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";

        public static string ConvertToRawHtml(string source) 
        {
            char[] array = new char[source.Length];

            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;

                }
                if (let == '>')
                {
                    inside = false;
                    continue;

                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;

                }

            }
            return new string(array, 0, arrayIndex);
        
        }

        public static double DiscountedPrice(Coupon couponFromDB, double OriginaOrderTotal) 
        {
            if (couponFromDB == null)
            {
                return OriginaOrderTotal;
            }
            else
            {
                if (couponFromDB.MinimumAmount > OriginaOrderTotal)
                {
                    return OriginaOrderTotal;

                }
                else
                {
                    // everything is valid

                    if (Convert.ToInt32(couponFromDB.CouponType) == (int)Coupon.ECouponType.Dollar)
                    {
                        //$10 off $100
                        return Math.Round(OriginaOrderTotal - couponFromDB.Discount, 2);
                    }
                    if (Convert.ToInt32(couponFromDB.CouponType) == (int)Coupon.ECouponType.Percent)
                    {
                        //10% off $100
                        return Math.Round(OriginaOrderTotal - (OriginaOrderTotal * couponFromDB.Discount/100), 2);
                    }
                }
            }
            return OriginaOrderTotal;
        }
    }
}
