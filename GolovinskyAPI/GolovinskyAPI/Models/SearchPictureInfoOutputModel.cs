using GolovinskyAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models
{
    public class SearchPictureInfoOutputModel
    {
        public string Catalog { get; set; }
        public string Ctlg_Name { get; set; }
        public string Ctlg_No { get; set; }
        public string TName { get; set; }
        public string Suplier { get; set; }
        public string TDescription { get; set; }
        public string ID { get; set; }
        public string Sup_ID { get; set; }
        public string Wgt { get; set; }
        public string Code_1C { get; set; }
        public string Qty { get; set; }
        public string Delivery { get; set; }
        public string phoneclient { get; set; }
        public string v_isnoprice { get; set; }
        public string isprice { get; set; }
        public string youtube { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string addr { get; set; }
        public int Prc_ID { get; set; }
        public string prc_Br { get; set; }
        public string t_imageprev { get; set; }
        public List<Image> AdditionalImages { get; set; }

        public SearchPictureInfoOutputModel()
        {
            AdditionalImages = new List<Image>();
        }

    }
}
