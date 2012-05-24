$(document).ready(function () {
    var token = localStorage.getItem("token");
    if (token == null) {
        alert("No seas Rata");
        nsp_redirect()
    } else if (token == "") {
        alert("No seas Rata");
        nsp_redirect();
    } else {
        arma_menu(token);
    }

    var path = window.location.pathname;
    localStorage.setItem("logout", path);

    function arma_menu(token) {
        var t = localStorage.getItem("token");
        var jsonMenu = {
         token: t,
        }; 
        $.ajax({
            type: "POST", 
            data: JSON.stringify(jsonMenu), 
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "../Navegacion/ListaMenu", 
            success: function (data) {
                 var result = "";
                 $.each(data, function (i, item) {
                    var nombre = item.Nombre;
                    var url = item.Url;
                    var icono = item.Icono;
                    result += '<li> <a href = "'+url+'" id ="menu-' + i + '" class = "' + icono + '">' + nombre + '</a>';
                    var sl = item.Sublinks;
                    if (sl.length > 0) result += "<ul>"
                    
                    for (j = 0; j < sl.length; j++){
                        result += '<li> <a href = "'+sl[j].Url+'" id ="menu-' + i + '-' + j + '">' + sl[j].Nombre + '</a>';
                    }
                    if (sl.length > 0) result += "</ul>"
                    result += "</li>";
                });
                $('#navigation').html(result);
            }
        });

    }

    $('#salir').click(function(){
        nsp_redirect() 
    });
    
    function nsp_redirect() {
        var url = "";
        var path = window.location.pathname;
        var algo = (localStorage.getItem("logout")).split("/");
       for (j = 0; j < algo.length; j++)  url += "/..";
        $(location).attr('href', url)
    }
});