﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UpdAdmTerceros.ascx.vb" Inherits="CtrlUsr_AdmTercero_UpdAdmTerceros" %>
<%@ Register src="AdmTercero.ascx" tagname="AdmTercero" tagprefix="uc1" %>

 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
<ContentTemplate>
            <ajaxToolkit:ModalPopupExtender ID="modalPopupCon" runat="server" 
                BackgroundCssClass="modalBackground" CancelControlID="btCerrarCon" 
                DropShadow="true" PopupControlID="pCons" 
                PopupDragHandleControlID="pCons" 
                TargetControlID="btn_Target">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pCons" runat="server" CssClass="ModalPanel2" 
                Height="229%" Width="650px">
                <asp:Panel ID="pConsT" runat="Server" CssClass="BarTitleModal2" 
                    Height="30px">
                    <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                        <div style="FLOAT: left">
                            Consulta de Terceros </div>
                        <div style="float: right">
                            <asp:Button ID="btCerrarCon" runat="server" Text="X" />
                        </div>
                    </div>
                </asp:Panel>
                <br />
                <uc1:AdmTercero ID="AdmTercero1" runat="server" />
                <br />
                <asp:Button ID="btn_Target" runat="server" style="display:none" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

