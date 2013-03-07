<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GMinuta.aspx.vb" Inherits="Procesos_NuevoProceso_Minuta" StylesheetTheme="Extra" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:TextBox ID="TxtNprocA" runat="server" Height="23px" Width="238px"></asp:TextBox>
        
     <ajaxToolkit:AutoCompleteExtender ID="autoCompleteMain" runat="server"
  ServicePath="AutoComplete.asmx" ServiceMethod="GetTerceros" CompletionInterval="0" 
  CompletionSetCount="10" MinimumPrefixLength="1" TargetControlID="TxtNprocA" />
                            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>

            <hr />
            <asp:TextBox id="TxtFilNom" runat="server" Width="277px"> 
</asp:TextBox> </TD><TD style="WIDTH: 53px" colSpan=1></TD><TD style="WIDTH: 49px" colSpan=5>&nbsp;</TD></TR></TBODY></TABLE>&nbsp; 
<ajaxToolkit:AutoCompleteExtender id="autoComplete1" runat="server" TargetControlID="TxtFilNom" 
BehaviorID="AutoCompleteEx" CompletionInterval="0" 
CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" 
CompletionListItemCssClass="autocomplete_listitem" CompletionSetCount="20" DelimiterCharacters=";, :" 
EnableCaching="true" MinimumPrefixLength="1" ServicePath="AutoComplete.asmx" ServiceMethod="GetTerceros">
        <Animations>
                    <OnShow>
                        <Sequence>
                            
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide></Animations>
    </ajaxToolkit:AutoCompleteExtender>
                            </ContentTemplate>
                            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
