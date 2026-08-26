using DealerGame.Betting;
using DealerGame.core;
using System;
using TMPro;
using UnityEngine;
namespace DealerGame.Game.HighCard
{
    public class HightCardGameController : MonoBehaviour
    {
        #region UI元件
        [SerializeField]
        private TMP_Text _betLabel;
        [SerializeField]
        private TMP_Text _blanceLabel;
        #endregion UI元件


        #region 欄位
        [SerializeField]
        private Dealer _dealer;
        private TableSession _session;
        [SerializeField]
        private Transform _playerHand;
        [SerializeField]
        private Transform _dealerHand;
        private int _betAmount = 10;
        #endregion 欄位

        #region 私有欄位
        /// <summary>
        /// 該遊戲專屬持有的遊戲規則書
        /// </summary>
        private readonly HighCardRules _rules = new HighCardRules();
        /// <summary>
        /// 取得玩家錢包數值捷徑
        /// </summary>
        private int _blance => _session.Betting.Balance;
        #endregion 私有欄位


        #region 生命週期
        void Start()
        {
            _session = TableSession.Instance;
            UpdateBetUI();
            UpdateBlaceIU();
        }


        #endregion 生命週期

        #region 公開方法
        /// <summary>
        /// [UI按鈕]加注
        /// </summary>
        public void AddBet()
        {
            _betAmount += Math.Min(_blance, _betAmount + 10);
            UpdateBetUI();
            UpdateBlaceIU();
        }
        /// <summary>
        /// [UI按鈕]減注
        /// </summary>
        public void ReduceBet()
        {
            _betAmount -= Math.Max(10, _betAmount - 10);
            UpdateBetUI();
            UpdateBlaceIU();
        }
        /// <summary>
        /// [UI按鈕]確認下注金
        /// </summary>
        public void ApplyBetting()
        {
            _session.Betting.TryPlaceBet(_betAmount);
            //UpdateBlaceIU();
            //
        }

        /// <summary>
        /// 遊玩回合
        /// </summary>
        public void PlayRound()
        {
            //荷官開局
            _dealer.BeginRound();
            //發牌給玩家與荷官，參與者

            PlayingCard playCard = _dealer.DealTo(_playerHand);
            PlayingCard dealerCard = _dealer.DealTo(_dealerHand);
            //用規則書取得結果
            RoundResult result = _rules.Resolve(playCard, dealerCard);
            int returnChips = _session.Betting.Settle(result);

            Debug.Log($"{result.Reason} 獲得 {returnChips} 籌碼");

        }
        #endregion 公開方法

        #region 私有方法
        /// <summary>
        /// 更新籌碼UI
        /// </summary>
        private void UpdateBetUI()
        {

            _betLabel.text = _betAmount.ToString();
        }
        /// <summary>
        /// 更新餘額UI
        /// </summary>
        private void UpdateBlaceIU()
        {
            _blanceLabel.text = _blance.ToString();
        }
        #endregion


    }
}

