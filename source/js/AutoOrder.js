var TimerForOrder; //計時器全域變數
var NowTime;

$(function() {
    Init();

    //登入
    $('#cmdLogin').on('click', function() {
        $.ajax({
            url: "AutoOrder.ashx",
            data: {
                "Login": true,
                "ddlAccount": myddlAccount
            },
            type: "GET",
            dataType: "text",
            beforeSend: function() {
                $('body').LoadingOverlay("show", {
                    image: "",
                    fontawesome: "fa fa-spinner fa-spin"
                });
            },
            success: function(req) {
                if (req == 'success') {
                    $('#lblLoginfo').css('color', '#009900');
                    $('#lblLoginfo').text('登入成功');
                    $("#cmdSure").attr('disabled', false);
                    $("#ddlAccount").attr('disabled', true);
                } else {
                    alert('登入失敗');
                }
            },
            complete: function() {
                $('body').LoadingOverlay("hide");
            },
            error: function(xhr, ajaxOptions, thrownError) {
                alert('系統錯誤登入失敗');
            }
        });
    });

    //登出
    $('#cmdLogout').on('click', function() {
        $.ajax({
            url: "AutoOrder.ashx",
            data: {
                "Logout": true
            },
            type: "GET",
            dataType: "text",
            beforeSend: function() {
                $('body').LoadingOverlay("show", {
                    image: "",
                    fontawesome: "fa fa-spinner fa-spin"
                });
            },
            success: function(req) {
                if (req == '0') {
                    $('#lblLoginfo').css('color', '#ff0000');
                    $('#lblLoginfo').text('尚未登入');
                    $("#cmdSure").attr('disabled', true);
                    $("#ddlAccount").attr('disabled', false);
                    alert('登出成功');
                } else {
                    alert('登出失敗');
                }
            },
            complete: function() {
                $('body').LoadingOverlay("hide");
            },
            error: function(xhr, ajaxOptions, thrownError) {
                alert('登出失敗');
            }
        });
    });

    //下單
    $('#cmdSure').on('click', function() {
        var myBuySell = $("input:radio:checked[name^='buy_or_sell']").val(); //買.賣
        var myFutureId = $("#future_id").val(); //商品代號
        var myPrice = $("#price").val(); //價格(6位數)
        var myAmount = $("#amount").val(); //口數(3位數)
        var myPriceType = $("input:radio:checked[name^='price_type']").val(); //市價.限價
        var myOrdtype = $("input:radio:checked[name^='ordtype']").val(); //訂單型別
        var myOcttype = $("input:radio:checked[name^='octtype']").val(); //倉別
        var myOrderTime = $("#txtOrderTime").val();
        var myTempOcttype;

        if ($.trim(myFutureId) == '') {
            alert('請輸入商品代號');
            return;
        }
        if ($.trim(myPrice) == '' || $.trim(myPrice).length != 6 || isNaN(myPrice) == true) {
            alert('請輸入價格(6位數)');
            return;
        }
        if ($.trim(myAmount) == '' || $.trim(myAmount).length != 3 || isNaN(myAmount) == true) {
            alert('請輸入口數(3位數)');
            return;
        }
        var uts = myOrderTime.split(':');
        if (isNaN(uts[0]) == true || isNaN(uts[1]) == true) {
            alert('小時或分鐘應為數字');
            return;
        }

        TempTime = new Date($('#txtTempDate').html() + ' ' + $("#txtOrderTime").val());
        NowTime = new Date();
        if (NowTime > TempTime) {
            TimeTomorrow();
        }

        // 資料確認視窗
        switch (myOcttype) {
            case "0":
                myTempOcttype = '新倉';
                break;
            case "1":
                myTempOcttype = '平倉';
                break;
            case " ":
                myTempOcttype = '自動';
                break;
            case "6":
                myTempOcttype = '當沖';
                break;
        }
        var s = '\n' + myFutureId + '\n' +
            (myBuySell == 'B' ? '買入:' : '賣出:') + myAmount + '口\n' +
            '價格: ' + myPrice + '\n' +
            (myPriceType == 'MKT' ? '市價 ' : '限價 ') + myOrdtype + ' ' + myTempOcttype + '\n\n' +
            '預計下單時間 :' + $('#txtTempDate').html() + ' ' + $("#txtOrderTime").val();
        if (!confirm('請確認資料是否正確?' + s)) return;

        // 控制項設定
        $("input").attr('disabled', true);
        s = s.replace(/\n/g, '<br>');
        $("#lblInfo").html(s);

        // 執行更新
        TimerForOrder = setInterval('StartProcess();', 1000 * 5);
    });

});

// 自動執行下單
function StartProcess() {

    UpdateTime = new Date($('#txtTempDate').html() + ' ' + $("#txtOrderTime").val());
    NowTime = new Date();

    //避免斷線問題，背景呼叫Ajax Keep 連線
    $.ajax({
        url: "AutoOrder.ashx",
        data: {
            "KeepAlive": true
        },
        type: "POST",
        dataType: "text",
        success: function(req) {
            if (req == 'KeepAlive') {
                console.log('系統保持連線中...');
            }
        },
        error: function(xhr, ajaxOptions, thrownError) {
            alert('系統連線中斷');
        }
    });

    if (NowTime > UpdateTime) {
        clearInterval(TimerForOrder);

        var myBranch = 'F002000'; //期貨分公司代號
        var myAccount = $("#ddlAccount").find(":selected").val(); //期貨帳戶
        var myBuySell = $("input:radio:checked[name^='buy_or_sell']").val(); //買.賣
        var myFutureId = $("#future_id").val(); //商品代號
        var myPrice = $("#price").val(); //價格(6位數)
        var myAmount = $("#amount").val(); //口數(3位數)
        var myPriceType = $("input:radio:checked[name^='price_type']").val(); //市價.限價
        var myOrdtype = $("input:radio:checked[name^='ordtype']").val(); //訂單型別
        var myOcttype = $("input:radio:checked[name^='octtype']").val(); //倉別
        var myOrderTime = $("#txtOrderTime").val();

        $.ajax({
            url: "AutoOrder.ashx",
            data: {
                Branch: myBranch,
                Account: myAccount,
                BuySell: myBuySell,
                FutureId: myFutureId,
                Price: myPrice,
                Amount: myAmount,
                PriceType: myPriceType,
                Ordtype: myOrdtype,
                Octtype: myOcttype
            },
            type: "GET",
            dataType: "text",
            beforeSend: function() {
                $('#div_order').LoadingOverlay("show", {
                    image: "",
                    fontawesome: "fa fa-spinner fa-spin"
                });
            },
            success: function(req) {
                //使用回傳代碼檢查交易是否正常
                if (req.indexOf('1234567') > -1) {
                    $("#lblInfo").html('<br>委託成功!');
                    // 控制項顯示
                    $("input").attr('disabled', false);
                } else {
                    $("#lblInfo").html('<br>委託異常!!    錯誤訊息如下:<br>' + req);
                }
            },
            complete: function() {
                $('#div_order').LoadingOverlay("hide");
            },
            error: function(xhr, ajaxOptions, thrownError) {
                $("#lblInfo").html('<br>下單失敗!!<br>' + xhr.status + '<br>' + thrownError);
            }
        });
    }
}

function TimeNow() {
    weekDay = new Array("日", "一", "二", "三", "四", "五", "六");

    function PadLeft(wkStr) {
        if (wkStr.toString().length == 1) { wkStr = "0" + wkStr; }
        return wkStr;
    }
    theDate = new Date();
    myYear = theDate.getFullYear();
    myMonth = theDate.getMonth() + 1;
    myDate = theDate.getDate();
    myDay = weekDay[theDate.getDay()];
    myHour = theDate.getHours();
    myMinute = theDate.getMinutes();
    mySecond = theDate.getSeconds();
    DateStr = myYear + "/" + PadLeft(myMonth) + "/" + PadLeft(myDate);
    TimeStr = PadLeft(myHour) + ":" + PadLeft(myMinute) + ":" + PadLeft(mySecond);

    document.getElementById('txtDate').innerHTML = DateStr;
    document.getElementById('txtTime').innerHTML = TimeStr;
    window.setTimeout("TimeNow();", 100);
}

function TimeTomorrow() {

    function PadLeft(wkStr) {
        if (wkStr.toString().length == 1) { wkStr = "0" + wkStr; }
        return wkStr;
    }
    theDate = new Date();
    myYear = theDate.getFullYear();
    myMonth = theDate.getMonth() + 1;
    myDate = theDate.getDate() + 1;
    DateStr = myYear + "/" + PadLeft(myMonth) + "/" + PadLeft(myDate);

    document.getElementById('txtTempDate').innerHTML = DateStr;
}

function Init() {
    $('#lblLoginfo').css('color', '#ff0000');
    $('.clockpicker').clockpicker();
    TimeNow();

    // 複製時間
    $('#txtTempDate').html($('#txtDate').html());
    $("#cmdSure").attr('disabled', true);
}