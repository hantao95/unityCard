using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������
/// </summary>
public class UIBase : MonoBehaviour
{
    //ע���¼�
    public UIEventTrigger Register(string name)
    {
        GameObject obj = transform.Find(name).gameObject;
        return UIEventTrigger.Get(obj);
    }

    //��ʾҳ��
    public virtual void Show()
    {
       gameObject.SetActive(true);
    }
    //���ؽ���
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    //�رս��棨���٣�
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }
 

}
