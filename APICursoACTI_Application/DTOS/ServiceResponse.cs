using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Application.DTOS
{
    /// <summary>
    /// Clase de apoyo para estandarizar las respuestas de los servicios.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Representa los datos de la respuesta del servicio.
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// Repreernta el estado de la respuesta del servicio.
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// Representa el mensaje de la respuesta del servicio.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Metodo que permite crear una respuesta exitosa.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ServiceResponse<T> Ok(T data, string message = "Operación exitosa") =>
       new() { Success = true, Message = message, Data = data };

        /// <summary>
        /// Metodo que permite crear una respuesta fallida.
        /// </summary>
        /// <param name="message">Objeto</param>
        /// <returns>Respuesta fallida</returns>
        public static ServiceResponse<T> Fail(string message) =>
            new() { Success = false, Message = message };


    }
}
