$("#btn-search-photos").unbind("click").bind("click", function () {
    var id = $("#albums").val()
    if (id == undefined || id == "")
        return;

    $.ajax({
        url: "https://localhost:44390/api/PhotoAlbums/" + id,
        contentType: 'json',
        success: function (response) {
            $("#tabla-img").empty();
            var arraysofarrays = chunkArray(response, 10);
            $.each(arraysofarrays, function (i, val) {
                var strRow = "<tr>"
                $.each(val, function (i, inval) {
                    strRow += "<td><img width='100' class='rounded float-left' src=" + inval.url + "/><button class='btn btn-outline-primary btn-sm' style='font-size: .6vw' onClick='GetComments(" + inval.id + ")'>Ver Comentarios</button></td>";
                });
                strRow += "</tr>";
                $("#tabla-img").append(strRow);
            });
        }
    })
})
function GetComments(id) {
    $.ajax({
        url: "https://localhost:44390/api/Comments/" + id,
        contentType: 'json',
        success: function (response) {
            $("#comments").empty();
            //var arraysofarrays = chunkArray(response, 10);
            $.each(response, function (i, val) {
                $("#comments").append(formatComment(val))
            });
        }
    })
}
function chunkArray(myArray, chunk_size) {
    var index = 0;
    var arrayLength = myArray.length;
    var tempArray = [];

    for (index = 0; index < arrayLength; index += chunk_size) {
        myChunk = myArray.slice(index, index + chunk_size);
        // Do something if you want with the group
        tempArray.push(myChunk);
    }

    return tempArray;
}


function formatComment(comment) {
    var comm = "<div class='be-comment'><div class='be-img-comment'></div>" +
        "<div class='be-comment-content'>" +
        "<span class='be-comment-name'>" + comment.name + "</span>" +
        "<span class='be-comment-time'>" + comment.email + "</span>" +
        "<p class='be-comment-text'>" + comment.body + "</p>" +
        "</div></div>";
    return comm;
}