using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public Dictionary<string, string> data;//ø®≈∆–≈œ¢

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
}
