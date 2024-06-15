<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListProduct.aspx.cs" Inherits="Crud_Test.ListProduct" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
        <br />
    <div class="container">
        <h2><i class="fas fa-list"></i> Listado de Productos</h2>
        <br />
        <div class="row">
            <div class="col-md-6">
                <label for="ddlCategories" style="font-weight: bold;">Categoría:</label>
                <asp:DropDownList ID="ddlCategories" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged">
                    <asp:ListItem Text="Todas las Categorías" Value="0" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
      <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-id-card"></i> ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("nIdProduct") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-box"></i> Nombre
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("cNombProdu") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-dollar-sign"></i> Precio
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("nPrecioProd") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <i class="fas fa-tags"></i> Categoría
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%# Eval("cNombCateg") %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="bg-dark text-white text-center" />
                    <ItemStyle CssClass="text-center" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No se encontraron productos.
            </EmptyDataTemplate>
            <HeaderStyle CssClass="bg-dark text-white" />
            <RowStyle CssClass="table-dark" />
            </asp:GridView>



            </div>
        </div>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="true"></asp:Label>
    </div>

  
</asp:Content>

