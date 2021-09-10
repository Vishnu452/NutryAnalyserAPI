using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriSenseAPI
{
    public class RecipeMasterData
    {
        public List<tblIngredient> tblIngredient { get; set; }
        public List<CookedFoodUnits> cookedFoodUnit { get; set; }
        public List<CookedFoodDetails> CookedFoodDetails { get; set; }
    }

    public class tblIngredient
    {
        public Int32 foodId { get; set; }
        public string foodName { get; set; }
        public decimal ingredientQuantity { get; set; }
        public Int32 unitID { get; set; }
        public string unitName { get; set; }
        public List<Units> tblUnit { get; set; }
    }
    public class Units
    {
        public string id { get; set; }
        public string unitName { get; set; }
    }
    
    public class CookedFoodDetails
    {
        public Int32 foodID { get; set; }
        public decimal foodQuantity { get; set; }
        public Int32 unitID { get; set; }
        public string unitName { get; set; }
    }

    public class CookedFoodUnits
    {
        public string unitID { get; set; }
        public string unitName { get; set; }
    }
}