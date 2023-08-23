using JEANKEFP6_23_2_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        //El VM funciona como puente entre el modelo y la vista
        //en sentido teorico el VM "siente" los cambios de la vista
        //y los pasa al modelo de forma automática, o viceversa
        //según se use en uno o dos sentidos.

        //También se puede usar (como en este caso particular,
        //simplemente como mediador de procesos. Más adelante se usará
        //commands y bindings en 2 sentidos.

        //primero en formato de funciones clásicas

        public User MyUser { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyUserDTO = new UserDTO();
        }

        //Funciones

        //Funcion que carga los datos del objeto de usuario global
        public async Task<UserDTO> GetUserDataAsync(string pEmail)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUserInfo(pEmail);

                if (userDTO == null) return null;
                return userDTO;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally { IsBusy = false; }
        }
    }
}
