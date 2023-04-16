using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//战斗界面 
public class FightUI : UIBase
{
    private Text cardCountText;//卡牌数量
    private Text usedCardCountText;//已使用卡牌数量
    private Text hpText;//血量
    private Image hpimg;
    private Text powerText;//能量
    private Text defenseText;//护盾
    private void Awake()
    {
        cardCountText = transform.Find("hasCard/icon/Text").GetComponent<Text>();
        usedCardCountText = transform.Find("noCard/icon/Text").GetComponent<Text>();
        hpText = transform.Find("hp/moneyTxt").GetComponent<Text>();
        hpimg = transform.Find("hp/fill").GetComponent<Image>();
        powerText = transform.Find("mana/Text").GetComponent<Text>();
        defenseText = transform.Find("hp/fangyu/Text").GetComponent<Text>();
    }

    public void Start()
    {
        UpdateAll();
    }

    public void UpdateAll()
    {
        UpdateHp();
        UpdatePower();
        UpdateDefense();
        UpdateCardCount();
        UpdateUsedCardCount();
    }

    //更新血量显示
    public void UpdateHp()
    {
        hpText.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpimg.fillAmount = (float)FightManager.Instance.CurHp / FightManager.Instance.MaxHp;
    }
    //更新能量
    public void UpdatePower()
    {
        powerText.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }
    //更新防御
    public void UpdateDefense()
    {
        defenseText.text = FightManager.Instance.DefenseCount.ToString();
    }

    //更新卡堆数量
    public void UpdateCardCount()
    {
        cardCountText.text = FightCardManager.instance.cardList.Count.ToString();
    }
    //更新弃牌堆数量
    public void UpdateUsedCardCount()
    {
        usedCardCountText.text = FightCardManager.instance.usedCardList.Count.ToString();
    }


}
