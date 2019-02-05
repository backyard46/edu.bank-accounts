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
        private BankAccount accountIguchi = new BankAccount();
        private BankAccount accountKasai = new BankAccount();
        private BankAccount accountKikuchi = new BankAccount();
        private BankAccount accountWatanuki = new BankAccount();

        public AccountManage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// フォームロード時の処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountManage_Load(object sender, EventArgs e)
        {
            comboAccount.Items.AddRange(new string[] { "井口", "笠井", "菊池", "綿貫" });
        }


        /// <summary>
        /// コンボボックスの選択状況を見て扱う口座情報のインスタンスを返す。
        /// </summary>
        /// <returns></returns>
        private BankAccount GetCurrentAccount()
        {
            BankAccount result;

            switch (comboAccount.SelectedItem.ToString())
            {
                case "井口":
                    result = accountIguchi;
                    break;
                case "笠井":
                    result = accountKasai;
                    break;
                case "菊池":
                    result = accountKikuchi;
                    break;
                case "綿貫":
                    result = accountWatanuki;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
