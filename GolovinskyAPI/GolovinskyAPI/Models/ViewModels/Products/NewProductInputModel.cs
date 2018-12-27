using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolovinskyAPI.Models.ViewModels.Products
{
    public class NewProductInputModel
    {
        // id магазина
        public string Catalog { get; set; }
        // id категории
        public string Id { get; set; }
        // наименование каталога
        public string Ctlg_Name { get; set; }
        // артикул
        public string TArticle { get; set; }
        // наименование товара
        public string TName { get; set; }
        // описание
        public string TDescription { get; set; }
        // цена
        public string TCost { get; set; }
        // имя фотографии с расширением
        public string TImageprev { get; set; }
        // передавать id магазина
        public string Appcode { get; set; }
        // тип изделия
        public string TypeProd { get; set; }
        // конечная цена изделия в рублях
        public string PrcNt { get; set; }
        // Это чисто то, что впишет клиент
        public string TransformMech { get; set; }
        //VidioName
        public string video { get; set; }
        // id пользователя, параметр, который должен будет передаваться 
        // при работе Системы частных объявлений 
        public int? CID { get; set; }
    }
}
