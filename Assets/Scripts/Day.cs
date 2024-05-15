using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : Translatable
{
    private int value = 0;

    public Day ()
    {
        System.Random gen = new System.Random();
        value = gen.Next(7);
    }
    public Translatable Next ()
    {
        return null;
    }

    public bool Valid ()
	{
		return true;
	}

	public bool IsForm (string thing)
	{
		return thing.Contains(RuStr());
	}

	public string IsFormDetailed (string thing)
	{
		if (!IsForm(thing))
			return RuStr() + "\n\nWrong...\nbut keep your spirit!";
		else
			return "Correct.";
	}
    public string RuStr ()
    {
        string translation = "";
            switch (value)
            {
                default:
                case 0:
                    translation += "понедельник";
                    return translation;
                case 1:
                    translation += "вторник";
                    return translation;
                case 2:
                    translation += "среда";
                    return translation;
                case 3:
                    translation += "четверг";
                    return translation;
                case 4:
                    translation += "пятница";
                    return translation;
                case 5:
                    translation += "суббота";
                    return translation;
                case 6:
                    translation += "воскресенье";
                    return translation;
            }
    }

    public string EnStr ()
    {
        string translation = "";
            switch (value)
            {
                default:
                case 0:
                    translation += "Monday";
                    return translation;
                case 1:
                    translation += "Tuesday";
                    return translation;
                case 2:
                    translation += "Wednesday";
                    return translation;
                case 3:
                    translation += "Thursday";
                    return translation;
                case 4:
                    translation += "Friday";
                    return translation;
                case 5:
                    translation += "Saturday";
                    return translation;
                case 6:
                    translation += "Sunday";
                    return translation;
            }
    }

    public bool HasNext ()
        { return false; }
}