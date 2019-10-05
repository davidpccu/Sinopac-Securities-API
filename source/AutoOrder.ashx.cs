using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace WebApplication1
{
    /// <summary>
    /// AutoOrder1 的摘要描述
    /// </summary>
    public class AutoOrder1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            #region 登入登出
            if (context.Request.Form["Login"] == "true")
            {
                string strResult;
                string myAccount = context.Request.Form["ddlAccount"];

                // 永豐API初始化函式  (回傳值：初始化成功/已初始化)
                string myStep1 = Marshal.PtrToStringAnsi(API.init_t4(API.ID, API.PassWord, ""));

                // 登入永豐帳戶 (回傳值：CA憑證資料登錄成功)
                string myStep2 = Marshal.PtrToStringAnsi(API.add_acc_ca(API.myBranch, myAccount, API.ID, API.acc_ca_path, API.ID));

                // 憑證驗證測試 (回傳值：CA驗證成功)
                string myStep3 = Marshal.PtrToStringAnsi(API.verify_ca_pass(API.myBranch, myAccount));

                if (( myStep1.IndexOf("已初始化") >= 0 || myStep1.IndexOf("初始化成功") >= 0 )
                    && myStep2.IndexOf("憑證資料登錄成功") >= 0 
                    && myStep3.IndexOf("驗證成功") >= 0)
                {
                    strResult = "success";
                }
                else
                {
                    strResult = "error";
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write(strResult);
                context.Response.End();
            }

            if (context.Request.Form["Logout"] == "true")
            {
                string strResult;

                strResult = API.log_out().ToString();

                context.Response.ContentType = "text/plain";
                context.Response.Write(strResult);
                context.Response.End();
            }
            #endregion

            #region 交易

            //國內期貨下單
            if (context.Request.QueryString["Branch"] != null)
            {

                string strResult;
                string myBranch    = context.Request.QueryString["Branch"];
                string myAccount   = context.Request.QueryString["Account"];
                string myBuySell   = context.Request.QueryString["BuySell"];
                string myFutureId  = context.Request.QueryString["FutureId"];
                string myPrice     = context.Request.QueryString["Price"];
                string myAmount    = context.Request.QueryString["Amount"];
                string myPriceType = context.Request.QueryString["PriceType"];
                string myOrdtype   = context.Request.QueryString["Ordtype"];
                string myOcttype   = context.Request.QueryString["Octtype"];

                Marshal.PtrToStringAnsi(API.init_t4(API.ID, API.PassWord, ""));
                Marshal.PtrToStringAnsi(API.add_acc_ca(API.myBranch, myAccount, API.ID, API.acc_ca_path, API.ID));
                Marshal.PtrToStringAnsi(API.verify_ca_pass(API.myBranch, myAccount));

                strResult = Marshal.PtrToStringAnsi(API.future_order(myBuySell, myBranch, myAccount, myFutureId, myPrice, myAmount, myPriceType, myOrdtype, myOcttype));
                
                API.log_out().ToString();

                context.Response.ContentType = "text/plain";
                context.Response.Write(strResult);
                context.Response.End();
            }

            #endregion

            // 避免斷線問題，背景呼叫Ajax Keep 連線
            if (context.Request.Form["KeepAlive"] == "true")
            {
                string strResult = "KeepAlive";

                context.Response.ContentType = "text/plain";
                context.Response.Write(strResult);
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}