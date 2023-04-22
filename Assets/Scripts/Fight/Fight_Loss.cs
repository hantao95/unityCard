using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ê§°Ü
public class Fight_Lose : FightUnit
{
    // Start is called before the first frame update
    override public void Init()
    {
        Debug.Log("Ê§°Ü");
        FightManager.Instance.StopAllCoroutines();
    }
    override public void OnUpdate()
    {

    }
}
