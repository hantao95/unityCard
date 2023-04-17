using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//战斗界面 
public class FightUI : UIBase
{
    private Text cardCountText;//卡牌数量
    private Text usedCardCountText;//已使用卡牌数量
    private Text hpText;//血量
    private Image hpimg;
    private Text powerText;//能量
    private Text defenseText;//护盾
    private List<CardItem> cardItemList;//储存卡牌物体的集合
    private void Awake()
    {
        cardItemList = new List<CardItem>();
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

    //创建卡牌实体
    public void CreateCardItem(int count)
    {
        if(count > FightCardManager.instance.cardList.Count)
        {
            count = FightCardManager.instance.cardList.Count;
        }
        for(int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"),transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -700);
            var item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.instance.DrawCard();
            Dictionary<string,string> data = GameConfigManager.Instance.GetCardById(cardId);
            item.Init(data);
            cardItemList.Add(item);
        }
    }
    //更新卡牌位置
    public void UpdateCardPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count/2.0f * offset + offset * 0.5f,-700 );
        for(int i = 0;i < cardItemList.Count;i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos( startPos,0.5f);
            startPos.x = startPos.x+offset;
        }
    }
}
