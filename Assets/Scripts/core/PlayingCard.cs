using System;
namespace DealerGame.core
{
    /// <summary>
    /// [類別]一張撲克牌的資料結構
    /// </summary>
    [Serializable]
    public class PlayingCard
    {
        #region 公開屬性
        /// <summary>
        /// [唯讀]取得花色
        /// </summary>
        public Suit Suit{ get; }
        /// <summary>
        /// [唯讀]取得點數
        /// </summary>
        public Rank Rank{ get; }
        /// <summary>
        /// 掀牌
        /// </summary>
        public bool IsShowUp { get; private set; } 
        #endregion 公開屬性

        #region 建構式
        /// <summary>
        /// 建立一張撲克牌
        /// </summary>
        /// <param name="suit">花色</param>
        /// <param name="rank">點數</param>
        /// <param name="showUp">是否翻開</param>
        public PlayingCard(Suit suit, Rank rank , bool showUp=true)
        {
            Suit = suit;//作用是紀錄在上方的欄位中
            Rank = rank;
            IsShowUp = showUp;
        }
        #endregion 建構式

        #region 公開方法
        /// <summary>
        /// 掀牌
        /// </summary>
        public void ShowUp()
        {
            IsShowUp = true;
        }
        /// <summary>
        /// 蓋排
        /// </summary>
        public void Hide()
        {
            IsShowUp = false;
        }
        /// <summary>
        /// 撲克牌資料的文字版
        /// </summary>
        /// <returns>花色+數值的文字</returns>
        public string Info()
        {
            return Suit.ToString() + (int)Rank;
        }
        #endregion 公開方法
    }

}

