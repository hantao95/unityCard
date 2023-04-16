using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用户信息管理器（拥有的卡牌，金币等信息）
public class RoleManager 
{
    public static RoleManager Instance = new RoleManager();

    public List<string> cardList;//拥有的卡牌id列表

    public void Init()
    {
        cardList = new List<string>();
        //四张攻击牌 四张防御牌 两张道具牌
        cardList.Add("1000");
        cardList.Add("1000");
        cardList.Add("1000");
        cardList.Add("1000");

        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");
        cardList.Add("1001");

        cardList.Add("1002");
        cardList.Add("1002");
    }
}
