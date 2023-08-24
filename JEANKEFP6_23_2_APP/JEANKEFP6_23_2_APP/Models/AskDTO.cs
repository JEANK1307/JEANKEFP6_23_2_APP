using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.Models
{
    public class AskDTO
    {
        [Newtonsoft.Json.JsonIgnore]
        public RestRequest Request { get; set; }

        public long IDPregunta { get; set; }
        public DateTime? Fecha { get; set; }
        public string Pregunta1 { get; set; } = null!;
        public int IDUsuario { get; set; }
        public int IDEstado { get; set; }
        public bool? EsValido { get; set; }
        public string? RutaImagen { get; set; }
        public string? Detalle { get; set; }
    }

}
