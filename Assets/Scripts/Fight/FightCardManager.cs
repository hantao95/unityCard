using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
   public static FightCardManager instance = new FightCardManager();

    public List<string> cardList;//卡堆

    public List<string> usedCardList;//已使用卡堆

    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();
        //定义临时集合
        List<string> tempList = new List<string>();
        //将玩家的卡牌存到临时集合
        tempList.AddRange(RoleManager.Instance.cardList);
        while (tempList.Count > 0)
        {
            //随机获取一个卡牌
            int index = Random.Range(0, tempList.Count);
            //将随机到的卡牌添加到卡堆
            cardList.Add(tempList[index]);
            //将随机到的卡牌从临时集合中移除
            tempList.RemoveAt(index);
        }

        Debug.Log(cardList.Count);

    }
}
