<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InstrumentProductScopeControl.ascx.cs" Inherits="InstrumentProductScope.InstrumentProductScopeControl" %>

<asp:Repeater ID="rptInstruments" runat="server">
    <ItemTemplate>
        <div class="repeater-item" style="margin-bottom: 20px;">
            <asp:Label ID="lblInstrumentName" runat="server" Text='<%# Eval("InsutrementName") %>'></asp:Label>
            <asp:HiddenField ID="hfInstrumentId" runat="server" Value='<%# Eval("InstrumentId") %>' />
            <div style="display: flex; align-items: center;">
                <!-- Left ListBox with a CSS class -->
                <asp:ListBox ID="lstOriginalProductScope" runat="server" SelectionMode="Multiple" DataTextField="ProductScopeName" DataValueField="ProductScopeId"
                             DataSource='<%# Eval("OriginalProductScopeList") %>' CssClass="lstOriginalProductScope"></asp:ListBox>

                <div style="margin: 0 20px;">
                    <!-- Use HTML buttons to avoid form submission -->
                    <button type="button" class="btnMoveRight">→</button>
                    <br /><br />
                    <button type="button" class="btnMoveLeft">←</button>
                </div>

                <!-- Right ListBox with a CSS class -->
                <asp:ListBox ID="lstProductScope" runat="server" SelectionMode="Multiple" DataTextField="ProductScopeName" DataValueField="ProductScopeId"
                             DataSource='<%# Eval("ProductScopeList") %>' CssClass="lstProductScope"></asp:ListBox>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<script type="text/javascript">
    function moveItems(button, toRight) {
        // Find the nearest repeater-item container that holds the list boxes
        var container = button.closest('.repeater-item');

        // Use CSS classes to find the corresponding list boxes within this container
        var sourceListBox = toRight ? container.querySelector('.lstOriginalProductScope') : container.querySelector('.lstProductScope');
        var destinationListBox = toRight ? container.querySelector('.lstProductScope') : container.querySelector('.lstOriginalProductScope');

        // Get the selected options and move them
        var selectedOptions = Array.from(sourceListBox.options).filter(option => option.selected);

        selectedOptions.forEach(option => {
            destinationListBox.appendChild(option);  // Move the option to the destination ListBox
        });
    }

    // Attach event listeners to the buttons after the DOM is fully loaded
    document.addEventListener('DOMContentLoaded', function () {
        // Find all the buttons within the repeater control
        var moveRightButtons = document.querySelectorAll('.btnMoveRight');
        var moveLeftButtons = document.querySelectorAll('.btnMoveLeft');

        // Attach the click event to the "Move Right" buttons
        moveRightButtons.forEach(button => {
            button.addEventListener('click', function () {
                moveItems(button, true);
            });
        });

        // Attach the click event to the "Move Left" buttons
        moveLeftButtons.forEach(button => {
            button.addEventListener('click', function () {
                moveItems(button, false);
            });
        });
    });
</script>
