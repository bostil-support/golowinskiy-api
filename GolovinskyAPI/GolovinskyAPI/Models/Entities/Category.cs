using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string t_image { get; set; }
        //Id предыдущей категории
        public string Parent_Category_Id { get; set; }
        public string IsShow { get; set; }
        public string Picture { get; set; }
        public string Txt { get; set; }
        //id портала(магазигна)
        public string Cust_ID_Main { get; set; }
        public int Level { get; set; }
    }
}
