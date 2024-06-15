using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Crud_Test
{
    public partial class ListCategory : System.Web.UI.Page
    {
        /// <summary>
        /// Evento que se ejecuta al cargar la página.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El objeto que contiene los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si la página se está cargando por primera vez
            if (!IsPostBack)
            {
                try
                {
                    // Cargar todas las categorías al cargar la página
                    LoadCategoriesAll();
                }
                catch (Exception ex)
                {
                   
                    lblErrorMessage.Text = "Error al cargar las categorías.";
                    lblErrorMessage.Visible = true;
                    // Registrar el error
                    LogError(ex);
                }
            }
        }

        /// <summary>
        /// Carga todas las categorías desde la base de datos y las enlaza al GridView.
        /// </summary>
        protected void LoadCategoriesAll()
        {
            try
            {
                // Ejecutar procedimiento almacenado para obtener todas las categorías
                DataTable dt = DataAccess.ExecuteStoredProcedure("Usp_Sel_Co_All_Categorias");

                // Asignar el resultado al origen de datos del GridView
                GridViewCategory.DataSource = dt;
                GridViewCategory.DataBind();
            }
            catch (Exception ex)
            {

                lblErrorMessage.Text = "Error al cargar las categorías.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
        }


        /// <summary>
        /// Método para registrar errores.
        /// </summary>
        /// <param name="ex">La excepción que se produjo.</param>
        private void LogError(Exception ex)
        {
            //Manejos el error con un log, No es lo ideal deberia de ir en la BD
            System.IO.File.AppendAllText(Server.MapPath("~/Errors.log"), DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
        }
    }
}
