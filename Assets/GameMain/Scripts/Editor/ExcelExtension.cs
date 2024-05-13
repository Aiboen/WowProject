using NPOI.SS.UserModel;
using System.IO;
using System.Text;
using Unity.Plastic.Newtonsoft.Json;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace WowGame.Editor
{
    public static class ExcelExtension
    {
        [MenuItem("GameMain/Excel to json")]
        public static void ExcelToJson()
        {
            ExportExcelToJson("UIForm");
        }
        [MenuItem("GameMain/Excel to text")]
        public static void ExcelToText()
        {
            ExportExcelToText("UIForm");
        }

        public static void ExportExcelToText(string fileName)
        {
            string filePath = Constant.Path.ExcelPath + fileName + Constant.Path.ExcelExtension;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //npoi读取并解析excel的sheet数据
                var workbook = WorkbookFactory.Create(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                //遍历sheet数据，转换成项目需要的txt格式
                var txt = ReadDataTable2Txt(sheet);
                //写入到工程目录
                fileName = fileName.Replace("Config", "");
                var savePath = Path.Combine(Application.dataPath, Constant.Path.TextPath, fileName + Constant.Path.TextExtension);
                FileUtility.SafeWriteAllText(savePath, txt);
            }
            AssetDatabase.Refresh();
        }

        //第一行为表头，第二行为字段名 第三行为类型
        private static string ReadDataTable2Txt(ISheet sheet)
        {
            // 获取表格有多少列
            int columns = sheet.GetRow(3).LastCellNum;
            // 获取表格有多少行
            int rows = sheet.LastRowNum + 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("#"); //读取TableName
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(0)?.GetCell(j);
                if (cell != null)
                    sb.Append("\t" + cell);
            }

            sb.Append("\n#"); //读取FiledName
            for (int j = 0; j < columns; j++)
            {
                var cell = sheet.GetRow(2)?.GetCell(j);
                if (cell != null)
                    sb.Append("\t" + cell);
            }

            sb.Append("\n#"); //读取FiledType
            for (int j = 0; j < columns; j++)
            {
                sb.Append("\t");
                var cell = sheet.GetRow(3)?.GetCell(j);
                if (cell != null)
                    sb.Append(cell);
            }

            sb.Append("\n#"); //读取FiledDesc
            for (int j = 0; j < columns; j++)
            {
                sb.Append("\t");
                var cell = sheet.GetRow(1)?.GetCell(j);
                if (cell != null)
                {
                    var desc = cell.ToString();
                    //zdesc = ConfigEditorUtility.ClearDesc(desc);
                    sb.Append(desc);
                }
            }

            //读取第4行后的表数据
            for (int i = 4; i < rows; i++)
            {
                var first = sheet.GetRow(i)?.GetCell(0);
                if (first == null) continue;

                sb.Append("\n");
                for (int j = 0; j < columns; j++)
                {
                    sb.Append("\t");
                    var cell = sheet.GetRow(i)?.GetCell(j);
                    if (cell != null)
                    {
                        sb.Append(cell);
                    }
                }
            }
            return sb.ToString();
        }


        public static void ExportExcelToJson(string fileName)
        {
            string filePath = Constant.Path.ExcelPath + fileName + Constant.Path.ExcelExtension;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //npoi读取并解析excel的sheet数据
                var workbook = WorkbookFactory.Create(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                //遍历sheet数据，转换成json格式的文本
                var txt = ReadDataTable2Json(sheet);
                //写入到工程目录
                fileName = fileName.Replace("Config", "");
                var savePath = Path.Combine(Application.dataPath, Constant.Path.JsonPath, fileName + Constant.Path.JsonExtension);
                FileUtility.SafeWriteAllText(savePath, txt);
            }
            AssetDatabase.Refresh();
        }

        private static string ReadDataTable2Json(ISheet sheet)
        {
            // 获取表格有多少列
            int columns = sheet.GetRow(3).LastCellNum;
            // 获取表格有多少行
            int rows = sheet.LastRowNum + 1;

            JArray array = new JArray();
            for (int i = 0; i < rows; i++)
            {
                var first = sheet.GetRow(i)?.GetCell(0);
                if (first != null)
                {
                    JArray line = new JArray();
                    for (int j = 0; j < columns; j++)
                    {
                        var fieldType = sheet.GetRow(3).GetCell(j);
                        var cell = sheet.GetRow(i)?.GetCell(j);
                        var value = cell?.ToString();
                        line.Add(value);
                    }
                    array.Add(line);
                }
            }
            return array.ToString(Formatting.Indented);
        }
    }
}