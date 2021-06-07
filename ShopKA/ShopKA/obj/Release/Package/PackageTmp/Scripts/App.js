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
    run_waitMe('#cartmini');
    run_waitMesm('#countcart');
    run_waitMe('#Pricetotal');
    run_waitMe('#Cartpage');

        $.ajax({
            type: 'POST',
            data: { ID: d},
            url: '/Home/DeleteCartmini',
            success: function (ketqua) {
                $('#cartmini').html(ketqua);
                stop_waitMe('#cartmini');
                
            }
        })

        
        $.ajax({
            type: 'POST',
            data: {},
            url: '/Home/CountCart',
            success: function (ketqua) {
                $('#countcart').html(ketqua);
                stop_waitMe('#countcart');

            }
        })
        $.ajax({
            type: 'POST',
            data: {},
            url: '/Home/Cart1',
            success: function (ketqua) {
                $('#Cartpage').html(ketqua);
                stop_waitMe('#Cartpage');


            }
        })

        $.ajax({
            type: 'POST',
            data: {},
            url: '/Home/Pricetotal',
            success: function (ketqua) {
                $('#Pricetotal').html(ketqua);
                stop_waitMe('#Pricetotal');

            }
        })

       



});


$('#ok2').on('click', function () {
    debugger;
    run_waitMe('#app');
    var SLSP = $('#SLSP').attr('data_value');
    if (SLSP == 0) {
        stop_waitMe('#app');
        $.iaoAlert({
            msg: "Không có SP nào trong đơn hàng",
            type: "warning",
            mode: "dark",
        });
        
        
    }
    else if ($('#dk').is(':checked')) {
        
        if ($('#shipid').attr('data_value') == -1 | $('#billid').attr('data_value') == -1) {
            stop_waitMe('#app'); $.iaoAlert({
                msg: "Thêm địa chỉ trước khi thanh toán",
                type: "warning",
                mode: "dark",
            });  }
        else if ($('#num').attr('data_value') == 5) {
            stop_waitMe('#app'); $.iaoAlert({
                msg: "Chỉ được thêm tối đa 5 đơn hàng",
                type: "warning",
                mode: "dark",
            }); }
        else {

            $.ajax({
                type: 'POST',
                data: { payment: $('input[name=payment]:checked').val(), shipID: $('#shipid').attr('data_value'), billID: $('#billid').attr('data_value'), Code: $('#Vouchercode').attr('data_value') },
                url: '/User/addOrder',
                success: function (ketqua) {
                    stop_waitMe('#app');
                    $.iaoAlert({
                        msg: "Tạo đơn hàng thành công",
                        type: "success",
                        mode: "light",
                    })
                    
                    window.location.href = '/User/Order';
                    
                   
                    
                    


                }
            })
        }
    }
    else {
        stop_waitMe('#app');
        $.iaoAlert({
            msg: "Vui lòng chấp nhận các điều khoản",
            type: "warning",
            mode: "dark",
        });}




});
$('.checkSTT').on('click', function () {
    run_waitMe('#Pricetotal');
    run_waitMe('#cartmini');
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
            stop_waitMe('#Pricetotal');

        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/DeleteCart2',
        success: function (ketqua) {
            $('#cartmini').html(ketqua);
            stop_waitMe('#cartmini');

        }
    })





});
$('.checkSTT2').on('click', function () {
    run_waitMe('#total');
    run_waitMe('#Pricetotal');
    run_waitMe('#Cartpage');

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
            stop_waitMe('#Pricetotal');

        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/total',
        success: function (ketqua) {
            $('#total').html(ketqua);
            stop_waitMe('#total');

        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/Cart1',
        success: function (ketqua) {
            $('#Cartpage').html(ketqua);
            stop_waitMe('#Cartpage');

        }
    })
    
    
    





});

$('.colorP2').on('click', function () {
    var d = $(this).attr('value');
    var a = $(this).attr('data_value');
    run_waitMe('#quantity-' + a.toString());
    $.ajax({
        type: 'POST',
        data: { ID: d },
        url: '/Home/ColorQuantity',
        success: function (ketqua) {
            $('#quantity-' + a.toString()).html(ketqua);
            stop_waitMe('#quantity-' + a.toString());
        }
    })
});

function addCart(p) {
    stop_waitMe('.modal1id-' + p.toString());
    $('#pd-'+p.toString()).modal('hide');
    $.iaoAlert({
        msg: "Đã thêm vào giỏ hàng",
        type: "success",
        mode: "light",
    })
    run_waitMesm('#countcart');
    
    $.ajax({
        type: 'POST',
        data: { },
        url: '/Home/CountCart',
        success: function (ketqua) {
            $('#countcart').html(ketqua);
            stop_waitMe('#countcart');
            

        }
    })


}

$('.addcartindex').on('click', function () {
    run_waitMesm('#countcart');
    var color = parseInt($(this).attr('data_value2'));
    var a = { ColorID: color, Quantity: 1 };
    var b = $(this).attr('data_value');
    
    run_waitMe('.modal2id-' + b.toString());
    
    run_waitMesm('#tbb-' + b);
    $.ajax({
        type: 'POST',
        data: { a:a },
        url: '/Home/AddCart',
        success: function (ketqua) {
            $('#cartmini').html(ketqua);
            stop_waitMe('.modal2id-' + b.toString());
        }
    })

    $.ajax({
        type: 'POST',
        data: { },
        url: '/Home/TB',
        success: function (ketqua) {
            $('#tbb-'+b).html(ketqua);
            stop_waitMe('#tbb-' + b);
        }
    })
    $.ajax({
        type: 'POST',
        data: {},
        url: '/Home/CountCart',
        success: function (ketqua) {
            $('#countcart').html(ketqua);
            stop_waitMe('#countcart');
        }
    })

});

$('.addWishList').on('click', function () {

    
    
    var ID = $(this).attr('data_value');
    run_waitMesm('.wish-' + ID);
    $.ajax({
        type: 'POST',
        data: { ID: ID },
        url: '/Home/addWishList',
        success: function (ketqua) {
            stop_waitMe('.wish-' + ID);
            
            
        }
    })
    $.iaoAlert({
        msg: "Đã thêm vào yêu thích",
        type: "success",
        mode: "light",
    })
});
$('.addWish').on('click', function () {
    
    var ID = $(this).attr('data_value');
    run_waitMesm('.wish2-' + ID);
    $.ajax({
        type: 'POST',
        data: { ID: ID },
        url: '/Home/addWishList',
        success: function (ketqua) {
            
            stop_waitMe('.wish2-' + ID);

        }
    })
    $.iaoAlert({
        msg: "Đã thêm vào yêu thích",
        type: "success",
        mode: "light",
    })


});
function Search() {
    var key = $('#main-search').val();
    window.location.href = "/Home/Product?key=" + key.toString();
}




//$(container).waitMe("hide");
function run_waitMe(a) {
    console.log(a);
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
function run_waitMesm(a) {
    console.log(a);
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
        maxSize: '20',

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

$("#demo-1").click(function () {
    $.iaoAlert()
});
$("#demo-2").click(function () {
    $.iaoAlert({
        msg: "Dark Theme",
        type: "notification",
        mode: "dark",
    })
});
$("#demo-3").click(function () {
    $.iaoAlert({
        msg: "Success + Light Theme",
        type: "success",
        mode: "light",
    })
});
$("#demo-4").click(function () {
    $.iaoAlert({
        msg: "Error + Dark Theme",
        type: "error",
        mode: "dark",
    })
});
$("#demo-5").click(function () {
    $.iaoAlert({
        msg: "Warning + Dark Theme",
        type: "warning",
        mode: "dark",
    })
});

text_truncate = function (str, length, ending) {
    if (length == null) {
        length = 100;
    }
    if (ending == null) {
        ending = '...';
    }
    if (str.length > length) {
        return str.substring(0, length - ending.length) + ending;
    } else {
        return str;
    }
};