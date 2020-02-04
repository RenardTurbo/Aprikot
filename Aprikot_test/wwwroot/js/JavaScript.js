var GLOBAL_DATA = [];

$(document).ready(function () {
    var request = $.ajax({
        url: "/songs/GetSongTable",
        method: "GET"
    });
    request.done(function (data) {
        for (var i = 0; i < data.length; i++) {
            var authorsRow = "";
            for (var j = 0; j < data[i].authors.length; j++) {
                authorsRow +=data[i].authors[j].name+"; "; 
            }
            $("#table").append('<tr><td><p>' + authorsRow + '</p></td><td><p>' + data[i].album + '</p></td><td><p>' + data[i].song + '</p></td><td><p>' + data[i].year + '</p></td></tr>');
        }

        console.log(data);

    });

});

function deleteSong (id){
    let request = $.ajax({
        url: '/songs/Delete',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({songId: id}),
        
    });
    request.done( function(data){
        alert("Удалена песня с id:"+id);
        window.location.reload();
    })
}
function addAuthor(){
    let authorName = $("#authorName").val() ;
    
    let request = $.ajax({
        url: '/authors/create',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({
                "name": authorName
            }
        )
});
}

function addAlbum(){
    let albumName = $("#albumName").val();
    let albumYear = $("#albumYear").val();
    let request = $.ajax({
        url: '/albums/create',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({
                "name": albumName,
                "year": +albumYear
            }
        )
    });
}

function addSong (){
    let authorsIds = $("#authorsIds").val() ;
    let albumId = $("#albumId").val();
    let songName = $("#songName").val();

    let request = $.ajax({
        url: '/songs/create',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({
            "song":{
                "name":songName
            },
            "albumId":+albumId,
            "authorIds":authorsIds.split(';').map(authorId=>+authorId)
        }),

    });
    
}

function updateSong(id){
    let authorsIds = $(`#updateAuthors_${id}`).val() ;
    let albumName = $(`#updateAlbum_${id}`).val() ;
    let songName = $(`#updateSong_${id}`).val() ;
    let year = $(`#updateYear_${id}`).val() ;
    
    console.log( GLOBAL_DATA);
    let tableItem = GLOBAL_DATA.filter(tableItem=>tableItem.id === id)[0];
    //EDIT AUTHORS
    $.ajax({
        url: '/songs/EditAuthors',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({
            "idSong":+id,
            "IdAuthors":authorsIds.split(';').map(authorId=>+authorId)
        }),

    });
    
    //EDIT ALBUMS
    $.ajax({
        url: '/albums/EditAlbum',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({

                "Id": +tableItem.albumId,
                "Name": albumName,
                "Year": +year
    
        }),

    });
    //EDIT SONGS
    $.ajax({
        url: '/songs/EditSongName',
        method: 'post',
        contentType:"application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify({

                "Id": +id,
                "Name": songName
        }),

    });
}

$(document).ready(function () {
    var requestAuthors = $.ajax({
        url: "/authors",
        method: "GET"
    });
    var requestAlbums = $.ajax({
        url: "/albums",
        method: "GET"
    });
    
    requestAuthors.done(function (data) {
        console.log("AUTHORS:",data);
        AUTHORS = data;
    });

    requestAlbums.done(function (data) {
        console.log("ALBUMS:",data);
        ALBUMS = data;
    });
    
    var request = $.ajax({
        url: "/songs/GetSongTable",
        method: "GET"
    });
    request.done(function (data) {
        GLOBAL_DATA=data;
        for (var i = 0; i < data.length; i++) {
            var authorsRow = "";
            for (var j = 0; j < data[i].authors.length; j++) {
                authorsRow += data[i].authors[j].name + ";";
            }
            $("#table_update").append('<tr><td><input type="text" id="updateAuthors_'+data[i].id+'" value="' + authorsRow +'"/></td><td><input type="text" id="updateAlbum_'+data[i].id+'" value="' + data[i].album + '"/></td><td><input type="text" id="updateSong_'+data[i].id+'" value="' + data[i].song + '"/></td><td><input type="text" id="updateYear_'+data[i].id+'" value="' + data[i].year +'"/></td><td><input type="button" id="delete" onclick="deleteSong('+data[i].id+')" value="delete"/></td><td><button  onclick="updateSong ('+data[i].id+')">update</button></td></tr>');
        }
        $("#table_update").append('<tr><td><input type="text" value="" placeholder="authorName" id="authorName"/></td><td></td><td></td><td></td><td><input onclick="addAuthor()" type="button" id="add_author"  value="Add author+"/></td><td></td></tr>');
        $("#table_update").append('<tr><td></td><td><input type="text" value="" placeholder="albumName" id="albumName"/></td><td></td><td><input type="text" placeholder="Year" id="albumYear"></td><td><input onclick="addAlbum()" type="button" id="add_album"  value="Add album+"/></td><td></td></tr>');

        $("#table_update").append('<tr><td><input type="text" value="" placeholder="authorsIds" id="authorsIds"/></td><td><input type="text" value="" placeholder="albumId" id="albumId"/></td><td><input type="text" value="" placeholder="songName" id="songName"/></td><td></td><td><input onclick="addSong()" type="button" id="add_song"  value="Add song+"/></td><td></td></tr>');
        

        console.log(data);

    });
    
});