namespace CSharpT4
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txLogonID = new System.Windows.Forms.TextBox();
            this.btnLogon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txLogonPass = new System.Windows.Forms.TextBox();
            this.cbStoAcct = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFuAcct = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddAccCa = new System.Windows.Forms.Button();
            this.txCaPass = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txStatus = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOctType = new System.Windows.Forms.ComboBox();
            this.cbBuySell = new System.Windows.Forms.ComboBox();
            this.cbPriceType = new System.Windows.Forms.ComboBox();
            this.cbOrdType = new System.Windows.Forms.ComboBox();
            this.txAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txPrice = new System.Windows.Forms.TextBox();
            this.xNoname = new System.Windows.Forms.Label();
            this.txProdCode = new System.Windows.Forms.TextBox();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFFGetInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txLogonID
            // 
            this.txLogonID.Location = new System.Drawing.Point(86, 37);
            this.txLogonID.Name = "txLogonID";
            this.txLogonID.Size = new System.Drawing.Size(114, 22);
            this.txLogonID.TabIndex = 2;
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(222, 35);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(103, 23);
            this.btnLogon.TabIndex = 3;
            this.btnLogon.Text = "Logon";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "登入ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "登入密碼";
            // 
            // txLogonPass
            // 
            this.txLogonPass.Location = new System.Drawing.Point(86, 65);
            this.txLogonPass.Name = "txLogonPass";
            this.txLogonPass.PasswordChar = '*';
            this.txLogonPass.Size = new System.Drawing.Size(114, 22);
            this.txLogonPass.TabIndex = 6;
            // 
            // cbStoAcct
            // 
            this.cbStoAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStoAcct.FormattingEnabled = true;
            this.cbStoAcct.Location = new System.Drawing.Point(423, 21);
            this.cbStoAcct.Name = "cbStoAcct";
            this.cbStoAcct.Size = new System.Drawing.Size(208, 20);
            this.cbStoAcct.TabIndex = 7;
            this.cbStoAcct.SelectedIndexChanged += new System.EventHandler(this.cbStoAcct_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "證券帳戶";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "期貨帳戶";
            // 
            // cbFuAcct
            // 
            this.cbFuAcct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuAcct.FormattingEnabled = true;
            this.cbFuAcct.Location = new System.Drawing.Point(423, 47);
            this.cbFuAcct.Name = "cbFuAcct";
            this.cbFuAcct.Size = new System.Drawing.Size(208, 20);
            this.cbFuAcct.TabIndex = 9;
            this.cbFuAcct.SelectedIndexChanged += new System.EventHandler(this.cbFuAcct_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "憑證密碼";
            // 
            // btnAddAccCa
            // 
            this.btnAddAccCa.Location = new System.Drawing.Point(559, 82);
            this.btnAddAccCa.Name = "btnAddAccCa";
            this.btnAddAccCa.Size = new System.Drawing.Size(103, 23);
            this.btnAddAccCa.TabIndex = 12;
            this.btnAddAccCa.Text = "加入憑證驗章";
            this.btnAddAccCa.UseVisualStyleBackColor = true;
            this.btnAddAccCa.Click += new System.EventHandler(this.btnAddAccCa_Click);
            // 
            // txCaPass
            // 
            this.txCaPass.Location = new System.Drawing.Point(423, 82);
            this.txCaPass.Name = "txCaPass";
            this.txCaPass.PasswordChar = '*';
            this.txCaPass.Size = new System.Drawing.Size(114, 22);
            this.txCaPass.TabIndex = 13;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(222, 69);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(103, 23);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txStatus
            // 
            this.txStatus.Location = new System.Drawing.Point(18, 232);
            this.txStatus.Multiline = true;
            this.txStatus.Name = "txStatus";
            this.txStatus.Size = new System.Drawing.Size(661, 118);
            this.txStatus.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFFGetInfo);
            this.groupBox1.Controls.Add(this.cbOctType);
            this.groupBox1.Controls.Add(this.cbBuySell);
            this.groupBox1.Controls.Add(this.cbPriceType);
            this.groupBox1.Controls.Add(this.cbOrdType);
            this.groupBox1.Controls.Add(this.txAmount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txPrice);
            this.groupBox1.Controls.Add(this.xNoname);
            this.groupBox1.Controls.Add(this.txProdCode);
            this.groupBox1.Controls.Add(this.btnPlaceOrder);
            this.groupBox1.Location = new System.Drawing.Point(18, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 116);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "手動下單";
            // 
            // cbOctType
            // 
            this.cbOctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOctType.FormattingEnabled = true;
            this.cbOctType.Items.AddRange(new object[] {
            "自動",
            "新倉",
            "平倉",
            "當沖"});
            this.cbOctType.Location = new System.Drawing.Point(541, 21);
            this.cbOctType.Name = "cbOctType";
            this.cbOctType.Size = new System.Drawing.Size(72, 20);
            this.cbOctType.TabIndex = 11;
            // 
            // cbBuySell
            // 
            this.cbBuySell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuySell.FormattingEnabled = true;
            this.cbBuySell.Items.AddRange(new object[] {
            "買",
            "賣"});
            this.cbBuySell.Location = new System.Drawing.Point(25, 21);
            this.cbBuySell.Name = "cbBuySell";
            this.cbBuySell.Size = new System.Drawing.Size(81, 20);
            this.cbBuySell.TabIndex = 10;
            // 
            // cbPriceType
            // 
            this.cbPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPriceType.FormattingEnabled = true;
            this.cbPriceType.Location = new System.Drawing.Point(454, 21);
            this.cbPriceType.Name = "cbPriceType";
            this.cbPriceType.Size = new System.Drawing.Size(81, 20);
            this.cbPriceType.TabIndex = 9;
            // 
            // cbOrdType
            // 
            this.cbOrdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOrdType.FormattingEnabled = true;
            this.cbOrdType.Location = new System.Drawing.Point(454, 47);
            this.cbOrdType.Name = "cbOrdType";
            this.cbOrdType.Size = new System.Drawing.Size(81, 20);
            this.cbOrdType.TabIndex = 8;
            // 
            // txAmount
            // 
            this.txAmount.Location = new System.Drawing.Point(358, 61);
            this.txAmount.Name = "txAmount";
            this.txAmount.Size = new System.Drawing.Size(41, 22);
            this.txAmount.TabIndex = 7;
            this.txAmount.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "口數";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "價格";
            // 
            // txPrice
            // 
            this.txPrice.Location = new System.Drawing.Point(237, 61);
            this.txPrice.Name = "txPrice";
            this.txPrice.Size = new System.Drawing.Size(70, 22);
            this.txPrice.TabIndex = 4;
            this.txPrice.Text = "0.1";
            // 
            // xNoname
            // 
            this.xNoname.AutoSize = true;
            this.xNoname.Location = new System.Drawing.Point(23, 66);
            this.xNoname.Name = "xNoname";
            this.xNoname.Size = new System.Drawing.Size(53, 12);
            this.xNoname.TabIndex = 3;
            this.xNoname.Text = "商品代碼";
            // 
            // txProdCode
            // 
            this.txProdCode.Location = new System.Drawing.Point(82, 61);
            this.txProdCode.Name = "txProdCode";
            this.txProdCode.Size = new System.Drawing.Size(100, 22);
            this.txProdCode.TabIndex = 2;
            this.txProdCode.Text = "TXO07700D4";
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.Location = new System.Drawing.Point(541, 61);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(103, 23);
            this.btnPlaceOrder.TabIndex = 1;
            this.btnPlaceOrder.Text = "送單";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFFGetInfo
            // 
            this.btnFFGetInfo.Location = new System.Drawing.Point(454, 87);
            this.btnFFGetInfo.Name = "btnFFGetInfo";
            this.btnFFGetInfo.Size = new System.Drawing.Size(190, 23);
            this.btnFFGetInfo.TabIndex = 17;
            this.btnFFGetInfo.Text = "國外期貨權益數查詢";
            this.btnFFGetInfo.UseVisualStyleBackColor = true;
            this.btnFFGetInfo.Click += new System.EventHandler(this.btnFFGetInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 362);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txStatus);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.txCaPass);
            this.Controls.Add(this.btnAddAccCa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbFuAcct);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStoAcct);
            this.Controls.Add(this.txLogonPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogon);
            this.Controls.Add(this.txLogonID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "非正式範例";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txLogonID;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txLogonPass;
        private System.Windows.Forms.ComboBox cbStoAcct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFuAcct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddAccCa;
        private System.Windows.Forms.TextBox txCaPass;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbOctType;
        private System.Windows.Forms.ComboBox cbBuySell;
        private System.Windows.Forms.ComboBox cbPriceType;
        private System.Windows.Forms.ComboBox cbOrdType;
        private System.Windows.Forms.TextBox txAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txPrice;
        private System.Windows.Forms.Label xNoname;
        private System.Windows.Forms.TextBox txProdCode;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnFFGetInfo;
    }
}

