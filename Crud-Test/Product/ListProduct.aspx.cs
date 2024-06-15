using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Crud_Test
{
    public partial class ListProduct : System.Web.UI.Page
    {
        /// <summary>
        /// Evento que se ejecuta al cargar la página.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El objeto que contiene los datos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Cargar las categorías en el DropDownList al cargar la página
                    LoadCategories();
                    SelectFirstCategory();
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Error al cargar las categorías.";
                    lblErrorMessage.Visible = true;
                    LogError(ex);
                }
            }
        }


        /// <summary>
        /// Selecciona la primera categoría que tiene productos y carga los datos.
        /// </summary>
        protected void SelectFirstCategory()
        {
            foreach (ListItem item in ddlCategories.Items)
            {
                int categoryId;
                if (int.TryParse(item.Value, out categoryId))
                {
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@IdCategoria", categoryId)
                        };

                        DataTable dt = DataAccess.ExecuteStoredProcedure("Usp_Sel_Co_Productos", parameters);

                        if (dt.Rows.Count > 0)
                        {
                            ddlCategories.SelectedValue = item.Value;
                            LoadProductData(categoryId);
                            lblErrorMessage.Visible = false;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Error al verificar productos para la categoría.";
                        lblErrorMessage.Visible = true;
                        LogError(ex);
                    }
                }
            }

            // Si no hay ninguna categoría con productos
            lblErrorMessage.Text = "No hay categorías con productos disponibles.";
            lblErrorMessage.Visible = true;
        }

        /// <summary>
        /// Carga las categorías desde la base de datos en el DropDownList.
        /// </summary>
        protected void LoadCategories()
        {
            try
            {
                DataTable dt = DataAccess.ExecuteStoredProcedure("Usp_Sel_Co_Categorias");

                ddlCategories.DataSource = dt;
                ddlCategories.DataTextField = "cNombCateg";
                ddlCategories.DataValueField = "nIdCategori";
                ddlCategories.DataBind();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error al cargar las categorías.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se cambia la categoría seleccionada en el DropDownList.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El objeto que contiene los datos del evento.</param>
        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID de la categoría seleccionada
                int categoryId = Convert.ToInt32(ddlCategories.SelectedValue);

                // Cargar los productos según la categoría seleccionada
                LoadProductData(categoryId);
            }
            catch (FormatException ex)
            {
                lblErrorMessage.Text = "ID de categoría no válido.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error al cargar los productos.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
        }

        /// <summary>
        /// Carga los productos desde la base de datos según la categoría seleccionada.
        /// </summary>
        /// <param name="categoryId">El ID de la categoría.</param>
        protected void LoadProductData(int categoryId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IdCategoria", categoryId)
                };

                DataTable dt = DataAccess.ExecuteStoredProcedure("Usp_Sel_Co_Productos", parameters);

                //si la categoría seleccionada no tiene productos y el mensaje de error se mostrará caso contrario se mostrara
                if (dt.Rows.Count > 0)
                {
                    GridViewProducts.DataSource = dt;
                    GridViewProducts.DataBind();
                    lblErrorMessage.Visible = false; // Ocultar el mensaje de error si hay datos
                }
                else
                {
                    GridViewProducts.DataSource = null;
                    GridViewProducts.DataBind();
                    lblErrorMessage.Text = "La categoría seleccionada no cuenta con productos.";
                    lblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error al cargar los productos.";
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
