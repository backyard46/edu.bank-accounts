using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClassSample
{
    public partial class AccountManage : Form
    {
        // 口座名義人
        List<string> users = new List<string> { "井口秀祐", "笠井美里", "菊池里沙子", "綿貫朱里" };

        // 口座情報を入れるDictionaryオブジェクト「accounts」の宣言。
        // 「名前」と「BankAccountのインスタンス」をペアでしまっておくと、名前で対応するインスタンスを取り出せる
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

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
            // アカウント情報ディクショナリーaccountsに各アカウントのインスタンスを格納しておく。
            // 取り出す際のキーは「苗字」。

            // Actionデリゲートに匿名メソッドを割り当てて、それでusersリストに対してForEachで処理する方式
            Action<string> createAccount = (item) => { accounts.Add(item, new BankAccount(item, 500)); };
            users.ForEach(createAccount);

            // こちらでも同じになる
            // usersリストに対してForEachにラムダ式でAddを繰り返し処理する方式
            // users.ForEach((item) => { accounts.Add(item, new BankAccount(item, 500)); });

            // コンボボックスに苗字を設定しておく。
            comboAccount.Items.AddRange(users.ToArray<string>());
            //comboAccount.Items.AddRange(new string[] { "井口", "笠井", "菊池", "綿貫" });
            // 無選択は許さない設定に
            comboAccount.SelectedIndex = 0;
        }


        /// <summary>
        /// 入金ボタン押下処理。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeposit_Click(object sender, EventArgs e)
        {
            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = accounts[comboAccount.SelectedItem.ToString()];
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
            BankAccount currentAccount = accounts[comboAccount.SelectedItem.ToString()];
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowTotal_Click(object sender, EventArgs e)
        {
            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = accounts[comboAccount.SelectedItem.ToString()];
            // 未選択の場合はnullになるので、それ以外の場合は入金処理を行う
            if (currentAccount != null)
            {
                textTotal.Text = currentAccount.AccountName + " : " + currentAccount.AccountBalance.ToString("C");
            }
        }

    }
}
