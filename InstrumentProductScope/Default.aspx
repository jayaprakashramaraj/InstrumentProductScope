<%@ Page Title="Instruments" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="InstrumentProductScope._Default"
    EnableEventValidation="false"%>

<%@ Register Src="~/InstrumentProductScopeControl.ascx" TagPrefix="uc" TagName="InstrumentProductScopeControl" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="row">
            <div>
                <uc:InstrumentProductScopeControl ID="InstrumentProductScopeControl1" runat="server" />
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </main>
</asp:Content>