using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Crud_Test
{
    public partial class InsertCategory : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para insertar una categoría.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        protected void btnInsertCategory_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar y obtener los valores de los campos
                int categoryId = int.Parse(txtCategoryId.Text);
                string categoryName = txtCategoryName.Text;
                bool isActive = ddlIsActive.SelectedValue == "1";

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
            
                DataAccess.ExecuteStoredProcedure("Usp_Ins_Co_Categoria", parameters);
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", "Swal.fire('¡Éxito!', 'Categoría agregada correctamente', 'success').then(() => window.location.href = 'ListCategory.aspx');", true);
           
                
            }
            catch (FormatException ex)
            {           
                lblErrorMessage.Text = "Error en el formato del algún campo.";
                lblErrorMessage.Visible = true;
                LogError(ex);
            }
            catch (SqlException ex)
            {
                // Manejar errores de SQL 
       
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Error al insertar la categoría. Asegúrese de que el ID de categoría no exista.', 'error');", true);

                LogError(ex);
            }
            catch (Exception ex)
            {
                // Manejar otros errores no previstos
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlertError", "Swal.fire('¡Error!', 'Error al insertar la categoría.', 'error');", true);
                LogError(ex);
            }
        }


     

        /// <summary>
        /// Registra el error especificado en un archivo de registro.
        /// </summary>
        /// <param name="ex">La excepción que se produjo.</param>
        private void LogError(Exception ex)
        {
            //Manejos el error con un log, No es lo ideal deberia de ir en la BD
            System.IO.File.AppendAllText(Server.MapPath("~/Errors.log"), DateTime.Now.ToString() + ": " + ex.ToString() + Environment.NewLine);
        }
    }
}
