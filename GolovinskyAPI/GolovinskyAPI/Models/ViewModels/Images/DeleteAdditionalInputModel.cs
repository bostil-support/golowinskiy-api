using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DeleteAdditionalInputModel
{
    // id юзера
    public int Cust_ID { get; set; }
    // id товара
    public int Prc_ID { get; set; }
    // порядковый номер картинки в ряду
    public string ImageOrder { get; set; }
    // id магазина
    public string AppCode { get; set; }
    // id пользователя, должен будет передаваться при работе Системы частных объявлений
    public int CID { get; set; }
}