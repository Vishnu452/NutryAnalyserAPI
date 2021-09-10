using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriSenseAPI
{
    public class StudentIntakeDetails
    {
        public Int32 foodId { get; set; }
        public string foodName { get; set; }
        public decimal foodQuantity { get; set; }
        public List<FoodUnits> tblUnit { get; set; }
    }
    public class FoodUnits
    {
        public string id { get; set; }
        public string unitName { get; set; }
    }
}