using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏入口脚本
public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //初始化游戏配置表
        GameConfigManager.Instance.init();
        //初始化音频管理器
        AudioManager.Instance.Init();

        //初始化用户信息
        RoleManager.Instance.Init();

        //创建的UI名字要和预制体的名字保持一致
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //播放bgm
        AudioManager.Instance.PlayBGM("bgm1");

        //test
        string name = GameConfigManager.Instance.GetCardById("1001")["Name"];
        print(name);
    }

    
}
