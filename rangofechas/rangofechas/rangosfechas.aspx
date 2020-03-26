<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rangosfechas.aspx.cs" Inherits="rangofechas.rangosfechas" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rangos Fechas</title>
    <script src="js/jquery.js"></script>
    <script src="js/moment.js"></script>
    <link href="css/daterangepicker.css" rel="stylesheet" />   
    <script src="js/daterangepicker.js"></script>
    <link href="css/bootstrap/bootstrap.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server" method="post" action="rangosfechas.aspx">
    <table border="0" >
        <tr>
              <th>Calendario</th>
              <th>Empresa</th>
              <th>Centro</th>
              <th>Departamento</th>
              <th>Empleados</th>
        </tr>
        <tr>
            <td><input type="text" id="Calendario" name="calendario"/></td>
            <td><input type="text" id="Empresa" name="empresa"/></td>           
            <td><input type="text" id="Centro" name="centro"/></td>
            <td><input type="text" id="Departamento" name="departamento"/></td>
            <td><input type="text" id="Empleados" name="empleados"/></td>            
        </tr>
    </table>
    <p>&nbsp;</p>
    <table border="0" >      
	  <tr>
              <th>Lunes</th>
              <th>Martes</th>
              <th>Miercoles</th>
              <th>Jueves</th>
              <th>Viernes</th>
              <th>Sabado</th>
              <th>Domingo</th>
          </tr>   
          <tr>
            <td><input type="checkbox" id="lunes" name="lunes"/></td>
            <td><input type="checkbox" id="martes" name="martes"/></td>           
            <td><input type="checkbox" id="miercoles" name="miercoles"/></td>
            <td><input type="checkbox" id="jueves" name="jueves"/></td>
            <td><input type="checkbox" id="viernes" name="viernes"/></td>
            <td><input type="checkbox" id="sabado" name="sabado"/></td>         
            <td><input type="checkbox" id="domingo" name="domingo"/></td>           
          </tr>
    </table>
    <p>&nbsp;</p>
    <table border="0">
        <tr>            
            <td>Cantidad de semanas</td>
            <td><input type="text" id="periodo" name="periodo"/></td>
         </tr>
    </table>
    <p>&nbsp;</p>
    <table border="0">
        <tr>            
            <td>Intervalo de fechas</td>
        </tr>
    </table>
    <input type="text" name="daterange"/>
<script type="text/javascript">
    $(function () {
        $('input[name="daterange"]').daterangepicker({
            opens: 'left'
        }, function (start, end, label) {
            console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
        });
    });
</script>    
    <p>&nbsp;</p> 
    <input id="submitdata" type="submit" value="submit" />
    <p>
        <asp:Label ID="lblresult" runat="server" Text="Label"></asp:Label>
        </p> 
    </form>
</body>
</html>