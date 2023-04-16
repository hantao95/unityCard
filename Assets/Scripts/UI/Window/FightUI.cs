using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ս������ 
public class FightUI : UIBase
{
    private Text cardCountText;//��������
    private Text usedCardCountText;//��ʹ�ÿ�������
    private Text hpText;//Ѫ��
    private Image hpimg;
    private Text powerText;//����
    private Text defenseText;//����
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


}
