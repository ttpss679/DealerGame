using DealerGame.core;
using UnityEngine;
namespace DealerGame.Game.HighCard
{
    public class HightCardGameController : MonoBehaviour
    {
        #region 欄位
        [SerializeField]
        private Dealer _dealer;
        [SerializeField]
        private Transform _playerHand;
        [SerializeField]
        private Transform _dealerHand;
        #endregion 欄位

        #region 私有欄位
        private readonly HighCardRules _rules = new HighCardRules();
        #endregion 私有欄位


        #region 生命週期
        void Start()
        {
           PlayRound();
        }
        #endregion 生命週期

        #region 公開方法
        /// <summary>
        /// 遊玩回合
        /// </summary>
        public void PlayRound()
        {
            //荷官開局
            _dealer.BeginRound();
            //發牌給玩家與荷官
                       
            PlayingCard playCard = _dealer.DealTo(_playerHand);
            PlayingCard dealerCard = _dealer.DealTo(_dealerHand);

            string result = _rules.Resolve(playCard, dealerCard);
            Debug.Log(result);

        }
        #endregion 公開方法




    }
}

