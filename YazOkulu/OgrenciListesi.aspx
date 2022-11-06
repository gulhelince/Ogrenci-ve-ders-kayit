<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OgrenciListesi.aspx.cs" Inherits="YazOkulu.OgrenciListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table class="table table-bordered table-hover">
        <tr> <!--tr ile satır eklenir, satırın içine sütunlar eklenir-->
            <th>Öğrenci ID</th>
            <th>Öğrenci Ad</th>
            <th>Öğrenci Soyad</th>
            <th>Öğrenci Numara</th>
            <th>Öğrenci Şifre</th>
            <th>Öğrenci Fotoğraf</th>
            <th>Bakiye</th>
            <th>İşlemler</th>

        </tr>

        <tbody>
            <!--Tekrarlayıcı olarak kullanılır ,verileri listelemek için kullanılır-->
            <asp:Repeater ID="Repeater1" runat="server"> 
            <ItemTemplate> <!--öğe içeriklerini tutan yapı-->
            <tr> <!--eval=veri tabanındaki verileri çekmek için kullanılır -->
                <td><%# Eval("Id")%></td> <!--entitiydeki isimler girilir-->
                <td><%# Eval("Ad")%></td>
                <td><%# Eval("Soyad")%></td>
                <td><%# Eval("Numara")%></td>
                <td><%# Eval("Sifre")%></td>
                <td><%# Eval("Fotograf")%></td>
                <td><%# Eval("Bakiye")%></td>
                <td>
                    <!--Silme ve güncelleme işlemleri için temel yönlendirmeler-->
                    <asp:HyperLink NavigateUrl='<%#"~/OgrenciSil.aspx?ID="+ Eval("ID")%>' ID="HyperLink1" CssClass="btn btn-danger" runat="server">Sil</asp:HyperLink>
                    <asp:HyperLink NavigateUrl='<%#"~/OgrenciGüncelle.aspx?ID="+ Eval("ID")%>' ID="HyperLink2" CssClass="btn btn-success"  runat="server">Güncelle</asp:HyperLink>

                </td>
            </tr>
                </ItemTemplate>
                </asp:Repeater>
        </tbody>

    </table>
</asp:Content>
