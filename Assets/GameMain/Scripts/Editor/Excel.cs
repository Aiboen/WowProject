namespace WowGame.Editor
{
    public class ExcelExtension
    {
        /*public void ExportExcel(string fileName)
        {
            string filePath = ExcelPath + fileName + Extension;
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //npoi读取并解析excel的sheet数据
                var workbook = WorkbookFactory.Create(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                //遍历sheet数据，转换成项目需要的txt格式
                var txt = ReadDataTable2Txt(sheet);
                //写入到工程目录
                fileName = fileName.Replace("Config", "");
                var savePath = Path.Combine(Application.dataPath, ExcelPath, fileName + ".txt");
                FileUtility.SafeWriteAllText(savePath, txt);
            }
            AssetDatabase.Refresh();
        }*/
    }
}