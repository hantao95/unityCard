using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʧ��
public class Fight_Lose : FightUnit
{
    // Start is called before the first frame update
    override public void Init()
    {
        Debug.Log("ʧ��");
        FightManager.Instance.StopAllCoroutines();
    }
    override public void OnUpdate()
    {

    }
}
