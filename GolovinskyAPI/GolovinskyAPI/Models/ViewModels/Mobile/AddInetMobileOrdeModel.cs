using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.ViewModels.Mobile
{
    public class AddInetMobileOrdeModel
    {
        // Строка содержимого заказа, пересылаемая из мобильного приложения
        [MaxLength(1000)]
        public string String { get; set; }

        // Примечание
        [MaxLength(8000)]
        public string Note { get; set; }

        // Телефон
        [MaxLength(50)]
        public string Phone { get; set; }
    }
}
