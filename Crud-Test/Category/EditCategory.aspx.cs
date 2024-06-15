using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Crud_Test
{
    public partial class EditCategory : System.Web.UI.Page
    {
        /// <summary>
        /// Método que se ejecuta cuando se carga la página.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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
        /// Método para registrar errores.
        /// </summary>
        /// <param name="ex">La excepción que se produjo.</param>
        private void LogError(Exception ex)
        {
            //Manejos el error con un log, No es lo ideal deberia de ir en la BD
            System.IO.File.AppendAllText(Server.MapPath("~/Errors.log"), DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
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
        /// Evento que se ejecuta al hacer clic en el botón de guardar.
        /// Actualiza los datos de la categoría en la base de datos.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El objeto que contiene los datos del evento.</param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = int.Parse(txtCategoryId.Text);
                string categoryName = txtCategoryName.Text;
                bool isActive = ddlIsActive.SelectedValue == "1";

                // Validación del lado del servidor para campos requeridos
                if (string.IsNullOrEmpty(categoryName))
                {
                    lblErrorMessage.Text = "Intentalo de nuevo.";
                    lblErrorMessage.Visible = true;
                    return;
                }

                // Validación del lado del servidor para el nombre de categoría
                if (!Regex.IsMatch(categoryName, @"^[a-zA-Z]*$"))
                {
                    lblErrorMessage.Text = "El nombre de la categoría solo puede contener letras.";
                    lblErrorMessage.Visible = true;
                    return;
                }

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@nIdCategori", categoryId),
                    new SqlParameter("@cNombCateg", categoryName),
                    new SqlParameter("@cEsActiva", isActive)
                };

                DataAccess.ExecuteStoredProcedure("Usp_Upd_Co_Categoria", parameters);   
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('¡Éxito!', 'Categoría editada correctamente', 'success').then(() => window.location.href = 'ListCategory.aspx');", true);

            }
            catch (FormatException ex)
            {
                lblErrorMessage.Text = "Error en el formato del algún campo.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Error al editar la categoría.', 'error');", true);
                LogError(ex);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Ocurrió un error inesperado. Por favor, intenta nuevamente.', 'error');", true);             
                LogError(ex);
            }
        }



    }
}