using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�鿨
public class AddCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if( TryUse())
        {
            int val = int.Parse(data["Arg0"]);
            //����ʹ�ú����Ч(���ܲ�һ��)
            AudioManager.Instance.PlayEffect("Effect/healspell");//����������õ�����
            if (FightCardManager.Instance.HasCard()==true)
            { 
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(val);
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardPos();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f));

                PlayEffect(pos);
            }
            else
            {
                base.OnEndDrag(eventData);
            }
        }
        else
        {
            base.OnEndDrag(eventData);
        }
       
    }
}
