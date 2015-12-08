using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

public class NPOIExcelReader 
{
	private string path;
	private XSSFWorkbook workbook;

	public NPOIExcelReader(string _path)
	{
		path = _path;
		workbook = GetWorkBook ();
	} 

	private XSSFWorkbook GetWorkBook()
	{
		XSSFWorkbook hssfwb;
		using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
		{
			hssfwb= new XSSFWorkbook(file);
		}

		return hssfwb;
	}

	public List<Dictionary<string, string>> GetRows(string sheetName)
	{
		List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

		ISheet sheet = workbook.GetSheet(sheetName);

		if (sheet == null) 
		{
			Debug.LogError("Sheet:: " + sheetName + " does not exist!");
			return rows;
		}

		IRow headerRow = sheet.GetRow(0);

		if (headerRow == null) 
		{
			Debug.LogError("Sheet:: " + sheetName + " does not contain header row");
			return rows;
		}

		for (int rowIndex = 1; rowIndex <= sheet.LastRowNum; rowIndex++)
		{

			IRow row = sheet.GetRow(rowIndex);
			if (row != null) //null is when the row only contains empty cells - not reliable
			{
				bool rowIsEmpty = true;
				for (int cellIndex = 0; cellIndex < row.LastCellNum; cellIndex++)
				{
					ICell cell = row.GetCell(cellIndex);
					
					if (cell != null)
					{
						cell.SetCellType(CellType.String);
						if (!string.IsNullOrEmpty(cell.StringCellValue))
						{
							ICell headerCell = headerRow.GetCell(cell.ColumnIndex);
							if (headerCell != null)
							{
								string columnName = headerCell.StringCellValue;
								if (!string.IsNullOrEmpty(columnName))
								{
									if (rows.Count < rowIndex)
									{
										rows.Add(new Dictionary<string, string>());
									}
									rowIsEmpty = false;
									rows[rowIndex-1].Add(columnName, cell.StringCellValue);
								}
							}
						}
					}
				}

				// we read rows until the first empty row
				if (rowIsEmpty)
				{
					break;
				}
			}
			else
			{
				// we read rows until the first empty row
				break;
			}
		}
		return rows;
	}
}
