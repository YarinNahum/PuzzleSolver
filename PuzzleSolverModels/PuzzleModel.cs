using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverViewModels
{
    public class PuzzleModel<T> where T : IEquatable<T>
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("Type")]
        public string PuzzleType { get; set; } = null!;
        [BsonElement("Algorithm")]
        public string Algorithm { get; set; } = null!;
        public List<Steps<T>> Steps { get; set; } = null!;
    }

    public class Steps<T> where T : IEquatable<T>
    {
        [BsonId]
        public int Id { get; set; }
        [BsonElement("State")]
        public List<List<T>> BoardState { get; set; } = null!;
    }
}
