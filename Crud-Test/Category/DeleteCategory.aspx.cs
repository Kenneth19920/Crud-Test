using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Optimization;
using System.Web.UI;

namespace Crud_Test
{
    public partial class DeleteCategory : Page
    {
        /// <summary>
        /// Método que se ejecuta al cargar la página.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoryId;
                if (int.TryParse(Request.QueryString["id"], out categoryId))
                {
                    try
                    {
                        LoadCategoryData(categoryId);
                    }
                    catch (Exception ex)
                    {
                        lblErrorMessage.Text = "Error al cargar los datos de la categoría.";
                        lblErrorMessage.Visible = true;
                        LogError(ex);
                    }
                }
                else
                {
                    Response.Redirect("ListCategory.aspx");
                }
            }
        }

        /// <summary>
        /// Carga los datos de la categoría basada en el ID proporcionado.
        /// </summary>
        /// <param name="categoryId">El ID de la categoría.</param>
        protected void LoadCategoryData(int categoryId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nIdCategori", categoryId)
                };

                DataTable dt = DataAccess.ExecuteStoredProcedure("Usp_Sel_Co_Id_Categoria", parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtCategoryId.Text = row["nIdCategori"].ToString();
                    txtCategoryName.Text = row["cNombCateg"].ToString();
                    ddlIsActive.SelectedValue = Convert.ToBoolean(row["cEsActiva"]) ? "1" : "0";
                }
                else
                {
                    lblErrorMessage.Text = "No se encontraron datos para la categoría especificada.";
                    lblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error al cargar los datos de la categoría.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para eliminar la categoría.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = int.Parse(txtCategoryId.Text);

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@nIdCategori", categoryId)
                };

                // Ejecutar procedimiento almacenado para eliminar la categoría
                DataAccess.ExecuteStoredProcedure("Usp_Del_Co_Categoria", parameters);

                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('¡Éxito!', 'Categoría eliminada correctamente', 'success').then(() => window.location.href = 'ListCategory.aspx');", true);

            }
            catch (FormatException ex)
            {
                lblErrorMessage.Text = "Error en el formato del algún campo.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
            catch (SqlException ex)
            {
                // Manejar errores de SQL específicos
                if (ex.Number == 547) // Número de error SQL para violación de restricción de clave externa
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Error al insertar la categoría. Asegúrese de que el ID de categoría no exista.', 'error');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Error al insertar la categoría.', 'error');", true);

                }
                LogError(ex);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Ocurrió un error inesperado. Por favor, intenta nuevamente..', 'error');", true);
                LogError(ex);
            }
        }




        /// <summary>
        /// Registra el error especificado en un archivo de registro.
        /// </summary>
        /// <param name="ex">La excepción que se produjo.</param>
        private void LogError(Exception ex)
        {
            // Implementa la lógica para registrar el error.
            // Puede ser en un archivo de texto, base de datos, etc.
            // Ejemplo simple:
            System.IO.File.AppendAllText(Server.MapPath("~/Errors.log"), DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
        }
    }
}
