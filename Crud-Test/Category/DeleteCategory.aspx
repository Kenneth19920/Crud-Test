<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCategory.aspx.cs" Inherits="Crud_Test.DeleteCategory" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br>
    <br>
    <h2 class="text-center mb-4"> ¿Estás seguro que deseas eliminar esta categoría? </i></h2>
    <br>
       <div class="form-container">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <h3 class="text-center mb-4"><i class="fa fa-trash"></i></h3>
                <div class="col-md-6">

                     <div class="form-group">
                        <label for="txtCategoryId"><i class="fa fa-id-card"></i> ID de Categoría:</label>
                        <asp:TextBox Enabled="false" ID="txtCategoryId"  runat="server" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCategoryId" runat="server"
                            ControlToValidate="txtCategoryId"
                            ErrorMessage="El ID de categoría es requerido."
                            Display="Dynamic"
                            ForeColor="Red" />
                        <asp:RegularExpressionValidator ID="revCategoryId" runat="server"
                            ControlToValidate="txtCategoryId"
                            ErrorMessage="El ID de categoría debe ser numérico."
                            ValidationExpression="^\d+$"
                            Display="Dynamic"
                            ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <label for="txtCategoryName"><i class="fa fa-tag"></i> Nombre de Categoría:</label>
                        <asp:TextBox Enabled="false" ID="txtCategoryName" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Ej. Electrónicos"></asp:TextBox>
                        <asp:CustomValidator ID="cvCategoryName" runat="server"
                            ClientValidationFunction="validateCategoryName"
                            ErrorMessage="El nombre de categoría debe contener solo letras."
                            Display="Dynamic"
                            ForeColor="Red" />
                        <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server"
                            ControlToValidate="txtCategoryName"
                            ErrorMessage="El nombre de categoría es requerido."
                            Display="Dynamic"
                            ForeColor="Red" />
                    </div>

                    <div class="form-group">
                        <label for="ddlIsActive"> <i class="fa fa-toggle-on"></i> Estado: </label>
                        <asp:DropDownList Enabled="false" CssClass="form-control dropdown-control" ID="ddlIsActive" runat="server">
                            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group d-flex justify-content-between">

                        <asp:Button ID="btnDeleteCategory" runat="server" Text="Eliminar Categoria" OnClick="btnDelete_Click" CssClass="btn btn-outline-danger" />
                        <a class="btn btn-outline-warning" href="ListCategory">
                            <i class="fa fa-chevron-left"></i> Regresar
                        </a>
                    </div>

                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                </div>


            </div>
        </div>
    </div>
     <style>
      *, *::before, *::after {
            box-sizing: inherit;
        }

  

        .form-control {
            width: 100%;
            height: calc(1.5em + .75rem + 2px);
            padding: .375rem .75rem;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
        }

        .dropdown-control {
            background: url('data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAxMCAxMCI+PHBhdGggZD0iTTAgMmgxMGwtNSA1eiIgZmlsbD0iIzY2NiIvPjwvc3ZnPg==') no-repeat right 0.75rem center/8px 10px;
            padding-right: 1.5rem;
            cursor: pointer;
            background-color: #fff; /* Color de fondo blanco para el dropdown */
        }

        .form-container {
            max-width: 500px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            --bs-bg-opacity: 1;
            background-color: rgba(33, 37, 41, var(--bs-bg-opacity));
        }

        input[type="text"],
        button,
        select{
            padding: 8px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            background-color: #fff; /* Color de fondo para los inputs y botones */
            color: #495057; /* Color de texto para los inputs y botones */
        }

        button {
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
        }

            button:hover {
                background-color: #45a049;
            }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</asp:Content>
