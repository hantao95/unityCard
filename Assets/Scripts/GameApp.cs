using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏入口脚本
public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //创建的UI名字要和预制体的名字保持一致
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }

    
}
