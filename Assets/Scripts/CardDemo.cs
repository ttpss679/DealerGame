using DealerGame.core;
using UnityEngine;

public class CardDemo : MonoBehaviour
{
    //宣告類型 名稱
    public PlayingCard testCard = new PlayingCard();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // 按下play後執行一次，初始化
    void Start()
    {
        Debug.Log(testCard);


    }

    // Update is called once per frame
    // 遊戲的每一FPS每秒幀數 全名Frames Per Second，偵測操作/刷新內容
    void Update()
    {
        
    }
}
