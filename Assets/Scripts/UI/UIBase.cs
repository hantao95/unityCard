using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 界面基类
/// </summary>
public class UIBase : MonoBehaviour
{
    //注册事件
    public UIEventTrigger Register(string name)
    {
        GameObject obj = transform.Find(name).gameObject;
        return UIEventTrigger.Get(obj);
    }

    //显示页面
    public virtual void Show()
    {
       gameObject.SetActive(true);
    }
    //隐藏界面
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    //关闭界面（销毁）
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }
 

}
