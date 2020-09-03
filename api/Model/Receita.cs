using System;
using MongoDB.Bson;

namespace api.Model {
    public class Receita : InputFinanceiro {
        
        public Receita(string nome, double valor, DateTime dataInicio, DateTime dataFim) : base(nome, valor, dataInicio, dataFim){

        }

        public Receita(string nome, double valor, DateTime dataInicio, DateTime dataFim, string codigo, ObjectId _id) 
            : base(nome, valor, dataInicio, dataFim, codigo, _id) {}
    }
}