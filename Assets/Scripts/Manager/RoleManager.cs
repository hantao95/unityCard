using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�û���Ϣ��������ӵ�еĿ��ƣ���ҵ���Ϣ��
public class RoleManager 
{
    public static RoleManager Instance = new RoleManager();

    public List<string> cardList;//ӵ�еĿ���id�б�

    public void Init()
    {
        cardList = new List<string>();
        //���Ź����� ���ŷ����� ���ŵ�����
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
