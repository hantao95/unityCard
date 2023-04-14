using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI管理器
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//画布的变换组件
    private void Awake()
    {
        Instance = this;
        //找世界中的画布
        canvasTf = GameObject.Find("Canvas").transform;
    }
}
