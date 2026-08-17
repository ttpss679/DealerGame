using DealerGame.core;
using TMPro;
using UnityEngine;
namespace DealerGame.View
{
    public class CardView : MonoBehaviour
    {
        #region UI元件
        [SerializeField]//強制將私有欄位顯示在編輯器
        private TMP_Text _suitLabel;
        [SerializeField]
        private TMP_Text _rankLabel;
        #endregion UI元件

        #region 公開方法
        public void Bind(PlayingCard card)
        {
            _suitLabel.text = GetSuitText(card.Suit);
            _rankLabel.text = GetRankText(card.Rank);


        }
        #endregion 公開方法

        #region 私有方法
        private string GetRankText(Rank rank)
        {
            switch (rank)
            {
                case Rank.Ace: return  "A";
                case Rank.Jack: return "J";
                case Rank.Queen: return "Q";
                case Rank.King: return "K";
            }
                return((int)rank).ToString();
        }

        private string GetSuitText(Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts: return "♥";
                case Suit.Diamonds: return "♦";
                case Suit.Clubs: return "♣";
                case Suit.Spades: return "♠";
            }
            return suit.ToString();
        }

        #endregion 私有方法





    }
}
