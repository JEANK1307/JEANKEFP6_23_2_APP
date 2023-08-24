using JEANKEFP6_23_2_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JEANKEFP6_23_2_APP.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public User MyUser { get; set; }

        public UserDTO MyUserDTO { get; set; }

        public UserViewModel()
        {
            MyUser = new User();
            MyUserDTO = new UserDTO();
        }

        //Funciones

        //Funcion que carga los datos del objeto de usuario global
        public async Task<UserDTO> GetUserDataAsync()
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {
                UserDTO userDTO = new UserDTO();

                userDTO = await MyUserDTO.GetUserInfo();

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
