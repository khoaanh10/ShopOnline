//Bấm Loại SP ra NSX
$('body').on('change', '#productOption', function () {
    
     

    var e = document.getElementById("productOption");
    var c = e.value;
  
    $.ajax({
        type: 'POST',
        data: { id: c },
        url: '/Admin/Creat1',
        success: function (ketqua) {
            $('#kqq').html(ketqua);
        }
    })
});

//Bấm ra sản phẩm sale trang admin
$('body').on('click', '#a2', function () {



 
    $.ajax({
        type: 'POST',
        data: { },
        url: '/Admin/Index1',
        success: function (ketqua) {
            $('#product').html(ketqua);
        }
    })
});
//Bấm ra tất cả SP trang admin
$('body').on('click', '#a1', function () {




    $.ajax({
        type: 'POST',
        data: {},
        url: '/Admin/Index2',
        success: function (ketqua) {
            $('#product').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a,Sort :c,b:b,type:type,max:max,min:min ,ProductTID:e},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, type: type,max:max,min:min,ProductTID:e},
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, type: type, max:max,min:min },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key:key, ProducerID: a, Sort: c, b: b, max: max, min: min, type: type, ProductTID:e },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key: key, ProducerID: a, Sort: c, b: b, page: page, max: max, min: min,type:type,ProductTID:e },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: { key:key,ProducerID: a, Sort: c, b: b, page: page, max: max, min: min, type: type, ProductTID:e },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: {key:key, ProductTID: a, Sort: c, b: b, type: type, max: max, min: min },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    $.ajax({
        type: 'POST',
        data: { key:key,ProducerID: a, Sort: c, page: d, b: b, max: max, min: min, type: type, ProductTID: e },
        url: '/Home/Product1',
        success: function (ketqua) {
            $('#ketqua').html(ketqua);
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
    if ($('#shipid').attr('data_value') == -1 | $('#billid').attr('data_value') == -1) { alert("Vui lòng thêm địa chỉ trước khi thanh toán"); }
    else if ($('#num').attr('data_value') == 5) { alert("Chỉ được thêm tối đa 5 đơn hàng 1 lần");}
    else {
       
        $.ajax({
            type: 'POST',
            data: { payment: $('input[name=payment]:checked').val(), shipID: $('#shipid').attr('data_value'), billID: $('#billid').attr('data_value'), Code: $('#Vouchercode').attr('data_value')},
            url: '/User/addOrder',
            success: function (ketqua) {

                alert("Tạo đơn hàng thành công");
                window.location.href = '/User/Order';



            }
        })
    }




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
function Search() {
    var key = $('#main-search').val();
    window.location.href = "/Home/Product?key=" + key.toString();
}
//function person(name, age) {
//    this.name = name;
//    this.age = age;
//    this.changeName = function (name) {
//        this.name = name;
//    }
//}

////Tạo đối tượng
//var p = new person("Khoa", 19);

//p.changeName("Vân");





