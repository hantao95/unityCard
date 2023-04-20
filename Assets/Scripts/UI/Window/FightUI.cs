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
        cardCountText.text = FightCardManager.Instance.cardList.Count.ToString();
    }
    //�������ƶ�����
    public void UpdateUsedCardCount()
    {
        usedCardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }

    //��������ʵ��
    public void CreateCardItem(int count)
    {
        if(count > FightCardManager.Instance.cardList.Count)
        {
            count = FightCardManager.Instance.cardList.Count;
        }
        for(int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(Resources.Load("UI/CardItem"),transform) as GameObject;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1000, -1000);
            //var item = obj.AddComponent<CardItem>();
            string cardId = FightCardManager.Instance.DrawCard();
            Dictionary<string,string> data = GameConfigManager.Instance.GetCardById(cardId);
            CardItem item = obj.AddComponent(System.Type.GetType(data["Script"])) as CardItem;
            item.Init(data);
            cardItemList.Add(item);
        }
    }
    //���¿���λ��
    public void UpdateCardPos()
    {
        float offset = 800.0f / cardItemList.Count;
        Vector2 startPos = new Vector2(-cardItemList.Count/2.0f * offset + offset * 0.5f,-1000 );
        for(int i = 0;i < cardItemList.Count;i++)
        {
            cardItemList[i].GetComponent<RectTransform>().DOAnchorPos( startPos,0.5f);
            startPos.x = startPos.x+offset;
        }
    }

    //ɾ����������
    public void RemoveCard(CardItem item)
    {
        AudioManager.Instance.PlayEffect("Cards/cardShove");//�Ƴ���Ч
        item.enabled = false;//���ÿ���
        //��ӵ����ƶ�
        FightCardManager.Instance.usedCardList.Add(item.data["Id"]);
        cardItemList.Remove(item);
        //����ʹ�ú�Ŀ�������
        cardCountText.text = FightCardManager.Instance.cardList.Count.ToString();
        usedCardCountText.text = FightCardManager.Instance.usedCardList.Count.ToString();
        UpdateCardPos();//ˢ�¿���λ��
        //�����ƶ������ƶ�Ч��
        item.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1000, -1000), 0.25f);
        item.transform.DOScale(0, 0.25f);
        Destroy(item.gameObject,1);

    }
}
