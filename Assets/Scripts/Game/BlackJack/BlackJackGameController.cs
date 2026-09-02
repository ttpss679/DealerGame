using DealerGame.core;
using DealerGame.Game;
using DealerGame.View;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace DealerGame.Game.BlackJack
{
    public class BlackJackGameController : MonoBehaviour
    {
        #region UI元件
        [SerializeField]
        private TMP_Text _betLabel;
        [SerializeField]
        private TMP_Text _blanceLabel;
        [SerializeField]
        private TMP_Text _playerPointsLabel;
        [SerializeField]
        private TMP_Text _dealerPointsLabel;
        [SerializeField]
        private Button _startBtn;
        [SerializeField]
        private Button _hitBtn;
        [SerializeField]
        private Button _standBtn;
        [SerializeField]
        private Button _nextRoundBtn;
        #endregion UI元件

        #region 欄位
        [SerializeField]
        private Dealer _dealer;
        private TableSession _session;
        [SerializeField]
        private CardHandLayout _playerLayout;
        [SerializeField]
        private CardHandLayout _dealerLayout;
        #endregion 欄位

        #region 私有欄位
        /// <summary>
        /// 回合控制資料
        /// </summary>
        private readonly BlackJackRound _round = new BlackJackRound();
        /// <summary>
        /// 玩家手排
        /// </summary>
        private BlackJackHand PlayerHand => _round.PlayerHand;
        private int PlayerPoints => PlayerHand.Points;
        /// <summary>
        /// 同一局內荷官的手牌
        /// </summary>
        private BlackJackHand DealerHand => _round.DealerHand;
        private int DealerPoints => DealerHand.Points;
        /// <summary>
        /// 建立荷官策略17以上要牌
        /// </summary>
        private readonly IDealerStrategy _dealerStrategy = new StandOn17();
        #endregion 私有欄位

        #region 生命週期
        void Start()
        {
            _session = TableSession.Instance;
            UpdateBtnUI();
            UpdatePointsUI(_playerPointsLabel, PlayerPoints);
            UpdatePointsUI(_dealerPointsLabel, DealerPoints);
        }
        #endregion 生命週期

        #region 公開方法

        /// <summary>
        /// 開局首輪
        /// </summary>
        public void StartRound()
        {
            //荷官開局
            _dealer.BeginRound();

            DealTo(PlayerHand, _playerLayout);
            DealTo(DealerHand, _dealerLayout, false); //荷官的第一張牌蓋著
            DealTo(PlayerHand, _playerLayout);
            DealTo(DealerHand, _dealerLayout);

            //Debug.Log($"玩家：{PlayerHand.Points}點");
            Debug.Log($"莊家：{DealerHand.Points}點");
            _round.TryStart(); //正式啟動
            UpdateBtnUI();
            UpdatePointsUI(_playerPointsLabel, PlayerPoints);
            
        }
        /// <summary>
        /// 發牌至指定對象之手牌區
        /// </summary>
        public void DealTo(BlackJackHand hand, CardHandLayout layout, bool showUp = true)
        {
            //荷官發牌至指定手牌對象定位
            PlayingCard card = _dealer.DealTo(layout.Root, showUp);
            hand.Add(card); // 資料納管
            layout.Refresh(); // 視覺更新

        }
        /// <summary>
        /// 玩家回合可操作：再要一張牌(回合判定是否爆牌)
        /// </summary>
        public void Hit()
        {
            if (!_round.CanPlayerAct) return; //避免非玩家可行動誤觸
            //發一張牌到玩家(資料)
            DealTo(PlayerHand, _playerLayout);
            //視覺(玩家點數物件名，玩家的點數)
            UpdatePointsUI(_playerPointsLabel, PlayerPoints);
            if (_round.CheckBust())
            {
                UpdatePointsUI(_dealerPointsLabel, DealerPoints);
                _dealer.ShowUpAll();
            }
            UpdateBtnUI();//更新對應的UI
        }
        /// <summary>
        /// 玩家回合可操作：放棄加牌(進到荷官回合)
        /// </summary>
        public void Stand()
        {
            _round.TryStand();
            RunDealerTurn();
        }

        public void NextRound()
        {
            _dealer.CollectAll();
            _round.TryNewGame();
            UpdatePointsUI(_playerPointsLabel, PlayerPoints);
            UpdatePointsUI(_dealerPointsLabel, DealerPoints);
        }
        #endregion 公開方法

        #region 私有方法

        private void RunDealerTurn()
        {
            while (_dealerStrategy.ShouldHit(DealerHand))
            {
                DealTo(DealerHand, _dealerLayout);
                _dealerLayout.Refresh();
            }
            //荷官回合結束攤牌
            UpdatePointsUI(_dealerPointsLabel, DealerPoints);
            _round.TryComplete();
        }
        /// <summary>
        /// 依照遊戲狀態機啟動對應的UI
        /// </summary>
        private void UpdateBtnUI()
        {
            //簡寫法?檢查物件是否存在
            //開始紐?物件.是否可見.(指定狀態：回合準備中)
            _startBtn?.gameObject.SetActive(_round.State ==
                BlackJackRoundState.WaitingForRound);
            //要牌/停牌?.物件.是否可見(指定狀態：玩家回合)
            _hitBtn?.gameObject.SetActive(_round.State ==
                BlackJackRoundState.PlayerTurn);
            _standBtn?.gameObject.SetActive(_round.State ==
                BlackJackRoundState.PlayerTurn);
            //下回合紐
            _nextRoundBtn?.gameObject.SetActive(_round.State != BlackJackRoundState.WaitingForRound &&
                _round.State != BlackJackRoundState.PlayerTurn);

        }
        /// <summary>
        /// 更新點數的方法
        /// </summary>
        /// <param name="tmpText">UI元件</param>
        /// <param name="points">當下點數</param>
        private void UpdatePointsUI(TMP_Text tmpText, int points)
        {
            tmpText.text = points > 0 ? $"{points}   " : "";
        }
        #endregion 私有方法
    }
}