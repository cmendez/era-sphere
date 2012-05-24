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
            url: "Home/LoginResult",
            success: function (data) {
                var token = data.token;
                if (token == "")
                    $("#explain").html("Usuario o Clave incorrecto");
                else {
                    localStorage.setItem("token", token);
                    var url = "/Home/Sistema";
                    $(location).attr('href', url)
                    //$(this).load("@Url.Action("/../../Home/LoginResult")");
                }
            }
        });
    });
});