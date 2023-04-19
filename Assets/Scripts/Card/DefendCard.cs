using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//防御卡
public class DefendCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse())
        {
            //使用效果
            int val = int.Parse(data["Arg0"]);
            //播发使用后的音效(可能不一样)
            AudioManager.Instance.PlayEffect("Effect/healspell");//这个可以配置到表中

            //刷新防御力
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
