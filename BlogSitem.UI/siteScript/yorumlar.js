
////function YorumKaydet() {

////    var makaleId = $("#makaleID").val();
////    var yorum = $("#comment-message").val();
////    var adi = $("#adi").val();
////    $.ajax({
////        method: "POST",
////        url: "/Makale/MakaleYorum",
////        data: { "makaleId": makaleId, "yorumIcerik": yorum, "adi": adi },
////        success: function (data) {
////            if (data != null) {
////                var yorumTarihi = new Date(data.yorumTarihi);

////                var yorumBaslama = '<div class="comment"><div class="d-flex">';
////                var yorumResim = '<div class="comment-img"><img src="/template/assets/img/blog/comments-2.jpg"></div>';
////                var yorumAlani = '<div><h5><a href="">' + adi + '</a> <a href="#" class="reply"><i class="bi bi-reply-fill"></i> Yanıtla</a></h5><time datetime="' + yorumTarihi.toISOString() + '">' + yorumTarihi.toLocaleString() + '</time><p>' + data.yorum + '</p></div></div></div>';

////                $(".comment:last").append(yorumBaslama, yorumResim, yorumAlani);
////                debugger;
////            }
////        },
////        error: function () {
////        }
////    });
////    location.reload();
////};










function YorumKaydet() {

    var makaleId = $("#makaleID").val();
    var yorum = $("#comment-message").val();
    //var kullaniciId = $("#").val();
    //var altYorumId = $("#").val();


    $.ajax({
        method: "post",
        url: "/Makaleler/MakaleYorum",
        data: { "makaleId": makaleId, "yorumIcerik": yorum }
    }).done(function (data) {

        // console.log(data);
        if (data != null) {

            //var yorumAlani="<div> "+data+"  </div>"
            var yorumBasla = '<div class="comment d-flex mb - 4">';
            var yorumResim = '<div class="flex-shrink-0" ><div class="avatar avatar-sm rounded-circle"><img class="avatar-img img-fluid" src="~/template/assets/img/person-5.jpg" ></div></div>';
            var yorumAlani = '<div class="flex-grow-1 ms-2 ms-sm-3"><div class="comment-meta d-flex align-items-baseline" ><h6 class="me-2">' + data.Adi + '</h6><span class="text-muted">' + data.YorumTarihi + '</span></div><div class="comment-body">' + data.Yorum + '</div><div class="comment-replies bg-light p-3 mt-3 rounded"></div></div></div>';

            $("#yorumAlani").append(yorumBasla, yorumResim, yorumAlani);
            //yorumYerlestir.append(yorumAlani);


        }



    }).fail(function () {


    });
};