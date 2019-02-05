namespace ClassSample
{
    partial class AccountManage
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDeposit = new System.Windows.Forms.Button();
            this.comboAccount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonWithdraw = new System.Windows.Forms.Button();
            this.buttonShowTotal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.textKingaku = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDeposit
            // 
            this.buttonDeposit.Location = new System.Drawing.Point(104, 88);
            this.buttonDeposit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDeposit.Name = "buttonDeposit";
            this.buttonDeposit.Size = new System.Drawing.Size(144, 31);
            this.buttonDeposit.TabIndex = 0;
            this.buttonDeposit.Text = "入金";
            this.buttonDeposit.UseVisualStyleBackColor = true;
            this.buttonDeposit.Click += new System.EventHandler(this.buttonDeposit_Click);
            // 
            // comboAccount
            // 
            this.comboAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAccount.FormattingEnabled = true;
            this.comboAccount.Location = new System.Drawing.Point(104, 16);
            this.comboAccount.Name = "comboAccount";
            this.comboAccount.Size = new System.Drawing.Size(184, 27);
            this.comboAccount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "口座名義人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "金額";
            // 
            // buttonWithdraw
            // 
            this.buttonWithdraw.Location = new System.Drawing.Point(256, 88);
            this.buttonWithdraw.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonWithdraw.Name = "buttonWithdraw";
            this.buttonWithdraw.Size = new System.Drawing.Size(144, 31);
            this.buttonWithdraw.TabIndex = 5;
            this.buttonWithdraw.Text = "出金";
            this.buttonWithdraw.UseVisualStyleBackColor = true;
            this.buttonWithdraw.Click += new System.EventHandler(this.buttonWithdraw_Click);
            // 
            // buttonShowTotal
            // 
            this.buttonShowTotal.Location = new System.Drawing.Point(104, 139);
            this.buttonShowTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowTotal.Name = "buttonShowTotal";
            this.buttonShowTotal.Size = new System.Drawing.Size(144, 31);
            this.buttonShowTotal.TabIndex = 6;
            this.buttonShowTotal.Text = "残高照会";
            this.buttonShowTotal.UseVisualStyleBackColor = true;
            this.buttonShowTotal.Click += new System.EventHandler(this.buttonShowTotal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "口座残高";
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(104, 176);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(296, 27);
            this.textTotal.TabIndex = 7;
            // 
            // textKingaku
            // 
            this.textKingaku.Location = new System.Drawing.Point(104, 54);
            this.textKingaku.Name = "textKingaku";
            this.textKingaku.Size = new System.Drawing.Size(296, 27);
            this.textKingaku.TabIndex = 9;
            // 
            // AccountManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 217);
            this.Controls.Add(this.textKingaku);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.buttonShowTotal);
            this.Controls.Add(this.buttonWithdraw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAccount);
            this.Controls.Add(this.buttonDeposit);
            this.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AccountManage";
            this.Text = "銀行口座管理";
            this.Load += new System.EventHandler(this.AccountManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeposit;
        private System.Windows.Forms.ComboBox comboAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonWithdraw;
        private System.Windows.Forms.Button buttonShowTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.TextBox textKingaku;
    }
}

