using UnityEngine;
namespace DealerGame.Betting
{
    /// <summary>
    /// [列舉] 相對於玩家的牌局結果：勝利、平手、失敗
    /// </summary>
    public enum RoundOutcome
    {
        /// <summary>
        /// 玩家勝
        /// </summary>
        Win,
        /// <summary>
        /// 玩家敗
        /// </summary>
        Lose,
        /// <summary>
        /// 平手退注
        /// </summary>
        Push,
    }
}