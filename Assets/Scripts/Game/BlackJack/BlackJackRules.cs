using DealerGame.Betting;
using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// [裁判]21點的遊戲規則類別，依照達成難易度排序
    /// </summary>
    public class BlackJackRules
    {

        #region 公開方法
        /// <summary>
        /// 雙方全部勝負組合與賠率
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dealer"></param>
        /// <returns></returns>
        public RoundResult Resolve(BlackJackHand player, BlackJackHand dealer)
        {
            if (player.Points > 21) //如果玩家爆掉：輸掉籌碼
                return new RoundResult(RoundOutcome.Lose, 0f, "玩家爆掉");
            if (player.IsBlackJack && dealer.IsBlackJack) //如果雙方都是黑傑克：籌碼退還
                return new RoundResult(RoundOutcome.Push, 1f, "Both BlackJack");
            if (player.IsBlackJack)//玩家21點：多退1.5倍
                return new RoundResult(RoundOutcome.Win, 2.5f, "!玩家黑傑克!");
            if (dealer.IsBlackJack)//莊家21點：輸掉籌碼
                return new RoundResult(RoundOutcome.Lose, 0f, "!莊家黑傑克!");
            if (player.IsPass5)//玩家過五關：退兩倍
                return new RoundResult(RoundOutcome.Win, 3f, "!玩家過五關!");
            if (dealer.Points > 21 || player.Points > dealer.Points)//莊家爆掉 或 點數勝
                return new RoundResult(RoundOutcome.Win, 2.2f, "!Win!");
            if (player.Points < dealer.Points)//點數輸
                return new RoundResult(RoundOutcome.Lose, 0f, "!Lose!");


            return new RoundResult(RoundOutcome.Push, 1f, "");
        }
        #endregion
    }

}