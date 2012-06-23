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
    $("#consumoCliente").click(function () {
        //dialogConsumo

        var ruta = "/AreaClientes/Cliente/DetalleCliente/" + localStorage.getItem("IDCLIENTE");
        $('#dialogConsumo').load(ruta);
        $('#dialogConsumo').dialog('open');
    });

    $("#promocionesCliente").click(function () {
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
        $("#somosContent").show();

        return false;
    });

    function init() {
        $("#inicioContent").hide();
        $("#detalleContent").hide();
        $("#somosContent").hide();
    }

    $("#inicio").click(function (e) {
        //e.preventdefault();
        $("#somosContent").hide();
        $("#detalleContent").hide();
        $("#inicioContent").show();
        return false;
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