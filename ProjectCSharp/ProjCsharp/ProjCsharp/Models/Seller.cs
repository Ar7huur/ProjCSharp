using System.Collections.Generic;
using System.Linq;

namespace ProjCsharp.Models {
    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public double BaseSalary { get; set; }

        //associações
        public Departament Departament { get; set; } //associado com Departamento, ou seja: muitos vendedores são de um departamento ( 1 pra * ou * pra 1)
        //public ICollection<SalesRecord> Sales { get; set; } //instaciado, associado Vendedores com recorde de vendas (1 vendedor pode ter * recorde de vendas).

        

        public Seller() {
        }

        public Seller(int id, string name, string email, string cPF, double baseSalary, Departament departament) {
            Id = id;
            Name = name;
            Email = email;
            CPF = cPF;
            BaseSalary = baseSalary;
            Departament = departament;
        }
    }
}
