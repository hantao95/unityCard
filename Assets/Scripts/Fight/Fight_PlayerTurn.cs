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
        });
    }
    public override void OnUpdate()
    {
        
    }
}

