using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʤ��
public class Fight_Win : FightUnit

{
    override public void Init()
    {
        FightManager.Instance.StopAllCoroutines();
        Debug.Log("��Ϸʤ��");
    }
    override public void OnUpdate()
    {
        
    }
}
