using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���˻غ�
public class Fight_EnemyTurn : FightUnit
{
    public override void Init()
    {
        //ɾ�����п���
        UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCards();
        //��ʾ���˻غ���ʾ
        UIManager.Instance.ShowTip("�з��غ�", Color.red, delegate ()
        {
            FightManager.Instance.StartCoroutine(EnemyManager.Instance.DoAllEnemyAction());

        });
    }
    public override void OnUpdate()
    {
        
    }
}

