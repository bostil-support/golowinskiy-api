using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GolovinskyAPI.Models.Orders
{
    public class NewOrderItemInputModel
    {
        //номер заказа – выходной параметр @Ord_ID процедуры [dbo].[sp_AddNewOrder]
        public int OrdTtl_Id { get; set; }
        //порядковый номер позиции в заказе
        public int @OI_No { get; set; }
        //номер по каталогу из рекордсета процедуры [sp_SearchPictureInfo]
        public string Ctlg_No { get; set; }
        public int @Qty { get; set; }
        //наименование каталога – из рекордсета процедуры [sp_SearchPictureInfo]
        public string Ctlg_Name { get; set; }
        //id поставщика – из рекордсета процедуры [sp_SearchPictureInfo]
        public int Sup_ID { get; set; }
        //описание товара из рекордсета процедуры sp_SearchPictureInfo поле TName.
        public string Descr { get; set; }
    }
}
