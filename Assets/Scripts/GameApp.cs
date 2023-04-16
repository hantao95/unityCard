using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ��ڽű�
public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //��ʼ����Ϸ���ñ�
        GameConfigManager.Instance.init();
        //��ʼ����Ƶ������
        AudioManager.Instance.Init();

        //��ʼ���û���Ϣ
        RoleManager.Instance.Init();

        //������UI����Ҫ��Ԥ��������ֱ���һ��
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        //����bgm
        AudioManager.Instance.PlayBGM("bgm1");

        //test
        string name = GameConfigManager.Instance.GetCardById("1001")["Name"];
        print(name);
    }

    
}
