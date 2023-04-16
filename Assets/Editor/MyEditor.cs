using Excel;
using System.Data;
using System.IO;
using UnityEditor; //����༭�������ռ�
using UnityEngine;


//�༭���ű�
public static class MyEditor
{
    [MenuItem("�ҵĹ���/excelתtxt")]
    public static void ExportExcelToTxt()
    {
        string assetPath = Application.dataPath + "/_Excel";

        //���excel�ļ����е� excel�ļ�
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");
        for(int i = 0; i < files.Length; i++)
        {
            //��б���滻����б��
            files[i] = files[i].Replace("\\", "/");
            //ͨ���ļ�����ȡ�ļ�
            using (FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                //�ļ���ת��excel����
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //���excel����
                DataSet dataSet = excelDataReader.AsDataSet();
                //��ȡexcel�ĵ�һ�ű�
                DataTable dataTable = dataSet.Tables[0];
                //���������ݴ洢����Ӧ��txt��
                ReadTableToTxt(files[i], dataTable);
            }
        }
        //ˢ�±༭��
        AssetDatabase.Refresh();
        
    }

    private static void ReadTableToTxt(string filePath, DataTable dataTable)
    {
        //����ļ��� û�к�׺
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        //txt �ļ��Ĵ洢·��
        string path = Application.dataPath + "/Resources/Data/"+fileName+".txt";
        //�ж��ļ��Ƿ���ڣ����������ɾ��
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        //�����ļ��� ,���� txt �ļ�
        using(FileStream fs = new FileStream(path, FileMode.Create))
        {
            //�ļ���תд����������д���ַ���
            using(StreamWriter sw = new StreamWriter(fs))
            {
                //����table
                for(int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];
                    string str = "";
                    //������
                    for(int col = 0;col< dataTable.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();
                        str = str + val +"\t"; //ÿһ��tab�ָ�
                    }
                    //д��
                    sw.Write(str);
                    //����������һ�У�����
                    if(row!= dataTable.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
