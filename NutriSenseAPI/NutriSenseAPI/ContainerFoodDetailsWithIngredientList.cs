using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriSenseAPI
{
    public class DiningTableSessionDetailResponse
    {
        public string sessionID { get; set; }
        public List<ContainerDetails> containerDetails { get; set; }

    }
    public class ContainerDetails
    {
        public string foodContainerName { get; set; }
        public int foodID { get; set; }
        public string foodName { get; set; }
        public List<IngredientList> ingredientList { get; set; }

    }
    public class IngredientList
    {
        public int ingredientID { get; set; }
        public string ingredientName { get; set; }
    }

}