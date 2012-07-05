$(document).ready(function () {
    localStorage.setItem("loginCliente", "off");
    localStorage.setItem("ESTADOCLIENTE", "inicio");
    /*
    Estados : 
    //inicio 
    //somos
    //login
    //detalle
    */

    //$("#inicioContent").load("/AreaReservas/Reserva/Index/1");

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "/AreaHoteles/Hotel/getHoteles",
        success: function (data) {
            var result = '<option  value = ""> - </option>';
            $.each(data, function (i, item) {
                var idhotel = item.ID;
                var descripcion = item.descripcion
                result += '<option  value = "' + idhotel + '">' + descripcion + '</option>';
            });
            $("#hotel").html(result);
        }
    });

    $('#hotel').change(function () {
        var idhotel = $('#hotel').val();
        ///AreaReservas/Reserva/Index/1
        $("#reserva").html("");
        //$("#loader").show();
        $("#reserva").load("../../AreaReservas/Reserva/Cliente/" + idhotel,
        function (responseText, textStatus, XMLHttpRequest) {
            if (textStatus == "success") {
                // all good!
                //$(".t-grid-bottom").hide();
            }
        });
    });

    $("#registrate").click(function () {
        //alert("aaa");
        init();
        $("#registrateContent").show();
    });

    $("#consumoCliente").click(function () {
        //dialogConsumo

        var ruta = "/AreaClientes/Cliente/DetalleCliente/" + localStorage.getItem("IDCLIENTE");
        $('#dialogConsumo').load(ruta);
        $('#dialogConsumo').dialog('open');
    });

    $("#registrateboton").click(function () {
      
      var jsonCliente = {
                 tipocliente: $("#tipocliente").val(),
                 nomcliente : $("#nomcliente").val(),
                 appmaterno : $("#appmaterno").val(),
                 apppaterno : $("#apppaterno").val(), 
                 emailcliente : $("#emailcliente").val(), 
                 usuariocliente : $("#usuariocliente").val(),
                 clavecliente : $("#pwdcliente").val(),
                 rscliente : $("#rscliente").val(),
                 ruccliente : $("#ruccliente").val(),
                 tipodocumento : $("#tipoDocumento").val(),
                 nrodocumento : $("#nrodocumento").val(),
        };

        $.ajax({
            type: "POST",
            data: JSON.stringify(jsonCliente),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "/AreaClientes/Cliente/registraCliente",

            success: function (data) {
                if (data.me == ""){
                    $("#textmessage").html("Usuario Registrado Correctamente");
                }else {
                    $("#textmessage").html("Ocurrio un error, al registrar");
                }
            }
        });




    });

                    
 $("#promocionesCliente").click(function () {

        var jsonLogin = {
            puntos: localStorage.getItem("PUNTOSCLIENTE")
            //puntos: 1000
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(jsonLogin),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "/AreaPromociones/Promocion/getPromociones",
            success: function (data) {
                var numpromociones = data.length;
                if (numpromociones == 0) {
                    var result = "";
                    result += '<li class = "promocion">';
                    result += '<span class = "titlepromo">' + 'No tiene puntos necesarios para las promociones!' + '</span>';
                    result += '</li>'
                    $('#dialogPromociones').html(result);
                } else {
                    var result = "<ul>";
                    for (i = 0; i < numpromociones; i++) {
                        var promocion = data[i];
                        result += '<li class = "promocion">';
                        result += '<span class = "titlepromo">' + promocion.nombre + '</span>';
                        result += '<span class = "descripcionpromo">' + promocion.descripcion + '</span>';
                        result += '<span class = "descripcionpromo"> Descuento Total: ' + promocion.descuento + '</span>';
                        result += '<span class = "descripcionpromo"> Puntos necesarios: ' + promocion.puntos_requeridos + '</span>';

                        //result += '<span class = "fecha"> Desde : ' + promocion.fecha_inicio + '- Hasta: ' + promocion.fecha_fin + '</span>';
                        result += '</li>';
                    }
                    result += '</ul>';
                    $('#dialogPromociones').html(result);
                }
            }
        });

        $('#dialogPromociones').dialog('open');

    });


    $("#detalle").click(function () {
        init();
        $("#detalleContent").show();
        return false;
    });

    $("#somos").click(function (e) {
        //e.preventdefault();
        $("#inicioContent").hide();
        $("#detalleContent").hide();
        $("#registrateContent").hide();
        $("#somosContent").show();

        return false;
    });

    function init() {
        $("#inicioContent").hide();
        $("#detalleContent").hide();
        $("#somosContent").hide();
        $("#registrateContent").hide();
    }

    $("#inicio").click(function (e) {
        //e.preventdefault();
        init();
        $("#somosContent").hide();
        $("#detalleContent").hide();
        $("#inicioContent").show();
        return false;
    });

    $("#tipocliente").change(function () {

        if ($("#tipocliente").val() == "1") {
            $("#natural").hide();
            $("#juridico").show();
        } else {
            $("#juridico").hide();
            $("#natural").show();
        }
    });

    $("#intranet").click(function (e) {
        //$("#mask").show();
        //$('.ui-widget-overlay').css("opacity : .70");
        var sape = localStorage.getItem("loginCliente");
        if (sape == "on") {
            $("#intranet").text("Intranet");
            init();
            $("#detalle").hide();
            $("#inicioContent").show();
            $("#despidete").html("Se ha cerrado la sesion correctamente, Vuelva Pronto!!");
            $("#despidete").show();
            $("#despidete").fadeOut(6000);
            localStorage.setItem("loginCliente", "off");
        } else {
            $('#formLoginCliente').each(function () {
                this.reset();
            });
            $("#explain").hide();
            $('#dialogLogin').dialog('open');
        }
        return false;
    });

    $('#dialogPromociones').dialog({
        autoOpen: false,
        resizable: false,
        draggable: false,
        width: 800,
        modal: true,
        title: "Promociones Disponibles",
        position: "center",
        buttons: {

            "Salir": function () {
                $(this).dialog("close");
            }
        }
    });


    $('#dialogLogin').dialog({
        autoOpen: false,
        resizable: false,
        draggable: false,
        width: 300,
        modal: true,
        title: "Login Cliente",
        position: "center",
        buttons: {
            "Ingresar": function () {
                var u = $("#usuario").val();
                var p = $("#password").val();
                var jsonLogin = {
                    user: u,
                    password: p
                };
                $.ajax({
                    type: "POST",
                    data: JSON.stringify(jsonLogin),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "/AreaClientes/Cliente/LoginResult",
                    success: function (data) {
                        if (data.ok == true) {
                            localStorage.setItem("loginCliente", "on");
                            localStorage.setItem("IDCLIENTE", data.cliente_id);
                            localStorage.setItem("TIPOCLIENTE", data.tipo_id);
                            localStorage.setItem("NombreCliente", data.nombre);
                            localStorage.setItem("PUNTOSCLIENTE", data.puntos);
                            $("#nombreUser").html(data.nombre);
                            init();
                            $("#intranet").html("Salir");
                            $("#detalle").show();
                            $("#detalleContent").show();
                            $("#dialogLogin").dialog("close");

                        } else {
                            $("#explain").html(data.error);
                            $("#explain").show();
                        }
                    }
                });

            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dialogConsumo').dialog({
        autoOpen: false,
        resizable: false,
        draggable: false,
        width: 800,
        modal: true,
        title: "Consumo Cliente",
        position: "center",
        buttons: {

            "Salir": function () {
                $(this).dialog("close");
            }
        }
    });


});