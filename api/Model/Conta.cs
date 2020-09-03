using System;
using MongoDB.Bson;

namespace api.Model {
    public class Conta : InputFinanceiro {
       public Conta(string nome, double valor, DateTime dataInicio, DateTime dataFim) : base(nome, valor, dataInicio, dataFim){

        }

        public Conta(string nome, double valor, DateTime dataInicio, DateTime dataFim, string codigo, ObjectId _id) 
            : base(nome, valor, dataInicio, dataFim, codigo, _id) {}
        public int diaVencimento { get; set; }
    }
}