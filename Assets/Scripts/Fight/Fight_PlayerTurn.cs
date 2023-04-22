using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家回合
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate ()
        {
            //恢复行动力
            FightManager.Instance.CurPowerCount = FightManager.Instance.MaxPowerCount;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            //卡堆没有卡牌，重新初始化
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();
                //更新弃坑堆数量
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }
            //抽牌
            Debug.Log("抽牌");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//抽4张牌
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardPos();

            //更新卡牌数
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }
    public override void OnUpdate()
    {
        
    }
}

