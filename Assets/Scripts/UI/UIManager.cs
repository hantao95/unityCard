using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        Debug.Log("1");
        //判断集合中是否有这个界面
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            Debug.Log("2");
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
        Debug.Log("0");
        return uiList.Find((UIBase obj) => { return obj.name == uiName; });
    }

}
