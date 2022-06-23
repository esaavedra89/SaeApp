using Newtonsoft.Json;
using SQLite;

namespace SaeApp.Model.Modules.System.Secutiry
{
    public class Resource
    {
        public const int ID_RESOURCE_LOGIN = 100;
        public const int ID_RESOURCE_HOME = 101;

        public const int ID_RESOURCE_SYSTEM = 101100;

        public const int ID_RESOURCE_INVENTORY = 102100;
        public const int ID_RESOURCE_INVENTORY_ITEM = 102101;
        public const int ID_RESOURCE_INVENTORY_INVENTORYMOVEMENT = 102102;

        public const int ID_RESOURCE_SELL = 103100;
        public const int ID_RESOURCE_SELL_INVOICE = 103101;
        public const int ID_RESOURCE_SELL_DELIVERYNOTE = 103102;
        public const int ID_RESOURCE_SELL_PROFORMA = 103103;

        #region Propiedades

        /// <summary>
        /// Id del Recurso en el almacenamiento local.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int IdRecursoLocal { get; set; }

        /// <summary>
        /// Id del Recurso.
        /// </summary>
        public int IdRecurso { get; set; }

        /// <summary>
        /// Id del modulo.
        /// </summary>
        public int IdModulo { get; set; }

        /// <summary>
        /// Indica si el recurso tiene hijos.
        /// </summary>
        public bool TieneHijos { get; set; }

        /// <summary>
        /// URL de la imagen.
        /// </summary>
        public string UrlImagenOpcionMenu { get; set; }

        /// <summary>
        /// Nivel del recurso.
        /// </summary>
        public int Nivel { get; set; }

        /// <summary>
        /// Indica si es Super Administrador o no.
        /// </summary>
        public bool SuperAdministrador { get; set; }

        /// <summary>
        /// Id del tipo de recurso.
        /// </summary>
        public int IdTipoRecurso { get; set; }

        /// <summary>
        /// Id del recurso padre del recurso actual.
        /// </summary>
        public int IdRecursoPadre { get; set; }

        /// <summary>
        /// Nombre del recurso.
        /// </summary>
        [JsonIgnore, Ignore]
        public string Nombre { get; set; }

        /// <summary>
        /// Icono del recurso a mostrar.
        /// </summary>
        [JsonIgnore, Ignore]
        public string IconFont { get; set; }

        /// <summary>
        /// Icono y texto a mostrar.
        /// </summary>
        [JsonIgnore, Ignore]
        public string TextAndIcon
        {
            get
            {
                return string.Format(" {0} {1} ", IconFont, Nombre);
            }
        }

        #endregion
    }
}
