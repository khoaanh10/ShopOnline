//Modal waiting


//Bấm Loại SP ra NSX
$('body').on('change', '#productOption', function () {
    
    run_waitMe('.loadNSX');
    
    var e = document.getElementById("productOption");
    var c = e.value;
  
    $.ajax({
        type: 'POST',
        data: { id: c },
        url: '/Admin/Creat1',
        success: function (ketqua) {
            stop_waitMe('.loadNSX');
            $('#kqq').html(ketqua);
           
        }
    })
});



//đổi số sản phẩm dc show ra
$('body').on('change', '#show', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var type = $('#Type').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a,Sort :c,b:b,type:type,max:max,min:min ,ProductTID:e,rate:rate},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })
});
//đổi kiểu sắp xếp
$('body').on('change', '#sort', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var type = $('#Type').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var e = $('#ProductTID').attr('data_value'); 
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, type: type,max:max,min:min,ProductTID:e,rate:rate},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })
});
//đổi nsx
$('.Producer').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $(this).attr('data_value');
    var type = $('#Type').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, type: type, max:max,min:min,rate:rate },
        url: '/Home/Product1',
        success: function (ketqua) {

            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })
   

});
//Phân trang ajax

//Tìm SP theo giá sản phẩm
$('#price').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var type = $('#Type').attr('data_value');
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, max: max, min: min, type: type, ProductTID:e,rate:rate },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })


});
//Xếp theo rate
$('.rating__check').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var type = $('#Type').attr('data_value');
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: { key: key, ProducerID: a, Sort: c, b: b, max: max, min: min, type: type, ProductTID: e, rate: rate },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })


});
//Kiểu hiện thị Grid
$('#Grid').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var type = document.getElementById("Grid").id;
    var page = $('#pagenumber').attr('data_value');
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key: key, ProducerID: a, Sort: c, b: b, page: page, max: max, min: min,type:type,ProductTID:e ,rate:rate},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })


});
//Kiểu hiện thị List
$('#List').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var type = document.getElementById("List").id;
    var page = $('#pagenumber').attr('data_value');
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: { key:key,ProducerID: a, Sort: c, b: b, page: page, max: max, min: min, type: type, ProductTID:e,rate:rate },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })


});
//Xem theo loại SP
$('.ProductTID').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    
    var type = $('#Type').attr('data_value');
    var max = document.getElementById("max").value;
    var min = document.getElementById("min").value;
    var a = $(this).attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: {key:key, ProductTID: a, Sort: c, b: b, type: type, max: max, min: min,rate:rate },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })


});

$('.page').on('click', function () {
    var b = document.getElementById("show").value;
    var c = document.getElementById("sort").value;
    var a = $('#ProducerID').attr('data_value');
    var d = $(this).attr('data_value');
    var max = $('#max').value;
    var min = $('#min').value;
    var type = $('#Type').attr('data_value');
    var e = $('#ProductTID').attr('data_value');
    var key = $('#key').attr('data_value');
    var rate = $('input[name=rate1]:checked').val();
    run_waitMe('#ketqua');
    $.ajax({
        type: 'POST',
        data: { key:key,ProducerID: a, Sort: c, page: d, b: b, max: max, min: min, type: type, ProductTID: e ,rate:rate},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
            stop_waitMe('#ketqua');
        }
    })




});

$('.Deletecartmini').on('click', function () {
        var d = $(this).attr('data_value');
        
        $.ajax({
            type: 'POST',
            data: { ID: d},
            url: '/Home/DeleteCartmini',
            success: function (ketqua) {
                $('#cartmini').html(ketqua);
               
                
            }
        })

        $.ajax({
            type: 'POST',
            data: { },
            url: '/Home/Cart1',
            success: function (ketqua) {
                $('#Cartpage').html(ketqua);
                alert("Đã xóa");

            }
        })

        $.ajax({
            type: 'POST',
            data: {},
            url: '/Home/CountCart',
            success: function (ketqua) {
                $('#countcart').html(ketqua);


            }
        })
        $.ajax({
            type: 'POST',
            data: {},
            url: '/Home/Pricetotal',
            success: function (ketqua) {
                $('#Pricetotal').html(ketqua);


            }
        })

       



});


$('#ok2').on('click', function () {
    
    if ($('#dk').is(':checked')) {
        run_waitMe('#app')
        if ($('#shipid').attr('data_value') == -1 | $('#billid').attr('data_value') == -1) { stop_waitMe('#app');alert("Vui lòng thêm địa chỉ trước khi thanh toán");  }
        else if ($('#num').attr('data_value') == 5) { stop_waitMe('#app');alert("Chỉ được thêm tối đa 5 đơn hàng 1 lần"); }
        else {

            $.ajax({
                type: 'POST',
                data: { payment: $('input[name=payment]:checked').val(), shipID: $('#shipid').attr('data_value'), billID: $('#billid').attr('data_value'), Code: $('#Vouchercode').attr('data_value') },
                url: '/User/addOrder',
                success: function (ketqua) {
                    stop_waitMe('#app');
                    alert('Tạo đơn hàng thành công');
                    window.location.href = '/User/Order';
                   
                    
                    


                }
            })
        }
    }
    else { alert("Vui long chấp nhận các điều khoản");}




});
$('.checkSTT').on('click', function () {

    if ($(this).is(':checked')) {
        var check = true;
    }
    else { var check = false; }
    var ID = $(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { check: check, ID:ID},
        url: '/Home/changecheck',
        success: function (ketqua) {
            $('#Pricetotal').html(ketqua);
            

        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/DeleteCart2',
        success: function (ketqua) {
            $('#cartmini').html(ketqua);


        }
    })





});
$('.checkSTT2').on('click', function () {

    if ($(this).is(':checked')) {
        var check = true;
    }
    else { var check = false; }
    var ID = $(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { check: check, ID: ID },
        url: '/Home/changecheck',
        success: function (ketqua) {
            $('#Pricetotal').html(ketqua);


        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/total',
        success: function (ketqua) {
            $('#total').html(ketqua);


        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/Cart1',
        success: function (ketqua) {
            $('#Cartpage').html(ketqua);


        }
    })





});

$('.colorP2').on('click', function () {
    var d = $(this).attr('value');
    var a = $(this).attr('data_value');

    $.ajax({
        type: 'POST',
        data: { ID: d },
        url: '/Home/ColorQuantity',
        success: function (ketqua) {
            $('#quantity-' + a.toString()).html(ketqua);
        }
    })
});

$('.ok3').on('click', function () {
    alert("Đã thêm thành công");
    var id1 = $(this).attr('data_value');
    var ID = $('.colorP-'+id1.toString()).attr('value');
    $.ajax({
        type: 'POST',
        data: { ID: ID },
        url: '/Home/CountCart2',
        success: function (ketqua) {
            $('#countcart').html(ketqua);

        }
    })


});
$('.addcartindex').on('click', function () {

    var color = parseInt($(this).attr('data_value2'));
    var a = { ColorID: color, Quantity: 1 };
    var b =$(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { a:a },
        url: '/Home/AddCart',
        success: function (ketqua) {
            $('#cartmini').html(ketqua);
           
        }
    })

    $.ajax({
        type: 'POST',
        data: { },
        url: '/Home/TB',
        success: function (ketqua) {
            $('#tbb-'+b).html(ketqua);

        }
    })
    $.ajax({
        type: 'POST',
        data: { ID: color },
        url: '/Home/CountCart2',
        success: function (ketqua) {
            $('#countcart').html(ketqua);

        }
    })

});
$('.addcartindex2').on('click', function () {

    var color = parseInt($(this).attr('data_value2'));
    var a = { ColorID: color, Quantity: 1 };
    var b = $(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { a: a },
        url: '/Home/AddCart',
        success: function (ketqua) {
            $('#cartmini').html(ketqua);
            alert('Đã thêm vào giỏ hàng');
        }
    })

    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/TB',
        success: function (ketqua) {
            $('#tbb-' + b).html(ketqua);

        }
    })
    $.ajax({
        type: 'POST',
        data: { ID: color },
        url: '/Home/CountCart2',
        success: function (ketqua) {
            $('#countcart').html(ketqua);

        }
    })

});
$('.addWishList').on('click', function () {

    
    
    var ID = $(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { ID: ID },
        url: '/Home/addWishList',
        success: function (ketqua) {
            alert("Đã thêm vào yêu thích");

        }
    })
});
$('.addWish').on('click', function () {

    var ID = $(this).attr('data_value');
    $.ajax({
        type: 'POST',
        data: { ID: ID },
        url: '/Home/addWishList',
        success: function (ketqua) {
            alert("Đã thêm vào yêu thích");

        }
    })


});
function Search() {
    var key = $('#main-search').val();
    window.location.href = "/Home/Product?key=" + key.toString();
}




//$(container).waitMe("hide");
function run_waitMe(a) {
    
    $(a).waitMe({

        //none, rotateplane, stretch, orbit, roundBounce, win8, 
        //win8_linear, ios, facebook, rotation, timer, pulse, 
        //progressBar, bouncePulse or img
        effect: 'bounce',

        //place text under the effect (string).
        text: '',

        //background for container (string).
        bg: 'rgba(255,255,255,0.7)',

        //color for background animation and text (string).
        color: '#000',

        //max size
        maxSize: '',

        //wait time im ms to close
        waitTime: -1,

        //url to image
        source: '',

        //or 'horizontal'
        textPos: 'vertical',

        //font size
        fontSize: '',

        // callback
        onClose: function () { }

    });
}
function stop_waitMe(a) {
    var a2 = a.toString();
    $(a2).waitMe('hide');
}

