using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// [策略]荷官要牌策略-停在17點
    /// 基底介面統一化，功能語意一致化
    /// </summary>
    public class StandOn17 : IDealerStrategy
    {
        /// <summary>
        /// 荷官手牌點數總和小於17點
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool ShouldHit(BlackJackHand hand)
        {
            return hand.Points < 17;
        }
    }

}