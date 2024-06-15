<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCategory.aspx.cs" Inherits="Crud_Test.ListCategory" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="container">
        <h2><i class="fas fa-list"></i> Listado de Categorías</h2>

        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <br />

        <div class="text-right mb-3">
            <a class="btn btn-outline-success" href="InsertCategory">
                <i class="fas fa-plus-circle"></i> Agregar Categoría
            </a>
        </div>

        <asp:GridView ID="GridViewCategory" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-id-card"></i> ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("nIdCategori") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-box"></i> Nombre
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("cNombCateg") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-check-circle"></i> Estado
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Convert.ToBoolean(Eval("cEsActiva")) ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Acciónes">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# Eval("nIdCategori", "EditCategory.aspx?id={0}") %>' Text='<i class="fas fa-edit"></i>' />
                        &nbsp;|&nbsp;
                        <asp:HyperLink ID="lnkDelete" runat="server" NavigateUrl='<%# Eval("nIdCategori", "DeleteCategory.aspx?id={0}") %>' CssClass="action-link delete-link">
                            <i class="fas fa-trash-alt"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No se encontraron categorías.
            </EmptyDataTemplate>
            <HeaderStyle CssClass="bg-dark text-white" />
            <RowStyle CssClass="table-dark" />
        </asp:GridView>

    </div>

    <style>
        .action-link {
            display: inline-block;
            color: #dc3545;
            text-decoration: none;
        }

            .action-link:hover,
            .action-link:focus {
                color: #dc3545;
                text-decoration: none;
                outline: none;
            }
    </style>


</asp:Content>

