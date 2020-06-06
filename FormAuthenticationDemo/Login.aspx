<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FormAuthenticationDemo.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-md-2">帳號:</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBox_UserName" TextMode="Search" AutoCompleteType="Disabled" CssClass="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <label class="control-label col-md-2">密碼:</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBox_Password" TextMode="Password" AutoCompleteType="Disabled" CssClass="form-control"/>
                </div>
            </div>
            <div class="form-group">
                <asp:LinkButton runat="server" ID="LinkButton_Submit" CssClass="btn btn-primary" OnClick="LinkButton_Submit_OnClick">
                    <i class="glyphicon glyphicon-ok"></i>登入
                </asp:LinkButton>
            </div>
        </div>

    </div>
</asp:Content>