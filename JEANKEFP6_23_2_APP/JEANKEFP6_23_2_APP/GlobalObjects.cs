﻿using System;
using System.Collections.Generic;
using System.Text;
using JEANKEFP6_23_2_APP.Models;

namespace JEANKEFP6_23_2_APP
{
    public static class GlobalObjects
    {
            //definimos las propiedades de codificación de los json
            //que usaremos en los modelos
            public static string MimeType = "application/json";
            public static string ContentType = "Content-Type";

            //Crear el objeto local (global) de usuario 
            public static UserDTO MyLocalUser = new UserDTO();
        
    }
}
