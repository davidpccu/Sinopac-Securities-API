<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoOrder.aspx.cs" Inherits="WebApplication1.AutoOrder" %>

    <!DOCTYPE html>

    <html>

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>永豐自動化下單系統</title>
        <link title="Style" rel="stylesheet" type="text/css" href="/css/main.css">
        <link title="Style" rel="stylesheet" type="text/css" href="/css/jquery-clockpicker.min.css">
        <script src="https://code.jquery.com/jquery-1.11.3.min.js"></script>
        <script src="/js/AutoOrder.js"></script>
        <script src="/js/loadingoverlay.min.js"></script>
        <script src="/js/jquery-clockpicker.min.js"></script>
    </head>

    <body>
        <div>
            <table cellspacing="0" cellpadding="4" border="0" width="560" align="center" border="0">
                <tr>
                    <td>
                        <table class="SearchBox" cellspacing="0" cellpadding="4" border="0" width="100%" align="center" border="0">
                            <tr>
                                <td>
                                    <table class="Search" scellspacing="0" cellpadding="4" border="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td style="text-align: left">API下單系統 -
                                                <span id="lblLoginfo">尚未登入</span>
                                            </td>
                                            <td style="text-align: right">
                                                <input id="cmdLogin" class="Button" type="button" value="登入"><input id="cmdLogout" class="Button" type="button" value="登出">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table cellspacing="0" cellpadding="2" border="0" width="560" align="center" border="0">
                <tr>
                    <td>
                        <table class="SearchBox" cellspacing="0" cellpadding="2" border="0" width="100%" align="center" border="0" style="background-color: orangered">
                            <tr>
                                <td>
                                    <table class="Search" scellspacing="0" cellpadding="4" border="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td style="text-align: left; width: 200px;">
                                                <span id="txtDate" class="day"></span>
                                            </td>
                                            <td style="text-align: left">
                                                <span id="txtTime" class="time"></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div>
                                                    排程下單清單:
                                                </div>
                                                <div id="lblInfo">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div id="div_order">
            <table cellspacing="0" cellpadding="2" border="0" width="560" align="center" border="0">
                <tr>
                    <td>
                        <table class="SearchBox" cellspacing="0" cellpadding="2" border="0" width="100%" align="center" border="0" style="background-color: lightskyblue">
                            <tr>
                                <td>
                                    <table class="Search" scellspacing="0" cellpadding="4" border="0" width="100%" align="center" border="0">
                                        <tr>
                                            <td style="text-align: left; width: 200px;">期貨分公司代號
                                            </td>
                                            <td style="text-align: left">
                                                <span>F002000</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">期貨帳戶
                                            </td>
                                            <td style="text-align: left">
                                                <select id="ddlAccount">
                                                  <option value ="1234567" selected>1234567</option>
                                                  <option value ="7654321">7654321</option>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">買/賣
                                            </td>
                                            <td style="text-align: left">
                                                <input name="buy_or_sell" type="radio" checked="true" value="B">買
                                                <input name="buy_or_sell" type="radio" value="S">賣
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">商品代號
                                            </td>
                                            <td style="text-align: left">
                                                <input id="future_id" type="text">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">價格(6位數)
                                            </td>
                                            <td style="text-align: left">
                                                <input id="price" type="text">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">口數(3位數)
                                            </td>
                                            <td style="text-align: left">
                                                <input id="amount" type="text">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">市價/限價
                                            </td>
                                            <td style="text-align: left">
                                                <input name="price_type" type="radio" checked="true" value="MKT">市價
                                                <input name="price_type" type="radio" value="LMT">限價
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">訂單型別
                                            </td>
                                            <td style="text-align: left">
                                                <input name="ordtype" type="radio" checked="true" value="ROD">ROD
                                                <input name="ordtype" type="radio" value="FOK">FOK
                                                <input name="ordtype" type="radio" value="IOC">IOC
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;">倉別
                                            </td>
                                            <td style="text-align: left">
                                                <input name="octtype" type="radio" checked="true" value="0">新倉
                                                <input name="octtype" type="radio" value="1">平倉
                                                <input name="octtype" type="radio" value=" ">自動
                                                <input name="octtype" type="radio" value="6">當沖
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;" class="Dashed">排程下單時間
                                            </td>
                                            <td style="text-align: left" class="Dashed">
                                                <span id="txtTempDate" style="display: none"></span>
                                                <div class="input-group clockpicker" data-autoclose="true">
                                                    <input id="txtOrderTime" type="text" class="form-control" value="05:00" size="5">
                                                    <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-time"></span>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left;"></td>
                                            <td style="text-align: right">
                                                <input id="cmdSure" type="button" value="確認加入排程下單">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </body>

    </html>