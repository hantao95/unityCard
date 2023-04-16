using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//开始界面 继承UIbase
public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("bg/startBtn").onClick = OnStartGameBtn;
    }

    private void OnStartGameBtn(GameObject go, PointerEventData eventData)
    {
        //关闭开始界面
        Close();
        //战斗初始化
        FightManager.Instance.ChangeFightType(FightType.Init);
        
    }
}
