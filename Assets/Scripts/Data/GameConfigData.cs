using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//游戏配置表类 每个对象对应一个配置表
public class GameConfigData 
{
    private List<Dictionary<string, string>> dataDic;//储存配置表中的所有数据

    public GameConfigData(string str)
    {
        dataDic = new List<Dictionary<string, string>>();
        //换行切割
        string[] lines = str.Split("\n");
        //第一行是数据类型
        string[] title = lines[0].Trim().Split("\t");
        //从第三行开始遍历
        for (int i = 2; i < lines.Length; i++)
        {
            //切割每一行
            string[] values = lines[i].Trim().Split("\t");
            //创建一个字典
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //遍历每一行的数据
            for (int j = 0; j < values.Length; j++)
            {
                //添加到字典中
                dic.Add(title[j], values[j]);
            }
            //添加到数据字典中
            dataDic.Add(dic);
        }
    }

    public List<Dictionary<string, string>> GetLines()
    {
        return dataDic;
    }

    public Dictionary<string, string> GetOneById(string id)
    {
        for (int i = 0; i < dataDic.Count; i++)
        {
            if (dataDic[i]["Id"] == id)
            {
                return dataDic[i];
            }
        }
        return null;
    }
}
