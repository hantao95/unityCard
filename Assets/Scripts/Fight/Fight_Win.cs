using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ê¤Àû
public class Fight_Win : FightUnit

{
    override public void Init()
    {
        FightManager.Instance.StopAllCoroutines();
        Debug.Log("ÓÎÏ·Ê¤Àû");
    }
    override public void OnUpdate()
    {
        
    }
}
