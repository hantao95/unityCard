using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ��ڽű�
public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������UI����Ҫ��Ԥ��������ֱ���һ��
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }

    
}
