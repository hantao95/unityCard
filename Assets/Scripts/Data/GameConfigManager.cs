using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ���ñ������
public class GameConfigManager 
{
   public static GameConfigManager Instance = new GameConfigManager();

    private GameConfigData cardData;//���Ʊ�
    private GameConfigData enemyData;//���˱�
    private GameConfigData levelData;//�ؿ���

    public void init()
    {
        //��ȡ���Ʊ�
        string cardStr = Resources.Load<TextAsset>("Data/card").text;
        cardData = new GameConfigData(cardStr);
        //��ȡ���˱�
        string enemyStr = Resources.Load<TextAsset>("Data/enemy").text;
        enemyData = new GameConfigData(enemyStr);
        //��ȡ�ؿ���
        string levelStr = Resources.Load<TextAsset>("Data/level").text;
        levelData = new GameConfigData(levelStr);
    }
    //��ȡ���Ʊ�
    public List<Dictionary<string,string>> GetCardLines()
    {
        return cardData.GetLines();
    }
    //��ȡ���˱�
    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.GetLines();
    }
    //��ȡ�ؿ���
    public List<Dictionary<string, string>> GetLevelLines()
    {
        return levelData.GetLines();
    }

    public Dictionary<string, string> GetCardById(string id)
    {
        return cardData.GetOneById(id);
    }
    public Dictionary<string, string> GetEnemyById(string id)
    {
        return enemyData.GetOneById(id);
    }
    public Dictionary<string, string> GetLevelById(string id)
    {
        return levelData.GetOneById(id);
    }
}
