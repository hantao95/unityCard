using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("玩家回合");
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()
        {
            //抽牌
            Debug.Log("抽牌");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//抽4张牌
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardPos();
        });
    }
    public override void OnUpdate()
    {
        
    }
}

