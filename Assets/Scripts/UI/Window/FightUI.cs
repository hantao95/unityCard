using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//ս������ 
public class FightUI : UIBase
{
    private Text cardCountText;//��������
    private Text usedCardCountText;//��ʹ�ÿ�������
    private Text hpText;//Ѫ��
    private Image hpimg;
    private Text powerText;//����
    private Text defenseText;//����
    private List<CardItem> cardItemList;//���濨������ļ���
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

    //����Ѫ����ʾ
    public void UpdateHp()
    {
        hpText.text = FightManager.Instance.CurHp + "/" + FightManager.Instance.MaxHp;
        hpimg.fillAmount = (float)FightManager.Instance.CurHp / FightManager.Instance.MaxHp;
    }
    //��������
    public void UpdatePower()
    {
        powerText.text = FightManager.Instance.CurPowerCount + "/" + FightManager.Instance.MaxPowerCount;
    }
    //���·���
    public void UpdateDefense()
    {
        defenseText.text = FightManager.Instance.DefenseCount.ToString();
    }

    //���¿�������
    public void UpdateCardCount()
    {
        cardCountText.text = FightCardManager.instance.cardList.Count.ToString();
    }
    //�������ƶ�����
    public void UpdateUsedCardCount()
    {
        usedCardCountText.text = FightCardManager.instance.usedCardList.Count.ToString();
    }

    //��������ʵ��
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
    //���¿���λ��
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
