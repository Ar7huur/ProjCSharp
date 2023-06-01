
namespace ProjCsharp.Models {
    public class SalesRecord {

        public int Id { get; set; }
        public string Date { get; set; }
        public double Amount { get; set; }

        

        //associações

        public Seller Seller { get; set; } //associado a vendedores ou seja, cada recorde de vendas possui um único vendedor.

        //Construtores..
        public SalesRecord() { }

        public SalesRecord(int id, string date, double amount, Seller seller) {
            Id = id;
            Date = date;
            Amount = amount;
            Seller = seller;
        }




    }
}
