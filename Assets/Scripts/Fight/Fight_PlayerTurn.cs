using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һغ�
public class Fight_PlayerTurn : FightUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate ()
        {
            //�ָ��ж���
            FightManager.Instance.CurPowerCount = FightManager.Instance.MaxPowerCount;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdatePower();

            //����û�п��ƣ����³�ʼ��
            if (FightCardManager.Instance.HasCard() == false)
            {
                FightCardManager.Instance.Init();
                //�������Ӷ�����
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateUsedCardCount();
            }
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//��4����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardPos();

            //���¿�����
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardCount();
        });
    }
    public override void OnUpdate()
    {
        
    }
}

