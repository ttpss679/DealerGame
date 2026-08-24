using System;
using UnityEngine;
namespace DealerGame.Betting
{
    /// <summary>
    /// [資料結構]玩家的籌碼錢包餘額
    /// </summary>
    public class ChipWallet
    {
        #region 公開屬性
        /// <summary>
        /// 取得玩家的籌碼餘額(只允許透過功能做內部設定)
        /// </summary>
        public int Balance { get; private set; }
        #endregion 公開屬性

        #region 建構式
        /// <summary>
        /// 建立一個玩家的籌碼錢包，並設定初始餘額
        /// </summary>
        /// <param name="initialBalance">儲值金額</param>
        public ChipWallet(int initialBalance)
        {
            //基本數據防護：取最小值的防呆措施
            Balance = Math.Max(0, initialBalance);
        }
        #endregion 建構式

        #region 公開方法
        /// <summary>
        /// (押金)"嘗試"提取
        /// </summary>
        /// <param name="amount">提取金額</param>
        /// <retutn>是否成功</retutn>
        public bool TryWithdraw(int amount)
        {
            //提領負值or超過餘額，則失敗
            if (amount <= 0 || amount > Balance) return false;
            //結餘減等於提領金額，沒被阻擋才合法扣除
            Balance -= amount;
            return true;
        }
        /// <summary>
        /// (撤回)存入金額，不能負數
        /// </summary>
        /// <param name="amount">存入金額</param>
        public void Deposit(int amount)
        {

            //結餘加等於取最小值的金額
            Balance += Math.Max(0, amount);
        }

        #endregion 公開方法


    }
}
