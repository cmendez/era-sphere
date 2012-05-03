$(document).ready(function () {

    $('#fecha_nacimiento_date').datepicker();

    $('.checkboxui, .radioui').buttonset();

    $('#slider').slider({ values: [20, 50], range: true });

    $('#tipo_cliente').change(
            function () {
                $('#cliente_natural_form , #cliente_juridico_form').hide();
                $('#cliente_' + $(this).find('option:selected').attr('value') + '_form').show("slow");
            }
        );

    $("#pruebaGET").click(function () {

        $.ajax({
            type: "GET",
            url: "ApiCliente/Cliente",
            success: function (data) {
                var cont = data.length;
                var rpta = "";
                for (i = 0; i < cont; i++) {
                    var idcliente = data[i].IdCliente;
                    var dni = data[i].Dni;
                    var ruc = data[i].Ruc;
                    var nombre = data[i].Nombre;
                    var tipo = dni ? "Natural" : "Juridico";
                    var estado = data[i].Estado;

                    rpta += formaData(idcliente, nombre, dni ? dni : ruc, tipo, estado);
                }
                $("#responseData").html(rpta);
            }
        });

        $("#responseData").html(rpta);
        repaintAcciones();

    });


    function formaData(id, nombre, documento, tipo, estado) {
        var respuesta = "";
        respuesta += "<tr " + 'id = "cliente' + id + '"' + ">";
        respuesta += '<td> <input type ="' + 'checkbox" name = "check" value = "-" </td>';
        respuesta += '<td>' + nombre + '</td>';
        respuesta += '<td>' + documento + '</td>';
        respuesta += '<td>' + tipo + '</td>';
        respuesta += '<td>' + estado + '</td>';
        respuesta += '<td><div style="height: 3px;">&nbsp;</div><div class="actionbar"><a id = "ver" class="action view"><span>View</span></a><a id = "editar" class="action edit"><span>Edit</span></a><a id = "eliminar" class="action delete"><span>Delete</span></a></div></td>';
        respuesta += '</tr>';
        return respuesta;
    }




    $("#pruebaPOST").click(function () {


    });


    $("#pruebaPUT").click(function () {


    });


    $("#pruebaUPDATE").click(function () {

    });


    function repaintAcciones() {
        $("#mostrar").click(function () {

        });

        $("#ver").click(function () {
            alert("viendo");
        });

        $("#editar").click(function () {
            alert("Editanto");
        });

        $("#eliminar").click(function () {
            alert("Eliminando");
        });

    }


});