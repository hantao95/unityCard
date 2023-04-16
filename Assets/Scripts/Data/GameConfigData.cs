using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��Ϸ���ñ��� ÿ�������Ӧһ�����ñ�
public class GameConfigData 
{
    private List<Dictionary<string, string>> dataDic;//�������ñ��е���������

    public GameConfigData(string str)
    {
        dataDic = new List<Dictionary<string, string>>();
        //�����и�
        string[] lines = str.Split("\n");
        //��һ������������
        string[] title = lines[0].Trim().Split("\t");
        //�ӵ����п�ʼ����
        for (int i = 2; i < lines.Length; i++)
        {
            //�и�ÿһ��
            string[] values = lines[i].Trim().Split("\t");
            //����һ���ֵ�
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //����ÿһ�е�����
            for (int j = 0; j < values.Length; j++)
            {
                //��ӵ��ֵ���
                dic.Add(title[j], values[j]);
            }
            //��ӵ������ֵ���
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
