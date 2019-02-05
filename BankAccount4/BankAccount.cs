using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassSample
{
    /// <summary>
    /// 銀行の口座情報1人分を管理するクラス。
    /// </summary>
    class BankAccount
    {
        // 口座の内部情報
        private string accountName = "";    // 口座名義人名
        private int total = 0;              // 口座残高


        /// <summary>
        /// デフォルトコンストラクター（何もしない）。
        /// </summary>
        public BankAccount()
        {
        }


        /// <summary>
        /// 口座名義人を初期設定するコンストラクター。
        /// </summary>
        /// <param name="AccountName">初期設定する氏名文字列。</param>
        public BankAccount(string name)
            : this(name, 0)
        {
            // 引数2つ版のコンストラクターを、第2引数ゼロで呼ぶのと同義なので、
            // コンストラクター初期化子記法を使ってみました。
        }


        /// <summary>
        /// 口座名義人と初期残高を設定するコンストラクター。
        /// </summary>
        /// <param name="name">初期設定する氏名文字列。</param>
        /// <param name="kingaku">初期口座残高。</param>
        public BankAccount(string name, int kingaku)
        {
            accountName = name;
            total = kingaku;
        }


        /// <summary>
        /// 口座名義プロパティ。
        /// </summary>
        public string AccountName
        {
            get 
            {
                return accountName;
            }
            set
            {
                accountName = value;
                if (value == null)
                {
                    accountName = "";
                }
            }
        }

        /// <summary>
        /// 残高設定/取得用プロパティ。
        /// </summary>
        public int AccountBalance
        {
            get 
            {
                return total;
            }
            /// 残高は参照のみで設定できないようにします
            //set 
            //{
            //    total = value;
            //}
        }

        /// <summary>
        /// 口座への預け入れ
        /// </summary>
        /// <remarks>
        /// 引数で指定した金額を口座に追加する。
        /// </remarks>
        /// <returns></returns>
        public void Deposit(int kingaku)
        {
            total += kingaku;
        }

        /// <summary>
        /// 口座引き落とし
        /// </summary>
        /// <remarks>
        /// 引数で指定した金額を口座から引き落とす。
        /// </remarks>
        /// <param name="kingaku">引き落とし金額。</param>
        /// <returns>追加成功ならTrue、失敗ならFalse。</returns>
        public Boolean Withdraw(int kingaku)
        {
            if (total - kingaku < 0)
            {
                return false;
            }
            else
            {
                total -= kingaku;
                return true;
            }
        }
    }
}
