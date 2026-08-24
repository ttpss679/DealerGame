using UnityEngine;
namespace DealerGame.Betting
{
    /// <summary>
    /// [資料結構]一回合結束的所有結算結果
    /// </summary>
    public class RoundResult
    {
        #region 公開屬性
        /// <summary>
        /// 取得玩家勝負
        /// </summary>
        public RoundOutcome Outcome { get; }
        /// <summary>
        /// 取得下注倍率
        /// </summary>
        public float ReturnRate { get; }
        /// <summary>
        /// 取得回合結束的原因/輸出這筆結果的原因(文字記錄)
        /// </summary>
        public string Reason { get; }
        #endregion 公開屬性

        #region 建構式
        /// <summary>
        /// 建立一筆回合產生的結果
        /// </summary>
        /// <param name="outcome">勝負</param>
        /// <param name="returnRate">倍率</param>
        /// <param name="reason">記錄</param>
        public RoundResult(RoundOutcome outcome,float returnRate,string reason)
        {
            Outcome = outcome;
            ReturnRate = returnRate;
            Reason = reason;
        }
        #endregion 建構式


        #region 公開方法
        /// <summary>
        /// 計算下注金額的回傳值(整數
        /// </summary>
        /// <param name="bet">下注值</param>
        /// <returns>結算回報</returns>
        public int CalculateReturn(int bet)
        {
            return (int)(bet * ReturnRate);
        }
        #endregion 公開方法
    }
}
