using UnityEngine;
namespace DealerGame.Betting
{
    /// <summary>
    /// [系統]下注系統：管理玩家的籌碼錢包、下注、結算
    /// </summary>
    public class BettingSystem
    {
        #region 常數
        /// <summary>
        /// [常數]定義籌碼最小下注金額單位
        /// </summary>
        private const int MinimumBet = 10;
        #endregion 常數

        #region 私有欄位
        /// <summary>
        /// 籌碼錢包的託管欄位
        /// </summary>
        private readonly ChipWallet _chipWallet;
        #endregion 私有欄位

        #region 公開屬性(UI能讀)
        /// <summary>
        /// 顯示錢包餘額
        /// </summary>
        public int Balance => _chipWallet.Balance;
        /// <summary>
        /// 顯示目前下注金額
        /// </summary>
        public int CurrentBet { get; private set; }
        #endregion 公開屬性(UI能讀)

        #region 建構式
        /// <summary>
        /// 建立下注系統，並託管玩家的籌碼錢包
        /// </summary>
        /// <param name="wallet">錢包</param>
        public BettingSystem(ChipWallet wallet)
        {
            _chipWallet = wallet;
        }
        #endregion 建構式

        #region 公開方法
        /// <summary>
        /// 嘗試放籌碼到下注區
        /// </summary>
        /// <param name="amount">下注金額</param>
        /// <returns>是否成功完成下注</returns>
        public bool TryPlaceBet(int amount)
        {
            //檢查下注金額是否符合規則
            if (amount < MinimumBet) return false; //下注失敗
            if (!_chipWallet.TryWithdraw(amount)) return false; //下注失敗
            CurrentBet = amount;
            return true; //下注成功
        }

        /// <summary>
        /// 結算目前下注金額返還數值
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public int Settle(RoundResult result)
        {
            if (CurrentBet == 0) return 0; //沒有下注，沒有結算
            //依照勝負回傳報告計算返回籌碼
            int returnChips = result.CalculateReturn(CurrentBet);
            //進回籌碼錢包
            _chipWallet.Deposit(returnChips);
            //清空下注金
            CurrentBet = 0;
            return returnChips;
        }
        #endregion 公開方法

    }
}
