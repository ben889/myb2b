<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebSite.admin.index" %>

<%@ Register Assembly="WebControls" Namespace="WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/skin.css" rel="stylesheet" />
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="menu.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            bindmenu();

        });    
    </script>
</head>
<body>
    <div class="header">
        <div class="header-box">
            <h1 class="logo"><span style="font-size:12px;"></span>
            </h1>
            <div class="nav">
                <%--<ul>
                    <li class=""><i class="icon-0"></i><span>内容</span></li>
                    <li class="selected"><i class="icon-1"></i><span>会员</span></li>
                    <li><i class="icon-2"></i><span>订单</span></li>
                    <li><i class="icon-3"></i><span>界面</span></li>
                    <li><i class="icon-4"></i><span>控制面板</span></li>
                </ul>--%>
                <div id="menu">
                </div>
            </div>
            <div class="nav-right">
                <%--<div class="icon-info">
                    <span></span>
                </div>--%>
                <div class="user">
                    <ul class="icon-nav">
                        <li style="margin-right: 10px;"><a href="/mob/" target="_blank" title="打开首页" class="icon-home">&nbsp;</a></li>
                        <li>您好，<%=base.UserName %> <%=rolenamestr %></li>

                        <li><a href="loginout.aspx" target="_self" title="退出" onclick="return confirm('确定退出吗？');"><i class="icon-signout"></i>退出</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <!--左部菜单-->
    <div class="main-sidebar">
        <div style="height: 0px;">
        </div>
        <div id="submenu-top">
        </div>
        <div id="submenu">
            <%--<ul>
                <li><a href="DesktopModules/Product/productlist.aspx" id="11" target="mainframe">产品</a><ul>
                    <li><a href="DesktopModules/Product/productlist.aspx" id="111" target="mainframe">产品</a></li>
                    <li><a href="DesktopModules/Product/producttype.aspx" id="112" target="mainframe">产品分类</a></li>
                </ul>
                </li>
                <li><a href="DesktopModules/Order/order.aspx" id="12" target="main">订单</a></li>
            </ul>--%>
        </div>
    </div>
    <!--内容-->
    <div class="main-container">
        <iframe id="mainframe" name="mainframe" allowtransparency="true" src="" border="0"
            frameborder="0" framespacing="0" marginheight="0" marginwidth="0" style="width: 100%; height: 100%; position: absolute;"></iframe>
    </div>
</body>
</html>
