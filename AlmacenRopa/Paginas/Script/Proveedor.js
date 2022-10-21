//Definir el código para garantizar que siempre se ejecute después de cargar todo el html
$(document).ready(function () {
    //Código para responder al evento click del: btnRegistrar
    $("#btnRegistrar").click(function () {
        ProcesarProveedor("Insertar");
    });
    $("#btnActualizar").click(function () {
        ProcesarProveedor("Actualizar");
    });
    $("#btnEliminar").click(function () {
        ProcesarProveedor("Eliminar");
    });
    $("#btnConsultar").click(function () {
        ProcesarProveedor("Consultar");
    });
});
function ProcesarProveedor(Comando) {
    var Nit = $("#txtNit").val();
    var Nombre = $("#txtNombre").val();
    var Productos = $("#cboProductos").val();
    var Telefono = $("#txtTelefono").val();
    var CorreoElectronico = $("#txtCorreo").val();
    var SitioWeb = $("#txtSitioWeb").val();
    
    var DatosProveedor = {
        Nit: Nit,
        Nombre: Nombre,
        Productos: Productos,
        Telefono: Telefono,
        CorreoElectronico: CorreoElectronico,
        SitioWeb: SitioWeb,
        Mensaje: Comando
    }

    //Se genera el ajax para enviar los datos al servidor
    $.ajax({
        type: "POST",
        url: "../Controladores/ControladorProveedor.ashx",
        contentType: "json",
        data: JSON.stringify(DatosProveedor),
        success: function (RptaProveedor) {
            //Crea un objeto de json con la respuesta del servidor
            var Proveedor = JSON.parse(RptaProveedor);
            if (Proveedor.Mensaje == "SI") {
                $("#dvMensaje").addClass("alert alert-success");             
                if (Comando == "Consultar") {
                    //Debe presentar los datos del cliente en la tabla
                    //JSON.parse, convierte el texto de respuesta que viene en formato json
                    //como un objeto de javascript
                    $("#txtNombre").val(Proveedor.Nombre);
                    $("#cboProductos").val(Proveedor.Productos);
                    $("#txtTelefono").val(Proveedor.Telefono);
                    $("#txtCorreo").val(Proveedor.CorreoElectronico);
                    $("#txtSitioWeb").val(Proveedor.SitioWeb);
                }
            }
            else {
                $("#dvMensaje").addClass("alert alert-danger");
                if (Comando == "Consultar") {
                    //Debe presentar los datos del cliente en la tabla
                    //JSON.parse, convierte el texto de respuesta que viene en formato json
                    //como un objeto de javascript
                    $("#txtNombre").val("");
                    $("#cboProductos").val("Camisas");
                    $("#txtTelefono").val("");
                    $("#txtCorreo").val("");
                    $("#txtSitioWeb").val("");
                }
            }
            $("#dvMensaje").html(Proveedor.Error);
        },
        error: function (RptaError) {
            $("#dvMensaje").html("Error: " + RptaError);
            
        }
    });
}
