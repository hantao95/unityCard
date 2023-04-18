using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public Dictionary<string, string> data;//卡牌信息

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }

    private void Start()
    {
        // Id                       Name    Script          Type    Des         BgIcon              Icon        Expend      Arg0 Effects
        //唯一的标识（不能重复）	名称 卡牌添加的脚本 卡牌类型的Id 描述  卡牌的背景图资源路径 图标资源的路径 消耗的费用 属性值 特效
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>( data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"], data["Arg0"]);
        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];
    }
}
