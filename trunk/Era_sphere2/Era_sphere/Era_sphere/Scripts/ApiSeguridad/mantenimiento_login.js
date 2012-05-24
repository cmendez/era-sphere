$(document).ready(function () {
    localStorage.clear();
    localStorage.setItem("token", "");
    $('#loginbox').hide().fadeIn(1000); /* LOGIN FADE */

    //$("#loginform form, .form").validate(); /* LOGIN VALIDATE */
    $('.ie #userbar').corner('top 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .titlebar').corner('top 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .block_cont').corner('bottom 5px'); /* IE BORDER-RADIUS FIX */
    $('.ie .error, .ie .warning, .ie .success, .ie .information').corner('5px'); /* IE BORDER-RADIUS FIX */
    //$("#loginform form, .form").validate(); /* LOGIN VALIDATE */

    
    $('#loginbutton').click(function () {
        var u = $("#usuario").val();
        //var pass = $("#password").val();
        //var parametros = '{' + '"user"' + ':"' + user + '"' + ' ,"pass"' + ':"' + pass + '"}';
        var jsonLogin = {
        user: u,
        };  
        $.ajax({
            type: "POST",
            data: JSON.stringify(jsonLogin),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "Home/LoginResult",
            success: function (data) {
                var token = data.token;
                localStorage.setItem("token", token);
                //var url = "/../../Home/Sistema";    
                //$(location).attr('href',url)
                //$(this).load("@Url.Action("/../../Home/LoginResult")");
            }
        });
    });
});