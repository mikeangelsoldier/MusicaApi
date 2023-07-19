using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MusicaApi.Models
{
    public class Cancion
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Genero { get; set; }

        public string? Banda { get; set; }

        public string? Discografia { get; set; }

    }
}