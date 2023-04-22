using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;


//���˵��ж�ö��
public enum EnemyActionType
{
    None,
    Attack,//����
    Defend,//����
}

/// <summary>
/// ���˽ű�
/// </summary>
public class Enemy : MonoBehaviour
{
    protected Dictionary<string, string> data;//�������ݱ���Ϣ

    public EnemyActionType actionType;

    public GameObject hpItemObj;
    public GameObject actionObj;


    //UI���
    public Transform attackTransform;
    public Transform defendTransform;
    public Text defendTxt;
    public Text hpTxt;
    public Image hpImg;

    //��ֵ���
    public int MaxHp;//���Ѫ��
    public int CurHp;//��ǰѪ��
    public int Attack;//������
    public int Defense;//������

    //������
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

        //����Ѫ�� �ж���־λ��
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.down*0.2F);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);

        RandomAction();
        //Hp	Attack	Defend
        //��ʼ����ֵ
        Attack = int.Parse(data["Attack"]);
        Defense = int.Parse(data["Defend"]);
        MaxHp = int.Parse(data["Hp"]);
        CurHp = MaxHp;

        UpdateHp();
        UpdateDefense();


    }

    //���һ���ж�
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

    //����Ѫ����ʾ
    public void UpdateHp()
    {
        hpTxt.text = CurHp + "/" + MaxHp;
        hpImg.fillAmount = (float)CurHp / MaxHp;
    }
    //���·���
    public void UpdateDefense()
    {
        defendTxt.text = Defense.ToString();
    }

    //������ѡ�У���ʾ���
    public void OnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.red);
    }

    //δѡ��
    public void OnUnSelect()
    {
        _meshRenderer.material.SetColor("_OtlColor", Color.black);
    }

    //����
    public void Hit(int val)
    {
        //�ȿۻ���
        if (Defense>=val)
        {
            //�ۻ���
            Defense -= val;
            //��������
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
                //��������
                ani.Play("die");
                //�ӵ����б��Ƴ�
                EnemyManager.Instance.RemoveEnemy(this);

                Destroy(gameObject, 1);
                Destroy(actionObj);
                Destroy(hpItemObj);

            }
            else
            {
                //����
                ani.Play("hit", 0, 0);
            }
        }
        //ˢ��Ѫ����UI
        UpdateDefense();
        UpdateHp();
    }

    //���ع���ͷ�ϵ��ж���־
    public void HideAction()
    {
        attackTransform.gameObject.SetActive(false);
        defendTransform.gameObject.SetActive(false);
    }

    //ִ�е����ж�
    public IEnumerator DoAction()
    {
        HideAction();
        //���Ŷ������������õ����У�����Ĭ�ϷŹ���������
        ani.Play("attack");
        //�ȴ�һ��ʱ���ִ�ж�Ӧ����Ϊ��Ҳ�����䵽���У�
        yield return new WaitForSeconds(0.5f);

        switch (actionType)
        {
            case EnemyActionType.None: 
                break;
            case EnemyActionType.Defend:
                Defense += 1;
                UpdateDefense();
                //���Բ��Ŷ�Ӧ����Ч
                break;
            case EnemyActionType.Attack:
                //��ҿ�Ѫ
                FightManager.Instance.GetPlayerHit(Attack);
                //�������һ��
                Camera.main.DOShakePosition(0.1f, 0.2f, 5, 45);

                break;
        }

        //�ȴ�����������
        yield return new WaitForSeconds(1);
        //���Ŵ���
        ani.Play("idle");
    }




}
