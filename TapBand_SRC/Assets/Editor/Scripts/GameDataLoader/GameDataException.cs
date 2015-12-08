using System;

public class GameDataException : Exception
{
	public GameDataException()
	{
	}
	
	public GameDataException(string message)
		: base(message)
	{
	}
	
	public GameDataException(string message, Exception inner)
		: base(message, inner)
	{
	}
}
