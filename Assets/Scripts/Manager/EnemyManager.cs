using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���˹�����
/// </summary>
public class EnemyManager 
{
    public static EnemyManager Instance = new EnemyManager();

    private List<Enemy> enemyList;//����ս���еĵ���

    /// <summary>
    /// ���ص�����Դ
    /// </summary>
    /// <param name="id">�ؿ�id</param>
    public void LoadRes(string id)
    {
        enemyList = new List<Enemy>();
        //Id	Name	EnemyIds	Pos	
        //10003	3	10001=10002=10003	3,0,1=0,0,1=-3,0,1	
        //��ȡ�ؿ���
        Dictionary<string,string> levelData = GameConfigManager.Instance.GetLevelById(id);

        //����ID��Ϣ
        string[] enemyIds = levelData["EnemyIds"].Split('=');
        //����λ����Ϣ
        string[] enemyPos = levelData["Pos"].Split('='); 
        //������ȡ������Ϣ
        for (int i = 0; i < enemyIds.Length; i++)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(",");
            //����λ��
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
        //�������Ƿ��ɱ���й��ж�
        if (enemyList.Count==0)
        {
            FightManager.Instance.ChangeFightType(FightType.Win);
        }
    }

    //ִ�л��ŵĹ������Ϊ
    public IEnumerator DoAllEnemyAction()
    {
        for(int i = 0;i < enemyList.Count; i++)
        {
            yield return FightManager.Instance.StartCoroutine(enemyList[i].DoAction());
        }
        //�ж��� �������е�����Ϊ
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].RandomAction();
        }

        //�л�����һغ�
        FightManager.Instance.ChangeFightType(FightType.Player);

    }

}
