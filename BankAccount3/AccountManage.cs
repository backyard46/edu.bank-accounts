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
        // 口座名義人一覧をListオブジェクトに入れておく（コンボボックスの初期化や口座作成時に楽なので）
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
            MessageBox.Show(BankAccount.GetUsers().ToString());


            // アカウント情報ディクショナリーaccountsに各アカウントのインスタンスを格納しておく。
            // 先に用意しておいた名義一覧Listについて、foreachでそれぞれの名前を使ってBankAccountを作成
            // 作ったBankAccountインスタンスはディクショナリー「accounts」に、氏名をキーにして入れておく。
            foreach (string user in users)
            {
                accounts.Add(user, new BankAccount(user, 500));
            }

            // コンボボックスに苗字を設定しておく。
            // List型をToArrayで文字配列に変換し、ComboBoxのItems.AddRangeで一気に登録。
            comboAccount.Items.AddRange(users.ToArray<string>());
            // 無選択は許さない設定にする（最初から1件目を選択した状態にする）
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
        /// 残高照会ボタン押下処理。氏名と残高を表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShowTotal_Click(object sender, EventArgs e)
        {

            // コンボボックスで選択されている人に応じた口座インスタンスを取得する
            BankAccount currentAccount = accounts[comboAccount.SelectedItem.ToString()];
            
            //MessageBox.Show("ただ今の口座数 : " + currentAccount.users.ToString());

            // 未選択の場合はnullになるので、それ以外の場合は入金処理を行う
            if (currentAccount != null)
            {
                // 氏名はBankAccountのAccountNameに入っているものを利用。
                // 残高は、ToStringの引数に、Currency型の数値として表示する「"C"」を指定して金額として整形。
                textTotal.Text = currentAccount.AccountName + " : " + currentAccount.AccountBalance.ToString("C");
            }
        }

    }
}
