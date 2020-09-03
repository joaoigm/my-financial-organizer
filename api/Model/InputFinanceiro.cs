using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Model {
    public abstract class InputFinanceiro : IDocument {

        [BsonId]
         public ObjectId _id { get; set; }
        public string nome { get; }
        public double valor { get; }
        public DateTime dataFim { get; set; }
        public DateTime dataInicio { get; set; }

        public string codigo { get; set;}

        public InputFinanceiro(string nome, double valor, DateTime dataInicio, DateTime dataFim){
            this.nome = nome;
            this.valor = valor;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.codigo = gerarCodigo(nome, valor, dataInicio, dataFim);
        }

        public InputFinanceiro(string nome, double valor, DateTime dataInicio, DateTime dataFim, string codigo, ObjectId _id){
            this.nome = nome;
            this.valor = valor;
            this.dataInicio = dataInicio;
            this.dataFim = dataFim;
            this.codigo = codigo;
            this._id = _id;
        }

        public string gerarCodigo(string nome, double valor, DateTime dataInicio, DateTime dataFim) {
            return $@"
                {nome}_
                {dataInicio.ToShortDateString()}_
                {dataFim.ToShortDateString()}_
                {valor.ToString()}";
        }
    }
}