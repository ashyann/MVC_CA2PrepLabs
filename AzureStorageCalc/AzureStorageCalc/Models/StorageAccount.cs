using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureStorageCalc.Models
{
    public class StorageAccount
    {
        public enum Redundancy
        {
            [Display(Name="Geographically Redundant")]GeographicallyRedundant,
            [Display(Name = "Locally Redundant")]LocallyRedundant
        }

        [DisplayName("Redundancy")]
        public Redundancy RedundancySelect { get; set; }


        [DisplayName("Storage (In GB)")]
        [Required(ErrorMessage = "Required field!")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You can only select at least 1GB")]
        public int StorageSize { get; set; }

        public double [] PricesBefore
        {
            get
            {
                return new double [] {0.125,0.093};
            }
        }

        public double [] PricesAfter
        {
            get
            {
                 return new double [] {0.11,0.083};
            }
        }

        public double Cost
        {
            get
            {
                double beforetb = 0;
                double aftertb = 0;
                double monthCost;
                for (int i = 0; i < 2; i++)
                {
                    if (RedundancySelect.Equals((Redundancy)i))
                    {
                        beforetb = PricesBefore[i];
                        aftertb = PricesAfter[i];
                        break;
                    }
                }

                if (StorageSize <= 1000)
                {
                    monthCost = StorageSize * beforetb;
                }
                else
                {
                    int leftover = StorageSize - 1000;
                    monthCost = (leftover * aftertb) + (1000 * beforetb);
                }

                return monthCost;
            }
        }
    }
}