using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ս��ö��
public enum FightType
{
    None,
    Init,
    Player,//��һغ�
    Enemy,//���˻غ�
    Win,//ʤ��
    Loss//ʧ��
}


/// <summary>
/// ս��������
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//ս����Ԫ

    public int MaxHp;//���Ѫ��
    public int CurHp;//��ǰѪ��

    public int MaxPowerCount;//�������
    public int CurPowerCount;//��ǰ����
    public int DefenseCount;//����ֵ

    public void Init()
    {
        MaxHp = 10;
        CurHp = 10;
        MaxPowerCount = 10;
        CurPowerCount = 10;
        DefenseCount = 10;
    }
    
    private void Awake()
    {
        Instance = this;
    }

    //�л�ս������
    public void ChangeFightType(FightType fightType)
    {
        switch (fightType)
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                break;
            case FightType.Player:
                fightUnit = new Fight_PlayerTurn();
                break;
            case FightType.Enemy:
                fightUnit = new Fight_EnemyTurn();
                break;
            case FightType.Win:
                fightUnit = new Fight_Win();
                break;
            case FightType.Loss:
                fightUnit = new Fight_Lose();
                break;
            default:
                break;
        }
        //��ʼ��
        fightUnit.Init();
    }


    private void Update()
    {
        
    }
}