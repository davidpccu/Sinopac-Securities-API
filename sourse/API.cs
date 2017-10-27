using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class API
    {
        public static string ID
        {
            get
            { return "A123456789"; } // 設定帳號的參數 
        }
        public static string PassWord
        {
            get
            { return "xxxxxx"; } // 設定密碼的參數 
        }

        // 分公司代號
        // 帳號
        public static string myBranch
        {
            get
            { return "F002000"; }
        }
        public static string myAccount
        {
            get
            { return "1234567"; }
        }
        public static string acc_ca_path
        {
            get
            { return "C:\\ekey\\551\\A123456789\\S"; }
        }

        #region 元件初始化
        /// <summary>
        /// 元件初始化
        /// </summary>
        /// <param name="login_id">帳號</param>
        /// <param name="login_pass">密碼</param>
        /// <param name="dll_path">元件所在路徑</param>
        /// <returns></returns>
        [DllImport("C:\\永豐期貨API\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr init_t4(string login_id, string login_pass, string dll_path);


        /// <summary>
        /// 登入期貨帳戶 (帳戶加入憑證清單)
        /// </summary>
        /// <param name="branch">分公司代號</param>
        /// <param name="account">帳號</param>
        /// <param name="acc_id">用戶ID</param>
        /// <param name="acc_ca_path">CA憑證路徑</param>
        /// <param name="acc_ca_pass">CA密碼</param>
        /// <returns></returns>
        [DllImport("C:\\永豐期貨API\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr add_acc_ca(string branch, string account, string acc_id, string acc_ca_path, string acc_ca_pass);


        /// <summary>
        /// 驗證下單帳號密碼 (憑證驗證測試)
        /// </summary>
        /// <param name="branch">分公司代號</param>
        /// <param name="account">帳號</param>
        /// <returns></returns>
        [DllImport("C:\\永豐期貨API\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr verify_ca_pass(string branch, string account);

        #endregion

        # region 下單
        /// <summary>
        /// 國內期貨下單
        /// </summary>
        /// <param name="buy_or_sell">"B" = 買, "S" = 賣</param>
        /// <param name="branch">期貨分公司代號</param>
        /// <param name="account">期貨帳戶</param>
        /// <param name="future_id">商品代號</param>
        /// <param name="price">價格 6位數</param>
        /// <param name="amount">口數 3位數</param>
        /// <param name="price_type">MKT：市價單、LMT：限價單</param>
        /// <param name="ordtype">IOC、ROD、FOK</param>
        /// <param name="octtype">倉別 "0" = 新倉、"1" = 平倉、" "= 自動、"6"= 當沖</param>
        /// <returns></returns>
        [DllImport("C:\\永豐期貨API\\t4.dll")]
        public static extern IntPtr future_order(string buy_or_sell, string branch, string account, string future_id, string price, string amount, string price_type, string ordtype, string octtype);

        /// <summary>
        /// 期權委託查詢，用來查詢已下單的狀況
        /// </summary>
        /// <param name="branch">分公司代號</param>
        /// <param name="acct">帳號</param>
        /// <param name="code">商品代號</param>
        /// <param name="ord_match_flag">成交類別 0:全部明細 1:未成交 3:委託失敗 5:委託彙總</param>
        /// <param name="ord_type">商品類別 0:全部商品 1:期貨 2:選擇權 3:美元計價</param>
        /// <param name="oct_type">倉別.定為"0"</param>
        /// <param name="is_daily">0:當日 1:歷史</param>
        /// <param name="start_date">歷史查詢起始日</param>
        /// <param name="end_date">歷史查詢終止日</param>
        /// <param name="preorder">' ' = 僅查預約單, 'N' = 不含預約單</param>
        /// <param name="source"> 來源, 1=e-Leader, 2=API, 3=e-Leader + API, 其他數值則傳回全部</param>
        /// <returns></returns>
        [DllImport(@"c:\永豐期貨API\t4.dll")]
        public static extern string fo_order_qry2(string branch, string acct, string code, string ord_match_flag, string ord_type, string oct_type, string daily, string start_date, string end_date, string preorder, string source);
        #endregion

        [DllImport(@"c:\永豐期貨API\t4.dll")]
        public static extern int log_out();
    }
}