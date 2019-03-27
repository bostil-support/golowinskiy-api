using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.ViewModels.Mobile
{
    public class OutMobileDbModel
    {
        [MaxLength(4000)]
        public string P_Id { get; set; }

        [MaxLength(4000)]
        public string G_Id { get; set; }

        public string G_Name { get; set; }

        [MaxLength(4000)]
        public string G_Image { get; set; }

        [MaxLength(4000)]
        public string G_Sup { get; set; }
    }
}
