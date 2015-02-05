$(document).ready(function () {
    var comments;
    $.ajax({
        url: $("#comment_url").val(),
        type: "GET",
        cache:'false',
        dataType:"json",
        success:function(result){populateCommentDiv(result);}
        }
        );
});
function populateCommentDiv(data) {
   
    var div = $("#comments");
    div.html("");
    var url = $("#comment_reply_url").val();
    var add = function (html,padding,data) {
        for (var i = 0; i < data.length; i++) {
            var d = data[i];
            html += '<div class="comment" style="margin-left:'+padding+'px;">';
            html += '<p class="comment-title">Comment by ' + d.Author + '</p>';
            html += '<p class="comment-content">' + d.Content + '</p>';
            html += '<p>Created on ' + d.CreateTime + '</p>';
            html += '<a href=' + url + '&parent=' + d.Id + '>Reply</a>'
            html += '</div>';
            if (d.Children.length > 0) {
                html += add(html, padding + 20, d.Children);
            };           
        }
        return html;
    };

    var h=add("", 0, data);

  
    //for (var i = 0; i < data.length; i++) {
    //    var d = data[i];
    //    html += '<div class="comment">';
    //    html += '<p>Comment by ' + d.Author + '</p>';
    //    html += '<p>' + d.Content + '</p>';
    //    html += '<p>Created on ' + d.CreateTime + '</p>';
    //    html+='<a href='+url+'&parent='+d.Id+'>Reply</a>'
    //    html += '</div>';
    //}
    div.html(h);
};