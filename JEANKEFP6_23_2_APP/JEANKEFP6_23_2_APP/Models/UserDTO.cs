using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.Models
{
    public class UserDTO
    {
        [Newtonsoft.Json.JsonIgnore]
        public RestRequest Request { get; set; }

        public int IDUsuario { get; set; }
        public string UsuarioNombre { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Contrasennia { get; set; } = null!;
        public int ConteoIntentos { get; set; }
        public string CorreoRespaldo { get; set; } = null!;
        public string? DescripcionPuesto { get; set; }
        public int IDEstado { get; set; }
        public int IDPais { get; set; }
        public int IDRol { get; set; }

        public async Task<UserDTO> GetUserInfo()
        {
            try
            {
                //Usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = string.Format("Users/GetUserInfoByEmail?Pemail=3");


                //armamos la ruta completa al endpoint en el API

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //En el API diseñamos el end point de forma que retorne un list<UserDTO>
                    //Pero esta funcion retorna solo UN objeto de UserDTO, por lo tanto
                    //debemos seleccionar de la lista el item con el index 0.

                    //esto puede llegar a servir para muchos propósitos donde un API retorna uno o muchos registros
                    //pero necesitamos solo 1 de ellos

                    var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDTO>>(response.Content);

                    var item = list[0];

                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }
    }
}
