using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//战斗枚举
public enum FightType
{
    None,
    Init,
    Player,//玩家回合
    Enemy,//敌人回合
    Win,//胜利
    Loss//失败
}


/// <summary>
/// 战斗管理器
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//战斗单元

    public int MaxHp;//最大血量
    public int CurHp;//当前血量

    public int MaxPowerCount;//最大能量
    public int CurPowerCount;//当前能量
    public int DefenseCount;//护盾值

    public void Init()
    {
        MaxHp = 10;
        CurHp = 10;
        MaxPowerCount = 3;
        CurPowerCount = 3;
        DefenseCount = 10;
    }
    
    private void Awake()
    {
        Instance = this;
    }

    //切换战斗类型
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
        //初始化
        fightUnit.Init();
    }

    //玩家受伤逻辑
    public void GetPlayerHit(int hit)
    {
        //扣护盾
        if (DefenseCount>=hit)
        {
            DefenseCount -= hit;
        }
        else
        {
            hit = hit - DefenseCount;
            DefenseCount = 0;
            CurHp -= hit;
            if(CurHp <= 0)
            {
                CurHp = 0;
                //游戏失败
                ChangeFightType(FightType.Loss);
            }
        }
        //更新界面
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateHp();
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdateDefense();
    }


    private void Update()
    {
        if (fightUnit != null)
        {
            fightUnit.OnUpdate();
        }
    }
}
