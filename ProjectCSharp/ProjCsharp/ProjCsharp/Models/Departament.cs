using System.Collections.Generic;
using System;
using System.Linq;
namespace ProjCsharp.Models {
    public class Departament {
        public int Id { get; set; }
        public string Name { get; set; }

        //associações
        //public Seller Sellers { get; set; }  //instaciada e associado departamento com seller ( 1 departamento tem * vendedores)

        //construtores vazios e com arguments.
        public Departament() { }

        public Departament(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
