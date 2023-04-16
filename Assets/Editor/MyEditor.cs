using Excel;
using System.Data;
using System.IO;
using UnityEditor; //引入编辑器命名空间
using UnityEngine;


//编辑器脚本
public static class MyEditor
{
    [MenuItem("我的工具/excel转txt")]
    public static void ExportExcelToTxt()
    {
        string assetPath = Application.dataPath + "/_Excel";

        //获得excel文件夹中的 excel文件
        string[] files = Directory.GetFiles(assetPath, "*.xlsx");
        for(int i = 0; i < files.Length; i++)
        {
            //反斜杠替换成正斜杆
            files[i] = files[i].Replace("\\", "/");
            //通过文件流读取文件
            using (FileStream fs = File.Open(files[i], FileMode.Open, FileAccess.Read))
            {
                //文件流转成excel对象
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //获得excel数据
                DataSet dataSet = excelDataReader.AsDataSet();
                //读取excel的第一张表
                DataTable dataTable = dataSet.Tables[0];
                //将表中内容存储到对应的txt中
                ReadTableToTxt(files[i], dataTable);
            }
        }
        //刷新编辑器
        AssetDatabase.Refresh();
        
    }

    private static void ReadTableToTxt(string filePath, DataTable dataTable)
    {
        //获得文件名 没有后缀
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        //txt 文件的存储路径
        string path = Application.dataPath + "/Resources/Data/"+fileName+".txt";
        //判断文件是否存在，如果存在则删除
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        //创建文件流 ,生成 txt 文件
        using(FileStream fs = new FileStream(path, FileMode.Create))
        {
            //文件流转写入流，方便写入字符串
            using(StreamWriter sw = new StreamWriter(fs))
            {
                //遍历table
                for(int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];
                    string str = "";
                    //遍历列
                    for(int col = 0;col< dataTable.Columns.Count; col++)
                    {
                        string val = dataRow[col].ToString();
                        str = str + val +"\t"; //每一项tab分割
                    }
                    //写入
                    sw.Write(str);
                    //如果不是最后一行，换行
                    if(row!= dataTable.Rows.Count - 1)
                    {
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}
