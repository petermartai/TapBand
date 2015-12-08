using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class ExcelData
{
	private string path;

	public ExcelData(string _path)
	{
		path = _path;
	} 
	
	public IExcelDataReader GetExcelReader()
	{
		// ExcelDataReader works with the binary Excel file, so it needs a FileStream
		// to get started. This is how we avoid dependencies on ACE or Interop:
		FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
		
		// We return the interface, so that
		IExcelDataReader reader = null;
		try
		{
			if (path.EndsWith(".xls"))
			{
				reader = ExcelReaderFactory.CreateBinaryReader(stream);
			}
			if (path.EndsWith(".xlsx"))
			{
				reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
			}
			return reader;
		}
		catch (Exception)
		{
			throw;
		}
	}

	/* Returns List of dictionaries that represent rows with column names as keys + cell content as value. */
	/* Header row is excluded. */
	public List<Dictionary<string, string>> GetRows(string sheet)
	{
		IExcelDataReader reader = this.GetExcelReader();
		DataTable workSheet = reader.AsDataSet().Tables[sheet];

		if (workSheet == null || workSheet.Rows.Count <= 1) 
		{
			Debug.LogError("No valid data in sheet: " + sheet);
			throw new GameDataException("No valid data in sheet: " + sheet);
		}

		List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();

		int columnNum = workSheet.Columns.Count; // may contain empty columns!
		List<string> columnNames = new List<string>();
		DataRow headerRow = workSheet.Rows[0];

		int notEmptyColumnNum = 0;
		for (int i=0; i<columnNum; i++)
		{
			if (headerRow[i] != null && !string.IsNullOrEmpty(headerRow[i].ToString())) 
			{
				notEmptyColumnNum++;
				columnNames.Add(headerRow[i].ToString());
			}
		}
		columnNum = notEmptyColumnNum;

		int dataRowNum = workSheet.Rows.Count; // may contain empty rows!
		for (int i=1; i<dataRowNum; i++)
		{
			bool rowIsEmpty = true;
			for (int j=0; j<columnNum; j++)
			{
				if (!workSheet.Rows[i].IsNull(j))
				{
					rowIsEmpty = false;

					if (rows.Count <= i-1)
					{
						rows.Add(new Dictionary<string, string>());
					}

					rows[i-1].Add(columnNames[j], workSheet.Rows[i][j].ToString());
				}
			}

			// we read rows until the first empty row
			if (rowIsEmpty)
			{
				break;
			}
		}

		return rows;
	}
}

