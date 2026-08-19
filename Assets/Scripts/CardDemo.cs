using DealerGame.core;
using DealerGame.View;
using UnityEngine;

public class CardDemo : MonoBehaviour
{
    //宣告類型 名稱
    public PlayingCard testCard = new PlayingCard(Suit.Spades, Rank.King);
    public CardView cardView;

    /// <summary>
    /// 建立整副牌
    /// </summary>
    private Deck _deck = new Deck();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 按下play後執行一次，初始化
    void Start()
    {
        Debug.Log(testCard.Info());
        //視覺顯示.綁定(卡牌資料)
        cardView.Bind(testCard);
        testCard = _deck.Draw();
    }

    // Update is called once per frame
    // 遊戲的每一FPS每秒幀數 全名Frames Per Second，偵測操作/刷新內容
    void Update()
    {
        //視覺顯示.綁定(卡牌資料)
        cardView.Bind(testCard);
    }
}
