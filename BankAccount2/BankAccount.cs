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
            set 
            {
                total += value;
            }
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
