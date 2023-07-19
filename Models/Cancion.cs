using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MusicaApi.Models
{
    public class Cancion
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Nombre { get; set; }

        public string? Genero { get; set; }

        public string? Banda { get; set; }

        public string? Discografica { get; set; }

    }
}