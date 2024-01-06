
function YorumKaydet() {

    var makaleId = $("#makaleID").val();
    var yorum = $("#comment-message").val();
    /*var kullanici = $("#kullaniciId").val();*/
    debugger;
    $.ajax({
        method: "post",
        url: "/Makale/MakaleYorum",
        data: { "makaleId": makaleId, "yorumIcerik": yorum }
    }).done(function (data) {
        if (data != null) {
            debugger;
            var yorumTarihi = new Date(data.yorumTarihi)
            debugger;
            var yorumBaslama = '<div class="comment"><div class="d-flex">';
            var yorumResim = '<div class="comment-img"><img src="/template/assets/img/blog/comments-2.jpg"></div>';
            var yorumAlani = '<div><h5><a href="">' + data.Adi + '</a> <a href="#" class="reply"><i class="bi bi-reply-fill"></i> Reply</a></h5><time datetime="' + yorumTarihi.toISOString() + '">' + yorumTarihi.toLocaleString() + '</time><p>' + data.Yorum + '</p></div></div></div>';

            $(".comment:last").append(yorumBaslama, yorumResim, yorumAlani);
            location.reload();
        }

    }).fail(function () {


    });
};