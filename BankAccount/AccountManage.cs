using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassSample
{
    public partial class AccountManage : Form
    {
        // フォーム内で使う銀行口座4名分を作成
        private BankAccount accountTokiwa = new BankAccount();
        private BankAccount accountNishiyama = new BankAccount();
        private BankAccount accountMiura = new BankAccount();

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountManage"/> class.
        /// </summary>
        public AccountManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード時の処理。
        /// </summary>
        /// <param name="sender">イベント呼び出し元オブジェクト</param>
        /// <param name="e">e</param>
        private void AccountManage_Load(object sender, EventArgs e)
        {
            // コンボボックスに選択肢を設定する。
            // new string[]……で文字列配列を作り、配列を元に選択肢を設定するAddRangeを使っています。
            comboAccount.Items.AddRange(new string[] { "トキ", "ニシ", "ミウ"});
        }

        /// <summary>
        /// コンボボックスの選択状況を見て扱う口座情報のインスタンスを返す。
        /// </summary>
        /// <returns>選択されている口座のBankAccount型データ。</returns>
        private BankAccount GetCurrentAccount()
        {
            BankAccount result;

            switch (comboAccount.SelectedItem.ToString())
            {
                case "トキ":
                    result = accountTokiwa;
                    break;
                case "ニシ":
                    result = accountNishiyama;
                    break;
                case "ミウ":
                    result = accountMiura;
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 入金ボタン押下処理。
        /// </summary>
        /// <param name="sender">イベント呼び出し元オブジェクト</param>
        /// <param name="e">e</param>
        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = GetCurrentAccount();
            // 未選択の場合はnullになるので、それ以外の場合は入金処理を行う
            // またテキストボックスが空の場合も除外する(String.Emptyとの比較で判断してみた）
            if (currentAccount != null && textKingaku.Text != string.Empty)
            {
                currentAccount.Deposit(int.Parse(textKingaku.Text));
            }
        }

        /// <summary>
        /// 出金ボタン押下処理。
        /// </summary>
        /// <param name="sender">イベント呼び出し元オブジェクト</param>
        /// <param name="e">e</param>
        private void buttonWithdraw_Click(object sender, EventArgs e)
        {
            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = GetCurrentAccount();
            // 未選択の場合はnullになるので、それ以外の場合は入金処理を行う
            // またテキストボックスが空の場合も除外する（トリムして長さがゼロかどうかで判断）
            if (currentAccount != null && textKingaku.Text.Trim().Length > 0)
            {
                // 残高不足の場合はFalseが返るので、その場合だけメッセージで警告する。
                if (!currentAccount.Withdraw(int.Parse(textKingaku.Text)))
                {
                    // 残高不足
                    MessageBox.Show("残高が不足しています。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 残高照会ボタン押下処理。
        /// </summary>
        /// <param name="sender">イベント呼び出し元オブジェクト</param>
        /// <param name="e">e</param>
        private void buttonShowTotal_Click(object sender, EventArgs e)
        {
            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = GetCurrentAccount();
            // 未選択の場合はnullになるので、それ以外の場合は入金処理を行う
            if (currentAccount != null)
            {
                textTotal.Text = currentAccount.AccountBalance.ToString("C");
            }
        }

    }
}
