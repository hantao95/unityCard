using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;


//敌人的行动枚举
public enum EnemyActionType
{
    None,
    Attack,//攻击
    Defend,//防御
}

/// <summary>
/// 敌人脚本
/// </summary>
public class Enemy : MonoBehaviour
{
    protected Dictionary<string, string> data;//敌人数据表信息

    public EnemyActionType actionType;

    public GameObject hpItemObj;
    public GameObject actionObj;


    //UI相关
    public Transform attackTransform;
    public Transform defendTransform;
    public Text defendTxt;
    public Text hpTxt;
    public Image hpImg;

    //数值相关
    public int MaxHp;//最大血量
    public int CurHp;//当前血量
    public int Attack;//攻击力
    public int Defense;//防御力

    //组件相关
    SkinnedMeshRenderer _meshRenderer;
    public Animator ani;

    public void Init(Dictionary<string, string> data)
    {
        this.data = data;
    }
    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        ani = transform.GetComponent<Animator>();

        actionType = EnemyActionType.None;
        hpItemObj = UIManager.Instance.CreateEnemyHpBar();
        actionObj = UIManager.Instance.CreateEnemyHeadIcon();

        attackTransform = actionObj.transform.Find("attack");
        defendTransform = actionObj.transform.Find("defend");

        hpTxt = hpItemObj.transform.Find("moneyTxt").GetComponent<Text>();
        hpImg = hpItemObj.transform.Find("fill").GetComponent<Image>();
        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();

        //设置血条 行动标志位置
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.down*0.2F);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);

        RandomAction();
        //Hp	Attack	Defend
        //初始化数值
        Attack = int.Parse(data["Attack"]);
        Defense = int.Parse(data["Defend"]);
        MaxHp = int.Parse(data["Hp"]);
        CurHp = MaxHp;

        UpdateHp();
        UpdateDefense();


    }

    //随机一个行动
    public void RandomAction()
    {
        int action = Random.Range(1, 3);
        actionType = (EnemyActionType)action;
        switch (actionType)
        {
             case EnemyActionType.None:
                break;
            case EnemyActionType.Attack:
                attackTransform.gameObject.SetActive(true);
                defendTransform.gameObject.SetActive(false);
                break;
            case EnemyActionType.Defend:
                attackTransform.gameObject.SetActive(false);
                defendTransform.gameObject.SetActive(true);
                break;
        }
    }

    //更新血量显示
    public void UpdateHp()
    {
        hpTxt.text = CurHp + "/" + MaxHp;
        hpImg.fillAmount = (float)CurHp / MaxHp;
    }
    //更新防御
    public void UpdateDefense()
    {
        defendTxt.text = Defense.ToString();
    }

    //被卡牌选中，显示红边
    public void OnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.red);
    }

    //未选中
    public void OnUnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.black);
    }

    //受伤
    public void Hit(int val)
    {
        //先扣护盾
        if (Defense>=val)
        {
            //扣护盾
            Defense -= val;
            //播放受伤
            ani.Play("hit", 0, 0);
        }
        else
        {
            val = val - Defense;
            Defense = 0;
            CurHp -= val;
            if(CurHp < 0)
            {
                CurHp = 0;
                //播放死亡
                ani.Play("die");
                //从敌人列表移除
                EnemyManager.Instance.RemoveEnemy(this);

                Destroy(gameObject, 1);
                Destroy(actionObj);
                Destroy(hpItemObj);

            }
            else
            {
                //受伤
                ani.Play("hit", 0, 0);
            }
        }
        //刷新血量等UI
        UpdateDefense();
        UpdateHp();
    }
}
