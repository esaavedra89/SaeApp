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
        public async Task<Response> PreSave(Item objItem)
        {
            try
            {
                Response objResponse = new Response();
                if (objItem == null)
                {
                    objResponse.UnsuccessfulResponse(404, "El ítem es nulo.");
                    return objResponse;
                }

                Item query = await GetItemAsync(objItem.Internalcode, objItem.IdCompany).ConfigureAwait(false);
                if (objItem.IdItem == 0 && query != null)
                {
                    objResponse.UnsuccessfulResponse(403, "El código del ítem ya existe, por favor ingrese uno nuevo.");
                    return objResponse;
                }

                if (string.IsNullOrEmpty(objItem.Name))
                {
                    objResponse.UnsuccessfulResponse(403, "Debe ingresar un nombre para el ítem.");
                    return objResponse;
                }

                if (objItem.IdBrand == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "Debe selecionar una marca.");
                    return objResponse;
                }

                if (objItem.CostPrice == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "Debe ingresar el precio costo del ítem.");
                    return objResponse;
                }

                if (objItem.ProfitPercentage == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "Debe ingresar el porcentaje de ganacia del ítem.");
                    return objResponse;
                }

                if (objItem.UnitPrice == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "No se ha calculado el precio unitario del ítem.");
                    return objResponse;
                }

                if (objItem.ProfitPercentage == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "No se ha calculado la gancia del ítem.");
                    return objResponse;
                }

                if (objItem.ProfitPercentage == 0)
                {
                    objResponse.UnsuccessfulResponse(403, "Debe ingresar un precio de venta para el ítem.");
                    return objResponse;
                }

                objResponse.SuccessfulResponse(200,"OK");

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
        public async Task<Response> Save(Item objItem)
        {
            try
            {
                Response objResponse = new Response();

                Response objRespPreSave = await PreSave(objItem).ConfigureAwait(false);
                if (objRespPreSave.Valid)
                {
                    // Objeto DAO.
                    ItemDAO objItemDAO = await ItemDAO.Instance;

                    // Realizamos la operación en la base de datos.              
                    int id = await objItemDAO.SaveItemAsync(objItem);

                    objResponse.SuccessfulResponse(id, "OK");
                }
                else
                    objResponse.UnsuccessfulResponse(402, objRespPreSave.Message);

                return objResponse;
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
