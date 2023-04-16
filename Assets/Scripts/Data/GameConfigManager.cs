using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏配置表管理类
public class GameConfigManager 
{
   public static GameConfigManager Instance = new GameConfigManager();

    private GameConfigData cardData;//卡牌表
    private GameConfigData enemyData;//敌人表
    private GameConfigData levelData;//关卡表

    public void init()
    {
        //读取卡牌表
        string cardStr = Resources.Load<TextAsset>("Data/card").text;
        cardData = new GameConfigData(cardStr);
        //读取敌人表
        string enemyStr = Resources.Load<TextAsset>("Data/enemy").text;
        enemyData = new GameConfigData(enemyStr);
        //读取关卡表
        string levelStr = Resources.Load<TextAsset>("Data/level").text;
        levelData = new GameConfigData(levelStr);
    }
    //获取卡牌表
    public List<Dictionary<string,string>> GetCardLines()
    {
        return cardData.GetLines();
    }
    //获取敌人表
    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.GetLines();
    }
    //获取关卡表
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
