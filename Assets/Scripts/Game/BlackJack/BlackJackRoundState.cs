using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// [狀態]表示21點的牌局當下的流程階段
    /// </summary>
    public enum BlackJackRoundState
    {
        /// <summary>
        /// 預備開始新局
        /// </summary>
        WaitingForRound,
        /// <summary>
        /// 等待玩家要排或停牌
        /// </summary>
        PlayerTurn,
        /// <summary>
        /// 玩家已停牌，荷官行動
        /// </summary>
        DealerTurn,
        /// <summary>
        /// 本局終局鎖定狀態
        /// </summary>
        Complete,
    }

}
