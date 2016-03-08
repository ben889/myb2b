<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editSeller.aspx.cs" Inherits="WebSite.admin.DesktopModules.seller.editSeller" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>编辑商家</title>
    <link href="../../css/style.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../../js/fourSelect/fourSelect.js"></script>
    <script>
        $(function () {
            if ($("#txbuname").val().length > 0) {
                $("#txbuname").attr("disabled", "disabled");
            }
        });
    </script>
    <script>
        var fourSelectData = <%=dist_json %>;

        //var fourSelectData = {
        //    "省份": {
        //        val: "", items: {
        //            "城市": {
        //                val: "", items: {
        //                    "区县": {
        //                        val: "", items: {
        //                            "乡镇": ""
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    },
        //    "北京": {
        //        val: "01", items: {
        //            "bj-01": {
        //                val: "0101", items: {
        //                    "bj-01-01县": { val: "010101", items: {} }
        //                }
        //            },
        //            "bj-02": {
        //                val: "0102", items: {
        //                    "bj-02-01县": { val: "010201", items: {} },
        //                    "bj-02-02县": { val: "010202", items: {} }
        //                }
        //            }
        //        }
        //    },
        //    "陕西": {
        //        val: "02", items: {
        //            "sx01市": {
        //                val: "0201", items: {
        //                    "sx-01-01县": { val: "020101", items: {} }
        //                }
        //            },
        //            "sx02市": {
        //                val: "0202", items: {
        //                    "sx-02-01县": {
        //                        val: "020201", items: {
        //                            "sx-02-01-01镇": "02020101",
        //                            "sx-02-01-02镇": "02020102"
        //                        }
        //                    },
        //                    "sx-02-02县": {
        //                        val: "020202", items: {
        //                            "sx-02-02-01镇": "02020201",
        //                            "sx-02-02-02镇": "02020202"
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    },
        //    "广州": { val: "03", items: {} }
        //};
        var defaults = {
            s1: 'Select1',
            s2: 'Select2',
            s3: 'Select3',
            s4: 'Select4',
            v1: "<%=ProvinceId%>",
            v2: "<%=CityId%>",
            v3: "<%=AreaId%>",
            v4: "<%=DistrictId%>"
        };
    </script>
</head>
<body>
    <div class="header">
        <h2><%=title %></h2>
    </div>
    <form id="form1" runat="server" action="editSeller.aspx" target="hd">
        <asp:HiddenField ID="HiddenFieldID" runat="server" />
        <div>
            <table cellspacing="1" cellpadding="2" border="0" class="formtable">
                <tr>
                    <td align="left" width="80">用户名：</td>
                    <td align="left">
                        <asp:TextBox ID="txbuname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        &nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <%if (id <= 0)
                  { %>
                <tr>
                    <td align="left" width="80">密码：</td>
                    <td align="left">
                        <asp:TextBox ID="txbpassword" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        &nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="left">名称：</td>
                    <td align="left">
                        <asp:TextBox ID="txbname" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        &nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <%--<tr>
                    <td align="left">类型：</td>
                    <td align="left">
                        <asp:TextBox ID="txbctype" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td align="left">商家类型：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSellerType" runat="server" CssClass="select"></asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td align="left">电话：</td>
                    <td align="left">
                        <asp:TextBox ID="txbtel" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        &nbsp;<span style="color: red;">*</span>
                    </td>
                </tr>
                <tr>
                    <td align="left">设置：</td>
                    <td align="left">
                        <asp:CheckBox ID="textislock" runat="server" Text="锁定" />
                        &nbsp;<asp:CheckBox ID="textrecommend" runat="server" Text="推荐"/>
                       <%-- <%=islock?"锁定":"正常" %>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left">排序：</td>
                    <td align="left">
                        <asp:TextBox ID="textorderby" runat="server" Width="200px" CssClass="textbox" Text="0" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">传真：</td>
                    <td align="left">
                        <asp:TextBox ID="txbfax" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">QQ：</td>
                    <td align="left">
                        <asp:TextBox ID="txbqq" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">微信：</td>
                    <td align="left">
                        <asp:TextBox ID="txbwx" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tbody style="display:none;">
                <tr>
                    <td align="left">微信二维码：</td>
                    <td align="left">
                        <%=wxqrcode %>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>

                </tbody>
                <tr>
                    <td align="left">区域：</td>
                    <td align="left">
                        <select id="Select1" name="Select1" class="select"></select>
                        <select id="Select2" name="Select2" class="select"></select>
                        <select id="Select3" name="Select3" class="select"></select>
                        <select id="Select4" name="Select4" class="select"></select>
                    </td>
                </tr>
                <tr>
                    <td align="left">地址：</td>
                    <td align="left">
                        <asp:TextBox ID="txbAddress" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">经纬度：</td>
                    <td align="left">
                        经度：<asp:TextBox ID="txblng" runat="server" Width="170px" CssClass="textbox"></asp:TextBox> 
                        &nbsp; 
                        纬度：<asp:TextBox ID="txblat" runat="server" Width="170px" CssClass="textbox"></asp:TextBox> 
                        &nbsp;&nbsp;
                        经纬度可<a href="http://api.map.baidu.com/lbsapi/getpoint/index.html" target="_blank" style="color:Red;">点击这里</a>到地图上获取
                    </td>
                </tr>
                
                <tr>
                    <td align="left">描述：</td>
                    <td align="left">
                        <asp:TextBox ID="txbDescription" runat="server" Width="640px" Height="100px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                
                <%--<tr>
                    <td align="left">所属代理商：</td>
                    <td align="left">
                        <%=CompanyControls %>
                    </td>
                </tr>--%>
                
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnsave" runat="server" Text="保存" CssClass="button save" OnClick="btnsave_Click" />
                        <input id="Button1" type="button" class="button create" value="返回" onclick="location.href = 'Seller.aspx';" />
                        <%
                            if (base.UserType == Common.enumUserType.host.ToString()
                           || base.UserType == Common.enumUserType.admin.ToString()
                           || base.UserType == Common.enumUserType.company.ToString())
                            {
                                if (id > 0)
                                { %>
                        <asp:Button ID="btnresetpass" runat="server" Text="重置密码(默认为：111111)" CssClass="button delete" OnClientClick="return confirm('确定重置密码么？');" OnClick="btnresetpass_Click" />
                        <%}
                            } %>  

                    </td>
                </tr>
            </table>
        </div>
    </form>
    <iframe name="hd" style="display: none;"></iframe>
</body>
</html>
