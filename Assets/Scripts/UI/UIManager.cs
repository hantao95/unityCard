using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI������
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//�����ı任���
    private void Awake()
    {
        Instance = this;
        //�������еĻ���
        canvasTf = GameObject.Find("Canvas").transform;
    }
}
