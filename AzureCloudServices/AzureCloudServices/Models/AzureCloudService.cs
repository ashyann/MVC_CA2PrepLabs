using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AzureCloudServices.Models
{
    public class AzureCloudService
    {
        public enum Instance
        {
            [Display(Name = "Very Small")] verysmall,
            Small,
            Medium,
            Large,
            [Display(Name = "Very Large")] verylarge,
            A6,
            A7      
        }

        [DisplayName("Instance Size")]
        public Instance SelectInstance { get; set; }

        public static double [] Prices
        {
            get
            {
                return new double [] {0.02,0.08,0.16,0.32,0.64,0.90,1.80};
            }
        }

        [Required(ErrorMessage = "Required field!")]
        [Range(2, Int32.MaxValue, ErrorMessage = "At least 2 instances required")]
        [DisplayName("Number of Instances")]
        public int NumInstances { get; set; }

        public double Cost
        {
            get
            {
               double hourlyPrice = 0;
               for (int i = 0; i < 7; i++)
               {
                   if(SelectInstance.Equals((Instance)i))
                   {
                       hourlyPrice = Prices[i];
                       break;
                   }
               }
               
                double dailyPrice = hourlyPrice * 24;
                double yearlyPrice;

                       if(DateTime.IsLeapYear(DateTime.Now.Year))
                       {
                           yearlyPrice = dailyPrice * 366;
                       }
                       else
                       {
                           yearlyPrice = dailyPrice * 365;
                       }
                       return yearlyPrice * NumInstances;
                   }
               }  
           }
        }