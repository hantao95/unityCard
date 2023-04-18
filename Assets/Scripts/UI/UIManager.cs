using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//UI管理器
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//画布的变换组件

    private List<UIBase> uiList ;//储存加载过的界面列表
    private void Awake()
    {
        Instance = this;
        //找世界中的画布
        canvasTf = GameObject.Find("Canvas").transform;
        //初始化集合
        uiList = new List<UIBase>();
    }

    //显示
    public UIBase ShowUI<T>(string uiName ) where T : UIBase
    {
        //判断集合中是否有这个界面
        UIBase ui = Find(uiName);
        if (ui == null) //如果没有，需要从文件中加载
        {
            //加载界面
            GameObject uiGo = Resources.Load<GameObject>("UI/" + typeof(T).Name);
            uiGo = Instantiate(uiGo, canvasTf);
            //改名字
            uiGo.name = uiName;
            //添加需要的脚本
            ui = uiGo.AddComponent<T>();
            //添加到集合中
            uiList.Add(ui);
        }
        //显示界面
        ui.Show();
        return ui;
    }

    //隐藏
    public void HideUI(string uiName)
    {
        //判断集合中是否有这个界面
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
    }

    //关闭（销毁）
    public void CloseUI(string uiName)
    {
        //判断集合中是否有这个界面
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //关闭所有界面
    public void CloseAllUI()
    {
        for (int i = uiList.Count-1; i>=0 ; i--)
        {
            Destroy(uiList[i].gameObject);
        }
        uiList.Clear();
    }

    public UIBase Find(string uiName)
    {
        return uiList.Find((UIBase obj) => { return obj.name == uiName; });
    }

    //获得某个界面的脚本
    public T GetUI<T>(string uiName) where T:UIBase
    {
        UIBase ui = Find(uiName);
        if(ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }

    //创建敌人头部的行动图标
    public GameObject CreateEnemyHeadIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"),canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//设置在父级的第一位
        return obj;
    }

    //创建敌人的血条
    public GameObject CreateEnemyHpBar()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//设置在父级的第一位
        return obj;
    }

    //提示界面
    public void ShowTip(string msg,Color color,System.Action callback=null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        Text text = obj.transform.Find("bg/Text").GetComponent<Text>() ;
        text.text = msg ;
        text.color = color;
        Tween scale1 = obj.transform.Find("bg").DOScaleY(1,0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScaleY(0, 0.4f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        });
        MonoBehaviour.Destroy(obj,2);
    }

}
