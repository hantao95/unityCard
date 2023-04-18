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
    private GameConfigData cardTypeData;//�������ͱ�

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
        //��ȡ�������ͱ�
        string cardTypeStr = Resources.Load<TextAsset>("Data/cardType").text;
        cardTypeData = new GameConfigData(cardTypeStr);
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
    //��ȡ�������ͱ�
    public List<Dictionary<string, string>> GetCardTypeLines()
    {
        return cardTypeData.GetLines();
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
    public Dictionary<string, string> GetCardTypeById(string id)
    {
        return cardTypeData.GetOneById(id);
    }
}
