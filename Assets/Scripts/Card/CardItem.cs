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

    private void Start()
    {
        // Id                       Name    Script          Type    Des         BgIcon              Icon        Expend      Arg0 Effects
        //Ψһ�ı�ʶ�������ظ���	���� ������ӵĽű� �������͵�Id ����  ���Ƶı���ͼ��Դ·�� ͼ����Դ��·�� ���ĵķ��� ����ֵ ��Ч
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>( data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"], data["Arg0"]);
        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];
    }
}
