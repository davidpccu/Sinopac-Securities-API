using System;
using System.Data;
using System.Runtime.InteropServices;

namespace WebApplication1
{
    public partial class AutoOrder : System.Web.UI.Page
    {

        #region  程式自訂變數宣告
        //--------------------------------------------------
        //程式自訂宣告變數
        //--------------------------------------------------
        #endregion

        #region  程式初始化處理
        //--------------------------------------------------
        //程式初始化處理 
        //--------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // 初始化設定
                    Init_Process();
                }
                Response.Expires = -1;
                Response.Cache.SetExpires(DateTime.Now);
            }
            catch (Exception myE)
            {
                Response.Write("<li>" + myE.Message);
                Response.Write("<li>" + myE.Source);
                Response.Write("<li>" + myE.StackTrace);
            }
        }
        #endregion

        #region 操作介面事件處理
        //--------------------------------------------------
        //程式介面事件處理
        //--------------------------------------------------
        #endregion

        #region 程式內部處理程序
        //--------------------------------------------------
        //程式內部程序
        //--------------------------------------------------
        private void Init_Process()
        {
        }
        #endregion
    }
}