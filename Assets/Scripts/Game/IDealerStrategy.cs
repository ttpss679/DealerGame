using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// [介面]定義荷官要牌策略
    /// </summary>
    public interface IDealerStrategy
    {
        #region 功能定義
        /// <summary>
        /// 判斷荷官是否要牌
        /// </summary>
        /// <returns>是否要牌</returns>
        bool ShouldHit(BlackJackHand hand);

        #endregion
        
    }
}
