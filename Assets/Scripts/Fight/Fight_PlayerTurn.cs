using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        Debug.Log("��һغ�");
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//��4����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardPos();
        });
    }
    public override void OnUpdate()
    {
        
    }
}

