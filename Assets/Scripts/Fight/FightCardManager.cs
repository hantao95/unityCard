using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager 
{
   public static FightCardManager instance = new FightCardManager();

    public List<string> cardList;//����

    public List<string> usedCardList;//��ʹ�ÿ���

    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();
        //������ʱ����
        List<string> tempList = new List<string>();
        //����ҵĿ��ƴ浽��ʱ����
        tempList.AddRange(RoleManager.Instance.cardList);
        while (tempList.Count > 0)
        {
            //�����ȡһ������
            int index = Random.Range(0, tempList.Count);
            //��������Ŀ������ӵ�����
            cardList.Add(tempList[index]);
            //��������Ŀ��ƴ���ʱ�������Ƴ�
            tempList.RemoveAt(index);
        }

        Debug.Log(cardList.Count);

    }
}