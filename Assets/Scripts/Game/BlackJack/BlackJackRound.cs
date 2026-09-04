using DealerGame.View;
using Unity.VisualScripting;
using UnityEngine;
namespace DealerGame.Game.BlackJack
{
    /// <summary>
    /// 21點的回合類別
    /// </summary>
    public class BlackJackRound
    {
        #region 公開屬性
        //公開21點回合狀態 簡稱為 狀態 唯獨 私人使用 = 狀態的等待回合
        public BlackJackRoundState State { get; private set; } =
            BlackJackRoundState.WaitingForRound;

        /// <summary>
        /// 取得玩家手牌資料
        /// </summary>
        public BlackJackHand PlayerHand { get; } = new BlackJackHand();
        /// <summary>
        /// 取得荷官手牌資料
        /// </summary>
        public BlackJackHand DealerHand { get; } = new BlackJackHand();
        /// <summary>
        /// 新開局的狀態：輔助判斷秒勝(BlackJack)
        /// </summary>
        public bool NewRound => State == BlackJackRoundState.WaitingForRound;
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

        public bool CheckBust()
        {
            if (IsPlayerBust)
            {
                
                return TryComplete();
            }
            return false;
        }
        /// <summary>
        /// 判斷是否過五關
        /// </summary>
        /// <returns></returns>
        public bool CheckPass5()
        {
            if (PlayerHand.IsPass5 || DealerHand.IsPass5)
            {

                return TryComplete();
            }
            return false;
            
        }
        //internal 權限在於私人跟公開之間，再指定空間裡公開，在空間外就私人
        /// <summary>
        /// 嘗試完成牌局
        /// </summary>
        internal bool TryComplete()
        {
            //開局也可能結束：
            if (NewRound && !PlayerHand.IsBlackJack) return false;

            State = BlackJackRoundState.Complete;
            //觸發清算
            return true;
        }
        /// <summary>
        /// 嘗試新開局(清理資料)
        /// </summary>
        public void TryNewGame()
        {
            State = BlackJackRoundState.WaitingForRound;
            PlayerHand.Clear();
            DealerHand.Clear();
        }

        #endregion 公開方法

    }

}
