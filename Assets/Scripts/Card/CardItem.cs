using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public Dictionary<string, string> data;//������Ϣ

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
}
