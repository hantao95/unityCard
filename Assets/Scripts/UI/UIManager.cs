using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

//UI������
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//�����ı任���

    private List<UIBase> uiList ;//������ع��Ľ����б�
    private void Awake()
    {
        Instance = this;
        //�������еĻ���
        canvasTf = GameObject.Find("Canvas").transform;
        //��ʼ������
        uiList = new List<UIBase>();
    }

    //��ʾ
    public UIBase ShowUI<T>(string uiName ) where T : UIBase
    {
        //�жϼ������Ƿ����������
        UIBase ui = Find(uiName);
        if (ui == null) //���û�У���Ҫ���ļ��м���
        {
            //���ؽ���
            GameObject uiGo = Resources.Load<GameObject>("UI/" + typeof(T).Name);
            uiGo = Instantiate(uiGo, canvasTf);
            //������
            uiGo.name = uiName;
            //�����Ҫ�Ľű�
            ui = uiGo.AddComponent<T>();
            //��ӵ�������
            uiList.Add(ui);
        }
        //��ʾ����
        ui.Show();
        return ui;
    }

    //����
    public void HideUI(string uiName)
    {
        //�жϼ������Ƿ����������
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
    }

    //�رգ����٣�
    public void CloseUI(string uiName)
    {
        //�жϼ������Ƿ����������
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    //�ر����н���
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

    //���ĳ������Ľű�
    public T GetUI<T>(string uiName) where T:UIBase
    {
        UIBase ui = Find(uiName);
        if(ui != null)
        {
            return ui.GetComponent<T>();
        }
        return null;
    }

    //��������ͷ�����ж�ͼ��
    public GameObject CreateEnemyHeadIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"),canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }

    //�������˵�Ѫ��
    public GameObject CreateEnemyHpBar()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();//�����ڸ����ĵ�һλ
        return obj;
    }

    //��ʾ����
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
