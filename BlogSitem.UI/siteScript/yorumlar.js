
function YorumKaydet() {

    var makaleId = $("#makaleID").val();
    var yorum = $("#comment-message").val();
    $.ajax({
        method: "post",
        url: "/Makale/MakaleYorum",
        data: { "makaleId": makaleId, "yorumIcerik": yorum }
    }).done(function (data) {

        // console.log(data);
        if (data != null) {

            //var yorumAlani="<div> "+data+"  </div>"
            //var yorumBasla = '<div class="comment d-flex mb - 4">';
            //var yorumResim = '<div class="flex-shrink-0" ><div class="avatar avatar-sm rounded-circle"><img class="avatar-img img-fluid" src="~/template/assets/img/person-5.jpg" ></div></div>';
            //var yorumAlani = '<div class="flex-grow-1 ms-2 ms-sm-3"><div class="comment-meta d-flex align-items-baseline" ><h6 class="me-2">' + data.Adi + '</h6><span class="text-muted">' + data.YorumTarihi + '</span></div><div class="comment-body">' + data.Yorum + '</div><div class="comment-replies bg-light p-3 mt-3 rounded"></div></div></div>';


            var yorum = ` <div class="comment">
                            <div class="d-flex">
                                <div class="comment-img"><img src="~/template/assets/img/blog/comments-2.jpg" alt=""></div>
                                <div>
                                    <h5><a href="">${data.Adi}</a> <a href="#" class="reply"><i class="bi bi-reply-fill"></i> Düzenle</a></h5>
                                    <time datetime="2020-01-01">${data.YorumTarihi}</time>
                                    <p>
                                        ${data.Yorum}
                                    </p>
                                </div>
                            </div>
                        </div>` ;


            $("#yorumAlani").append(yorum);
            //yorumYerlestir.append(yorumAlani);


        }



    }).fail(function () {


    });
};