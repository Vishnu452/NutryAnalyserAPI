using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NutriSenseAPI
{
    public class SmartTableResponse
    {
        public int sessionID { get; set; }
        public List<FoodContainerDetail> foodContainerDetail { get; set; }

    }
    public class FoodContainerDetail
    {
        public string containerName { get; set; }
        public int foodID { get; set; }
        public string foodName { get; set; }
        public List<CombinationList> combinationList { get; set; }
    }
    public class CombinationList
    {
        public int combinationID { get; set; }
        public string combinationName { get; set; }
    }

}