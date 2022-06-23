using System;
using System.Collections.Generic;
using System.Text;

namespace SaeApp.Model.Modules.System.Entity
{
    public class Response
    {
        /// <summary>
        /// Indica si fue exitosa o no la petición.
        /// </summary>
        public bool Valid
        {
            get;
            set;
        }

        /// <summary>
        /// Código obtenido de la respuesta.
        /// </summary>
        public int Code
        {
            get;
            set;
        }

        /// <summary>
        /// message a mostrar.
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Resultado de la respuesa en un string.
        /// </summary>
        public object Result
        {
            get;
            set;
        }

        /// <summary>
        /// resultTwo de la respuesa en un objeto.
        /// </summary>
        public object ResultTwo
        {
            get;
            set;
        }

        /// <summary>
        /// Método que establece la conexión como existosa y estable el message respectivo.
        /// </summary>
        /// <param name="code">Código de la respuesta.</param>
        /// <param name="message">message de la respuesta.</param>
        public void SuccessfulResponse(int code, string message)
        {
            this.Valid = true;
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// Método que establece la conexión como existosa, establece el message respectivo y el objeto obtenido.
        /// </summary>
        /// <param name="code">Código de la respuesta.</param>
        /// <param name="message">message de la respuesta.</param>
        /// <param name="resultado">Objeto obtenido de la respuesta.</param>
        public void SuccessfulResponse(int code, string message, object resultado)
        {
            this.Valid = true;
            this.Code = code;
            this.Message = message;
            this.Result = resultado;
        }

        /// <summary>
        /// Método que establece la conexión como existosa, establece el message respectivo y el objeto obtenido.
        /// </summary>
        /// <param name="code">Código de la respuesta.</param>
        /// <param name="message">message de la respuesta.</param>
        /// <param name="resultado">Objeto obtenido de la respuesta.</param>
        /// <param name="resultTwo">Segundo objeto obtenido de la respuesta.</param>
        public void SuccessfulResponse(int code, string message, object resultado, object resultTwo)
        {
            this.Valid = true;
            this.Code = code;
            this.Message = message;
            this.Result = resultado;
            this.ResultTwo = resultTwo;
        }

        /// <summary>
        /// Método que establece la conexión como no existosa y estable el message respectivo.
        /// </summary>
        /// <param name="code">Código de la respuesta.</param>
        /// <param name="message">message de la respuesta.</param>
        public void UnsuccessfulResponse(int code, string message)
        {
            this.Valid = false;
            this.Code = code;
            this.Message = message;
        }
    }
}
