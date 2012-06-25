$(document).ready(function () {
    localStorage.clear();
    localStorage.setItem("token", "");
    var path = window.location.pathname;
    localStorage.setItem("logout", path);
    $('#loginbox').hide().fadeIn(1000); /* LOGIN FADE */
    $('.ie #userbar').corner('top 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .titlebar').corner('top 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .block_cont').corner('bottom 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .error, .ie .warning, .ie .success, .ie .information').corner('5px'); /* IE BORDER-RADIUS FIX */

    $('#loginbutton').click(function () {
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
            url: "/AreaEmpleados/Empleado/LoginResult",
            success: function (data) {
                if (data.length == 0) {
                    $("#explain").html("Usuario o Clave incorrecto");
                } else {
                    var login = data[0];
                    var idusuario = login.ID;
                    var idperfil = login.perfilID;
                    //nos jalamos el idperfil
                    localStorage.setItem("usuario", login.nombre);
                    localStorage.setItem("idusuario", idusuario);
                    localStorage.setItem("Hotel", login.hotelID);
                    localStorage.setItem("perfil", idperfil);
                    var entrada = {
                        perfilID: idperfil
                    };
                    $.ajax({
                        type: "POST",
                        data: JSON.stringify(entrada),
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        url: "/AreaConfiguracion/Perfiles/DamePerfil",
                        success: function (data) {
                            var np = data.nombrePerfil;
                            var token = data.listaVisibilidad;
                            localStorage.setItem("token", token);
                            localStorage.setItem("nombrePerfil", np);
                            var url = "/Home/Sistema";
                            $(location).attr('href', url);
                        }
                    });
                }

                /*
                var token = data.token;
                if (token == "")
                $("#explain").html("Usuario o Clave incorrecto");
                else {
                localStorage.setItem("token", token);
                var url = "/Home/Sistema";
                $(location).attr('href', url);
                localStorage.setItem("usuario", u);
                //$(this).load("@Url.Action("/../../Home/LoginResult")");
                }
                */
            }
        });
    });
});