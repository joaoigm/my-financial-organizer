using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Model {
    public interface IDocument {

        [BsonId]
        ObjectId _id { get; set; }

        string codigo { get; set; }
    }
}