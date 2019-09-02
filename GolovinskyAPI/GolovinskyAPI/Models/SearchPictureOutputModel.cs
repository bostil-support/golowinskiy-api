using System.Collections.Generic;


namespace GolovinskyAPI.Models
{
    public class SearchPictureOutputModel
    {
        public int Prc_ID { get; set; }
        public string Image_Site { get; set; }
        public string Image_Base { get; set; }
        public string AppCode { get; set; }
        public string Prc_Br { get; set; }
        public byte[] Img { get; set; }
        public string Suplier { get; set; }
        public string Cust_ID { get; set; }
        public string TName { get; set; }
        public string IsShowBasket { get; set; }
        public string gdate { get; set; }
        public string id { get; set; }
        public string parent_id { get; set; }
        // список названий категорий в виде  строки
        public string txtcrumbs { get; set; }
        // список id категорий в виде  строки
        public string idcrumbs { get; set; }

        public List<string> NameCategories { get; set; }
        public List<string> IdCategories { get; set; }
    }
}
