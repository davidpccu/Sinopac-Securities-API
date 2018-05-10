using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


namespace CSharpT4
{
    public partial class Form1 : Form
    {
        // 初始化
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string init_t4( string login_id         // 登入 ID
                                           , string login_pass       // 登入密碼
                                           , string dll_path);       // 執行路徑

        // 登出
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern int log_out();

        // 取得帳號                                                   // 通常在成功登入之後
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string show_list2();

        // 加入憑證驗章                                                 // 通常在 show_list2 之後
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string add_acc_ca( string branch         // 分公司
                                              , string account       // 下單帳戶        (非登入ID)
                                              , string acc_id        // 帳戶所屬身份證號 (不一定為登入ID)
                                              , string acc_ca_path   // 憑證路徑        (非API路徑)
                                              , string acc_ca_pass); // 憑證密碼        (非登入密碼)

        // 開啟/關閉 主動回報   (不下單或是非必要時，可以避免註冊主動回報，節省資源、加快效能)
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int do_register(int YesNo);

        // 測試憑證驗章
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string verify_ca_pass( string branch
                                                  , string account);

        // 檢查是否有未讀回報
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern int check_response_buffer();

        // 讀取未讀回報
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string timer_response_log();

        // 期貨下單
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string future_order( string buy_sell       // 買賣別
                                                , string branch         // 期貨分公司
                                                , string account        // 期貨帳戶
                                                , string code           // 商品代碼
                                                , string price          // 商品價格
                                                , string amount         // 商品口數
                                                , string price_type     // 價別
                                                , string ord_type       // 單別
                                                , string oct_type );    // 倉別

        // 證券下單
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string stock_order( string buy_sell        // 買賣別
                                               , string branch          // 證券分公司
                                               , string account         // 證券帳戶
                                               , string code            // 商品代碼
                                               , string ord_type        // 單別
                                               , string price           // 價格
                                               , string amount          // 張數/股數
                                               , string price_type );   // 價別

        // 期貨未平倉部位查詢
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string fo_unsettled_qry
            (string flag, string leng, string next, string prev
            , string gubn, string grop
            , string bran, string acct
            , string typ1, string typ2, string tout);

        // 國外期貨權益數查詢
        [DllImport("C:\\VBA DLL\\t4.dll", CharSet = CharSet.Ansi)]
        public static extern string ff_get_info(string branch, string account);


        // 取得主動回報 event handle
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern UInt32 get_response_evt(  );

        // 取得主動回報 event name
        //[DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        //public static extern string get_response_evtname();

        // Windows kernel API
        //[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr OpenEvent(UInt32 dwDesiredAccess, bool bInheritHandle, String lpName);

        // Windows kernel API
        //[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr LoadLibrary(String mod_name);

        // Windows kernel API
        //[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr GetModuleHandle(String mod_name);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cbBuySell.SelectedIndex < 0)
                cbBuySell.SelectedIndex = 0;

            if (cbOctType.SelectedIndex < 0)
                cbOctType.SelectedIndex = 1;
        }


        private void btnLogon_Click(object sender, EventArgs e)
        {
            //IntPtr inst = GetModuleHandle("C:\\vba dll\\t4.dll"); // 取得載入的 module handle

            string ret = init_t4(txLogonID.Text, txLogonPass.Text, "C:\\vba dll");

            if (ret.StartsWith("初始化成功"))
            {
                //timer1.Start(); // 如果用 event 方式，就不需要此 timer
                uint evt_handle = get_response_evt();

                // 讓一個 Task 專門聆聽主動回報 event
                #region T4Dll就緒後監聽事件 get_response_evt()
                Task.Factory.StartNew(() =>
                {

                    if (evt_handle != (uint)IntPtr.Zero)
                    {
                        // 轉換 Event 成 C# 事件
                        var arEvt = new AutoResetEvent(false);
                        arEvt.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle((System.IntPtr)evt_handle, true);
                        var waitHandles = new WaitHandle[] { arEvt };
                        while (this.IsDisposed == false)
                        {
                            // 等候主動回報 Event
                            int idx_waitHandles = WaitHandle.WaitAny(waitHandles, 24 * 60 * 60 * 1000, false);
                            if (idx_waitHandles == 0)
                            {
                                // 收到主動回報，用迴圈把回報都讀完
                                while (check_response_buffer() > 0)
                                {
                                    // 收到回報時，測試一下
                                    string rep = timer_response_log();
                                    MessageBox.Show(  this.Parent, rep );
                                }

                            }
                        }
                    }
                });
                #endregion



                string acct = show_list2();   // 取得交易帳戶清單
                do_register(1);  // 開啟主動回報

                string [] arr_acct = acct.Split('\n');
                for (int i = 0; i < arr_acct.Length; i++)
                {
                    if (arr_acct[i].Length > 0)
                    {
                        if( arr_acct[i].StartsWith( "S" ))
                        {
                            cbStoAcct.Items.Add( arr_acct[i] );
                        }
                        else if( arr_acct[i].StartsWith( "F" ))
                        {
                            cbFuAcct.Items.Add( arr_acct[i] );
                        }

                    }
                }

            }
        }

        // 登出
        private void btnLogout_Click(object sender, EventArgs e)
        {
            cbStoAcct.Items.Clear();
            cbFuAcct.Items.Clear();
            //timer1.Stop();
            do_register(0); // 關閉主動回報
            log_out();  // 登出
        }

        // 加入憑證驗章
        private void btnAddAccCa_Click(object sender, EventArgs e)
        {
            string branch = "";
            string account = "";

            if (cbStoAcct.SelectedIndex >= 0)
            {
                string [] ret = cbStoAcct.Items[cbStoAcct.SelectedIndex].ToString().Split( '-' );

                branch = ret[0].Substring(1);
                account = ret[1];

            }
            else if (cbFuAcct.SelectedIndex >= 0)
            {
                string[] ret = cbFuAcct.Items[cbFuAcct.SelectedIndex].ToString().Split('-');

                branch = ret[0].Substring(1);
                account = ret[1];
            }
            else
            {
                return;
            }

            // 加入交易帳戶憑證驗章
            add_acc_ca(branch, account, txLogonID.Text, "C:\\ekey\\551\\R122921861\\S.real", txCaPass.Text );

            // 測試憑證驗章
            txStatus.Text = verify_ca_pass(branch, account);
        }

        // 切換交易股票/期貨
        private void cbStoAcct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選擇證券帳戶
            if (cbStoAcct.SelectedIndex >= 0)
            {
                cbFuAcct.SelectedIndex = -1;

                cbOrdType.Items.Clear();
                cbOrdType.Items.Add("定盤現股");
                cbOrdType.Items.Add("定盤融資");
                cbOrdType.Items.Add("定盤融券");
                cbOrdType.Items.Add("整股現股");
                cbOrdType.Items.Add("整股融資");
                cbOrdType.Items.Add("整股融券");
                cbOrdType.Items.Add("零股");

                cbPriceType.Items.Clear();
                cbPriceType.Items.Add("限價");
                cbPriceType.Items.Add("漲停");
                cbPriceType.Items.Add("跌停");
            }
        }

        // 切換交易帳戶
        private void cbFuAcct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 選擇期貨帳戶
            if (cbFuAcct.SelectedIndex >= 0)
            {
                cbStoAcct.SelectedIndex = -1;

                cbOrdType.Items.Clear();
                cbOrdType.Items.Add("ROD");
                cbOrdType.Items.Add("FOK");
                cbOrdType.Items.Add("IOC");

                cbPriceType.Items.Clear();
                cbPriceType.Items.Add("限價");
                cbPriceType.Items.Add("市價");

                cbOctType.SelectedIndex = -1;
            }
        }

        // 
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // 手動下單
            if (cbStoAcct.SelectedIndex >= 0)
            {
                // 下證券
                string [] acc = cbStoAcct.Items[cbStoAcct.SelectedIndex].ToString().Split('-');
                string buy_sell = (cbBuySell.SelectedIndex == 0) ? "B" : "S";
                string ord_type = (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "定盤現股") ? "P0"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "定盤融資") ? "P3"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "定盤融券") ? "P4"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "整股現股") ? "00"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "整股融資") ? "03"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "整股融券") ? "04"
                                : (cbOrdType.Items[cbOrdType.SelectedIndex].ToString() == "零股") ? "20" : "";

                string price_type = (cbPriceType.Items[cbPriceType.SelectedIndex].ToString() == "限價") ? " "
                                  : (cbPriceType.Items[cbPriceType.SelectedIndex].ToString() == "漲停") ? "2"
                                  : (cbPriceType.Items[cbPriceType.SelectedIndex].ToString() == "跌停") ? "3" : "";

                txStatus.Text = stock_order( buy_sell
                    , acc[0].Substring(1)
                    , acc[1]
                    , txProdCode.Text
                    , ord_type
                    , txPrice.Text
                    , txAmount.Text
                    , price_type );
            }
            else if (cbFuAcct.SelectedIndex >= 0)
            {
                // 下期貨
                string[] acc = cbFuAcct.Items[cbFuAcct.SelectedIndex].ToString().Split('-');
                string buy_sell = (cbBuySell.SelectedIndex==0) ? "B" : "S";
                string price_type = (cbPriceType.Items[cbPriceType.SelectedIndex].ToString() == "市價") ? "MKT" : "LMT";
                string ord_type = cbOrdType.Items[cbOrdType.SelectedIndex].ToString();
                string oct_type = (cbOctType.Items[cbOctType.SelectedIndex].ToString() == "自動") ? " "
                                : (cbOctType.Items[cbOctType.SelectedIndex].ToString() == "新倉") ? "0"
                                : (cbOctType.Items[cbOctType.SelectedIndex].ToString() == "平倉") ? "1"
                                : (cbOctType.Items[cbOctType.SelectedIndex].ToString() == "當沖") ? "6" : "";

                txStatus.Text = future_order(buy_sell
                    , acc[0].Substring(1)
                    , acc[1]
                    , txProdCode.Text
                    , txPrice.Text
                    , txAmount.Text
                    , price_type
                    , ord_type
                    , oct_type);
            }
        }

        // 用主動回報 event 時，則無須由 timer 取得主動回報，效率較佳
        private void timer1_Tick(object sender, EventArgs e)
        {
            //
            if (check_response_buffer()>0)
            {
                txStatus.Text = timer_response_log();
            }
        }

        // 視窗關閉
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            log_out();
        }

        private void btnFFGetInfo_Click(object sender, EventArgs e)
        {
            string ret = ff_get_info("F002000", "9120783");





            txStatus.Text = ret;
            

        }



    }
}
