
function YorumKaydet() {

    var makaleId = $("#makaleID").val();
    var yorum = $("#comment-message").val();
    $.ajax({
        method: "POST",
        url: "/Makale/MakaleYorum",
        data: { "makaleId": makaleId, "yorumIcerik": yorum },
        success: function (data) {
            if (data != null) {
                var yorumTarihi = new Date(data.yorumTarihi);

                var yorumBaslama = '<div class="comment"><div class="d-flex">';
                var yorumResim = '<div class="comment-img"><img src="/template/assets/img/blog/comments-2.jpg"></div>';
                var yorumAlani = '<div><h5><a href="">' + data.adi + '</a> <a href="#" class="reply"><i class="bi bi-reply-fill"></i> Yanıtla</a></h5><time datetime="' + yorumTarihi.toISOString() + '">' + yorumTarihi.toLocaleString() + '</time><p>' + data.yorum + '</p></div></div></div>';

                $(".comment:last").append(yorumBaslama, yorumResim, yorumAlani);
            }
        },
        error: function () {
           
        }
    });
};