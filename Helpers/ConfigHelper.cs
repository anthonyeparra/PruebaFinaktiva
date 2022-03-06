using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaFinaktiva.Helpers
{
    public class ConfigHelper
    {
        // FUNCIÓN PARA OBTENER LAS CONFIGURACIONES DE APLICACIÓN
        public static IConfiguration readAppConfig()
        {
            //LEEMOS JSON DE CONFIGURACIÓN
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }
    }
}
