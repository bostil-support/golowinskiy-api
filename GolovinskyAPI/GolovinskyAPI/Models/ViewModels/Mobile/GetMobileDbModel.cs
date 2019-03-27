using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.ViewModels.Mobile
{
    public class GetMobileDbModel
    {
        // Код приложения
        [MaxLength(50)]
        public string AppCode { get; set; }

        // Наименование таблицы локальной базы данных приложения
        [MaxLength(100)]
        public string TableName { get; set; }

        //Код установки приложения на мобильное устройство
        [MaxLength(10)]
        public string CodeMobile { get; set; }
    }
}
