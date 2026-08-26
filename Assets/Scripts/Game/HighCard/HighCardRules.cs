using DealerGame.Betting;
using DealerGame.core;
using UnityEngine;
using UnityEngine.UI;
namespace DealerGame.Game.HighCard
{
    /// <summary>
    /// [裁判]比大小的遊戲規則
    /// </summary>

    public class HighCardRules
    {
        #region 公開方法
        /// <summary>
        /// 比較兩者點數的大小，並回傳結果
        /// </summary>
        /// <param name="A">對象A</param>
        /// <param name="B">對象B</param>
        public RoundResult Resolve(PlayingCard A, PlayingCard B)
        {
            //值翻譯
            int valueA = GetValue(A);
            int valueB = GetValue(B);
            
            //如果(A大於B)回傳大
            if (valueA > valueB)
            {
                return new RoundResult(RoundOutcome.Win, 2f, "玩家勝");
            }
            //如果(A小於B)回傳小
            if (valueA < valueB)
            {
                return new RoundResult(RoundOutcome.Lose, 0f, "玩家敗");
            }


            //比對結果
            return new RoundResult(RoundOutcome.Push, 1f, "和局");
        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 資料轉譯(值放到十位數以上+花色放置個位數=獨一無二的數值)
        /// </summary>
        /// <param name="card">翻譯對象</param>
        /// <returns>回傳翻譯結果</returns>
        private int GetValue(PlayingCard card)
        {
            return (int)card.Rank * 10 + (int)card.Suit;
        }
        #endregion 私有方法
    }
}
