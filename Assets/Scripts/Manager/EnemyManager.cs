using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人管理器
/// </summary>
public class EnemyManager 
{
    public static EnemyManager Instance = new EnemyManager();

    private List<Enemy> enemyList;//储存战斗中的敌人

    /// <summary>
    /// 加载敌人资源
    /// </summary>
    /// <param name="id">关卡id</param>
    public void LoadRes(string id)
    {
        enemyList = new List<Enemy>();
        //Id	Name	EnemyIds	Pos	
        //10003	3	10001=10002=10003	3,0,1=0,0,1=-3,0,1	
        //读取关卡表
        Dictionary<string,string> levelData = GameConfigManager.Instance.GetLevelById(id);

        //敌人ID信息
        string[] enemyIds = levelData["EnemyIds"].Split('=');
        //敌人位置信息
        string[] enemyPos = levelData["Pos"].Split('='); 
        //遍历获取敌人信息
        for (int i = 0; i < enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(",");
            //敌人位置
            float x = float.Parse(posArr[0]);
            float y = float.Parse(posArr[1]);
            float z = float.Parse(posArr[2]);
            
            Dictionary<string,string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject;

            Enemy enemy = obj.AddComponent<Enemy>();
            enemy.Init(enemyData);
            enemyList.Add(enemy);

            obj.transform.position = new Vector3(x, y, z);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        //后续做是否击杀所有怪判断
        if (enemyList.Count==0)
        {
            FightManager.Instance.ChangeFightType(FightType.Win);
        }
    }

    //执行活着的怪物的行为
    public IEnumerator DoAllEnemyAction()
    {
        for(int i = 0;i < enemyList.Count; i++)
        {
            yield return FightManager.Instance.StartCoroutine(enemyList[i].DoAction());
        }
        //行动后 更新所有敌人行为
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].RandomAction();
        }

        //切换到玩家回合
        FightManager.Instance.ChangeFightType(FightType.Player);

    }

}
