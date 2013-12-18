<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TreeViewUbigeEmerg.aspx.vb" Inherits="aspx_TreeViewUbigeEmerg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
			    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" 
                    ExpandDepth="1" NodeIndent="15" style="text-align: left" Width="210px">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle Font-Underline="False" 
                        HorizontalPadding="0px" VerticalPadding="0px" BackColor="#B5B5B5" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                        HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                </asp:TreeView>
			
    </div>
    </form>
</body>
</html>
