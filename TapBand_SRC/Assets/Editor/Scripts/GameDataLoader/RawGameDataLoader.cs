using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Excel;
using System;
using System.IO;
using System.Data;
using UnityEditor;

public class RawGameDataLoader : IGameDataLoader
{
	private string gameDataFilePath;
	private string currentSheet;
	private List<Dictionary<string, string>> currentRows;
	private NPOIExcelReader dataReader;

	public RawGameDataLoader(string _gameDataFilePath)
	{
		gameDataFilePath = _gameDataFilePath;
		currentSheet = "";
		dataReader = new NPOIExcelReader(gameDataFilePath);
	}

	private bool IsCellExist(int rowIndex, string columnName)
	{
		return rowIndex < currentRows.Count && currentRows[rowIndex].ContainsKey(columnName);
	}

	private void AbortWithErrorMessage(string msg)
	{
		EditorUtility.DisplayDialog ("GameData Loading Error", msg, "Ok");
		throw new GameDataException(msg);
	}

	#region Type Specific Loaders

	// loads from consecutive columns
	private void TryLoadIntArray (int rowIndex, string baseColumnName, int columnNum, out int[] array)
	{
		array = new int[columnNum];
		
		for (int i = 0; i < columnNum; i++) 
		{
			TryLoadInt(rowIndex, baseColumnName + i, out array[i]);
		}
	}

	private void TryLoadInt(int rowIndex, string columnName, out int data)
	{
		if(!IsCellExist(rowIndex,  columnName))
		{				
			AbortWithErrorMessage(currentSheet + "::" + columnName + " column is invalid! Row number: " + (rowIndex + 2) );
		}

		string[] splitCellValue = currentRows[rowIndex][columnName].Split('.'); // may contain number in format 10.0 etc

		if (!int.TryParse(splitCellValue[0], out data)) 
		{
			AbortWithErrorMessage(currentSheet + "::" + columnName + " is not valid int! Row number: " + (rowIndex + 2));
		}
	}

	private void TryLoadBigInteger(int rowIndex, string columnName, out BigInteger data)
	{
        data = new BigInteger(0);
        try
        {
    		string originalCellValue = "";
    		try 
    		{
    			originalCellValue = currentRows[rowIndex][columnName]; 
    		}
    		catch( Exception e)
    		{
                AbortWithErrorMessage(currentSheet +  "::" + columnName + " failed to parse as biginteger! Row number: " + (rowIndex + 1).ToString() + ". Error: " + e.Message);
    		}
    		if (originalCellValue.Contains("E"))
    		{
    			string cellValue = originalCellValue.Replace("E", ","); // to be easier to split

				if (cellValue.Contains("+"))
				{
					cellValue = cellValue.Replace("+","");
				}

    			string[] splitValue = cellValue.Split(','); // {integerpart.fractionalpart , exponent}

    			string[] baseNumStr = splitValue[0].Split('.');

    			int exponent = int.Parse(splitValue[1]);
    			BigInteger tempInt = new BigInteger(baseNumStr[0] + baseNumStr[1]);

    			for (int i=1; i <= (exponent - baseNumStr[1].Length); i++)
    			{
    				tempInt *= 10;
    			}

    			data = tempInt;
    		}
    		else
    		{
    			string[] splitCellValue = originalCellValue.Split('.'); // may contain number in format 10.0 etc

    			data = new BigInteger(splitCellValue[0]);
    		}
        } 
        catch (Exception e)
        {
            AbortWithErrorMessage(currentSheet +  "::" + columnName + " failed to parse as biginteger! Row number: " + (rowIndex + 1).ToString() + ". Error: " + e.Message);
        }
	}
	
	private void TryLoadString(int rowIndex, string columnName, out string data)
	{		
		if(!IsCellExist(rowIndex, columnName) || string.IsNullOrEmpty(currentRows[rowIndex][columnName])) 
		{
			data = "";
			AbortWithErrorMessage(currentSheet + "::" + columnName + " is empty or null! Row number: " + (rowIndex + 2));
		}
		else
		{
			data = currentRows[rowIndex][columnName];
		}
	}

	#endregion
	
	public List<SongData> LoadExampleDatas()
	{
		List<SongData> dataObjects = new List<SongData>();

		dataObjects.Add(LoadSongData(0));

		return dataObjects;
	}
	
	private SongData LoadSongData(int index)
	{
		currentSheet = "SongSheet";
		currentRows = dataReader.GetRows(currentSheet);

		int edId = 0;
		TryLoadInt (0, "Id", out edId);

        SongData songDataObject = new SongData(edId);

		TryLoadString (0, "Name", out songDataObject.name);
		
		songDataObject.levelDatas = new List<SongData.LevelData>();

		// Level 0 skip
		songDataObject.levelDatas.Add (new SongData.LevelData());
		
		int rowNum = currentRows.Count;
		for (int i = 0; i < rowNum; i++)
		{
            SongData.LevelData levelDataObject = new SongData.LevelData();

			TryLoadBigInteger(i, "Coin", out levelDataObject.coin);
			TryLoadBigInteger(i, "UpgradeCost", out levelDataObject.upgradeCost);
			
			songDataObject.levelDatas.Add(levelDataObject);
		}
		
		return songDataObject;
	}
}
