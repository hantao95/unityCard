using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//��ʼ���� �̳�UIbase
public class LoginUI : UIBase
{
    private void Awake()
    {
        Register("bg/startBtn").onClick = OnStartGameBtn;
    }

    private void OnStartGameBtn(GameObject go, PointerEventData eventData)
    {
        //�����ʼ��Ϸ��ť
        Debug.Log("�����ʼ��Ϸ��ť");
        //�رտ�ʼ����
        Close();
        
        
    }
}
