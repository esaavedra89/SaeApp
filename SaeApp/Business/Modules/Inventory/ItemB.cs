using SaeApp.DataAccess.Modules.Inventory;
using SaeApp.Model.Modules.Inventory;
using SaeApp.Model.Modules.System.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaeApp.Business.Modules.Inventory
{
    public class ItemB
    {
        /// <summary>
        /// Método para ejecutar lógica de negocio antes de ejecutar la operación Guardar.
        /// </summary>
        public async Task<Response> PreSave(Item objItem, ItemDAO objItemDAO)
        {
            try
            {
                Response objResponse = new Response();
                if (objItem == null)
                    objResponse.UnsuccessfulResponse(404, "El ítem es nulo");
                else
                {
                    if (objItem.IdItem == 0)
                    {
                         Item query = await GetItemAsync(objItem.Internalcode, objItem.IdCompany).ConfigureAwait(false);
                        if (query != null)
                            objResponse.UnsuccessfulResponse(403, "Código existente");
                    }
                    else
                    {

                    }
                }

                return objResponse;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Registra o modifica un objeto.
        /// </summary>
        /// <returns>Id primario del objeto.</returns>
        public async Task<int> Guardar(Item objItem)
        {
            try
            {
                // Objeto DAO.
                ItemDAO objItemDAO = await ItemDAO.Instance;

                // Realizamos la operación en la base de datos.              
                int id = await objItemDAO.SaveItemAsync(objItem);

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para ejecutar lógica de negocio despúes de ejecutar la operación Guardar. 
        /// </summary>
        private void PostGuardar(Item objItem, ItemDAO objItemDAO)
        {
        }
        
        /// <summary>
        /// Elimina registros de la tabla.
        /// </summary>
        public async Task Eliminar(Item item)
        {
            try
            {
                // Objeto DAO.
                ItemDAO objItemDAO = await ItemDAO.Instance;

                // Realizamos la operación en la base de datos.
                await objItemDAO.DeleteItemAsync(item).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtiene la lista de Items para una empresa.
        /// </summary>
        /// <param name="idRutaTransporte">Id de la ruta de transporte.</param>
        public async Task<List<Item>> GetItemsAsync()
        {
            List<Item> lista = new List<Item>();

            try
            {
                // Objeto DAO.
                ItemDAO objItemDAO = await ItemDAO.Instance;

                // Realizamos la operación en la base de datos.
                lista = await objItemDAO.GetItemsAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la lista de Items para una empresa.
        /// </summary>
        /// <param name="idRutaTransporte">Id de la ruta de transporte.</param>
        public async Task<Item> GetItemAsync(int idItem, int idCompany)
        {
            try
            {
                // Objeto DAO.
                ItemDAO objItemDAO = await ItemDAO.Instance;

                // Realizamos la operación en la base de datos.
                return await objItemDAO.GetItemAsync(idItem, idCompany).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtiene la lista de Items para una empresa.
        /// </summary>
        /// <param name="idRutaTransporte">Id de la ruta de transporte.</param>
        public async Task<Item> GetItemAsync(string code, int idCompany)
        {
            try
            {
                // Objeto DAO.
                ItemDAO objItemDAO = await ItemDAO.Instance;

                // Realizamos la operación en la base de datos.
                return await objItemDAO.GetItemAsync(code, idCompany).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
