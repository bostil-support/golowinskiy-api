namespace GolovinskyAPI.Models.ViewModels.Products
{
    public class DeleteProductInputModel
    {
        // id товара
        public int Prc_ID { get; set; }
        // id магазина
        public string AppCode { get; set; }
        //
        public int Cust_ID { get; set; }
        //id клиента
        public int? CID { get; set; }
    }
}
