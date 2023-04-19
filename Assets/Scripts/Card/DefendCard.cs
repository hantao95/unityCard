using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//������
public class DefendCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse())
        {
            //ʹ��Ч��
            int val = int.Parse(data["Arg0"]);
            //����ʹ�ú����Ч(���ܲ�һ��)
            AudioManager.Instance.PlayEffect("Effect/healspell");//����������õ�����

            //ˢ�·�����
            FightManager.Instance.DefenseCount += val;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateDefense();
            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);
        }
        else
        {
            base.OnEndDrag(eventData);
        }
        
    }
}
