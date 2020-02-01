$(document).ready(function () {
    var request = $.ajax({
        url: "https://localhost:44372/songs/GetSongTable",
        method: "GET"
    });
    request.done(function (data) {
        for (var i = 0; i < data.length; i++) {
            var authorsRow = "";
            for (var j = 0; j < data[i].authors.length; j++) {
                authorsRow +=data[i].authors[j]+"; "; 
            }
            $("#table").append('<tr><td><p>' + authorsRow + '</p></td><td><p>' + data[i].album + '</p></td><td><p>' + data[i].song + '</p></td><td><p>' + data[i].year + '</p></td></tr>');
        }

        console.log(data);

    });

});

$(document).ready(function () {
    var request = $.ajax({
        url: "https://localhost:44372/songs/GetSongTable",
        method: "GET"
    });
    request.done(function (data) {
        for (var i = 0; i < data.length; i++) {
            var authorsRow = "";
            for (var j = 0; j < data[i].authors.length; j++) {
                authorsRow += data[i].authors[j] + "; ";
            }
            $("#table_update").append('<tr><td><input type="text" value="' + authorsRow +'"/></td><td><input type="text" value="' + data[i].album + '"/></td><td><input type="text" value="' + data[i].song + '"/></td><td><input type="text" value="' + data[i].years +'"/></td><td><input type="button" id="delete" onclick="alert()" value="delete"/></td><td><button>update</button></td></tr>');
        }

        

        console.log(data);

    });

});