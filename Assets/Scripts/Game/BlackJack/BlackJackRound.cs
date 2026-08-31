using DealerGame.View;
using Unity.VisualScripting;
using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// 
    /// </summary>
    public class BlackJackRound
    {
        #region 公開屬性
        //公開21點回合狀態 簡稱為 狀態 唯獨 私人使用 = 狀態的等待回合
        public BlackJackRoundState State { get; private set; } =
            BlackJackRoundState.WaitingForRound;

        /// <summary>
        /// 取得玩家手排資料
        /// </summary>
        public BlackJackHand PlayerHand { get; } = new BlackJackHand();
        /// <summary>
        /// 取得荷官手排資料
        /// </summary>
        public BlackJackHand DealerHand { get; } = new BlackJackHand();
        /// <summary>
        /// 取得當下玩家是否可以合法操作
        /// </summary>
        public bool CanPlayerAct => State == BlackJackRoundState.PlayerTurn;
        /// <summary>
        /// 玩家爆牌
        /// </summary>
        public bool IsPlayerBust => PlayerHand.Points > 21;
        #endregion 公開屬性

        #region 公開方法
        /// <summary>
        /// 正式回合開始
        /// </summary>
        public void TryStart()
        {
            //如果玩家或荷官手上的牌少於2就回傳
            if (PlayerHand.Count < 2 || DealerHand.Count < 2) return;
            State = BlackJackRoundState.PlayerTurn;
        }
        /// <summary>
        /// 玩家停牌，轉移行動權
        /// </summary>
        public void TryStand()
        {
            if (!CanPlayerAct) return; //避免非玩家可行動誤觸
            State = BlackJackRoundState.DealerTurn;
        }

        public void CheckBust()
        {
            if (IsPlayerBust) State = BlackJackRoundState.Complete;
        }
        #endregion 公開方法

    }

}
