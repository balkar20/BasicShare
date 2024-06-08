using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace Mod.PowerSupply.Services
{
    internal class FlatFileService
    {
        DataTable dt = new DataTable();

        public async Task ReadFlatFile(Stream stream)
        {
            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            stream.Close();
            ms.Position = 0;

            ISheet sheet;

            var xsswb = new XSSFWorkbook(ms);
            sheet = xsswb.GetSheetAt(0);
            IRow hr = sheet.GetRow(0);
            var rl = new List<string>();

            int cc = hr.LastCellNum;
            for (var i = 0; i < cc; i++)
            {
                ICell cell = hr.GetCell(i);
                dt.Columns.Add(cell.ToString());
            }

            for (var i = (sheet.FirstRowNum +1); i < sheet.LastRowNum; i++)
            {
                var r = sheet.GetRow(i);
                for (int j = r.FirstCellNum; j < cc; j++)
                {
                    rl.Add  (r.GetCell(i).ToString());
                }

                if (rl.Count > 0)
                {
                    dt.Rows.Add(rl.ToArray());
                }
                rl.Clear();
            }
        } 
    }
}
