using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.Models
{
    public class Ask
    {    
        public RestRequest Request { get; set; }

        //Atributos traidos de el modelo del API
        public long AskId { get; set; }
        public DateTime? Date { get; set; }
        public string Ask1 { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        //public virtual AskStatus AskStatus { get; set; } = null!;
        //public virtual User User { get; set; } = null!;

        public async Task<ObservableCollection<Ask>> GetAskListByUserID()
        {
            try
            {
                //Usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = string.Format("api/AskStatus/1", this.AskStatusId);


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

                    var list = JsonConvert.DeserializeObject<ObservableCollection<Ask>>(response.Content);

                    return list;
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


        public async Task<bool> AddAskAsync()
        {
            try
            {
                //Usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = string.Format("Asks");

                //armamos la ruta completa al endpoint en el API

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //En el caso de una operación POST debemos serializar el objeto para pasarlo como
                //json al API
                string SerializedModelObject = JsonConvert.SerializeObject(this);
                //Agregamos el objeto serializado al cuerpo del request.
                Request.AddBody(SerializedModelObject, GlobalObjects.MimeType);


                //ejecutar la llamada al API
                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
