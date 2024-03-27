using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class Adjective : Translatable
{
    private int gender = 0;
    private int declension = 0;
    private AdjectiveEntry word = null;

    public Adjective (string word)
    {
        this.word = AdjectiveEntry.Grab(word);
    }

    public Adjective (string word, int gender, int declension)
    {
        this.word = AdjectiveEntry.Grab(word);
        this.gender = gender;
        this.declension = declension;
    }

    public Adjective ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\AdjectiveMasterList").ToArray();
        System.Random gen = new System.Random();
        word = AdjectiveEntry.Grab(list[gen.Next(0, (list.Length - 1))]);
    }

    public Adjective (string[] list)
    {
        System.Random gen = new System.Random();
        if (list.Length != 0)
            word = AdjectiveEntry.Grab(list[gen.Next(0, (list.Length - 1))]);
    }

    public Adjective (string[] list, int gender, int declension)
    {
        System.Random gen = new System.Random();
        if (list.Length != 0)
            word = AdjectiveEntry.Grab(list[gen.Next(0, (list.Length - 1))]);

        this.gender = gender;
        this.declension = declension;
    }

    public string RuStr ()
    {
        return word.GetAs(gender, declension);
    }

    public string EnStr ()
    {
        return word.Translate();
    }

    public Translatable Next ()
    {
        return null;
    }

	public bool IsForm (string thing)
	{
		for (int i = 0; i < 6; i++)
			for (int j = 0; j < 4; j++)
				 if (thing.Contains(this.word.GetAs(j, i)))
				 	return true;

		return false;
	}

	public string IsFormDetailed (string thing)
	{
		if (FormGender(thing) == -1 && FormDeclension(thing) == -1)
		{
			return "Sentence entered contains a typo.";
		}
		else if (FormGender(thing) == gender)
		{
			switch (declension)
			{
				default:
				case 0:
					return "Missing adjective in the nominative.";
				case 1:
					return "Missing adjective in the genitive.";
				case 2:
					return "Missing adjective in the dative.";
				case 3:
				case 4:
					return "Missing adjective in the accusative.";
				case 5:
					return "Missing adjective in the instrumental.";
				case 6:
					return "Missing adjective in the prepositional.";
				case 7:
					return "Short form missing.";
			}
		}
		else // FormDeclension(thing) == declension
		{
			switch (gender)
			{
				default:
				case 0:
					return "Subject is a masculine noun.";
				case 1:
					return "Subject is a feminine noun.";
				case 2:
					return "Subject is a neuter noun.";
				case 3:
					return "Subject is plural.";
			}
		}
	}
	private int FormGender (string thing)
	{
		for (int i = 0; i < 6; i++)
    			for (int j = 0; j < 4; j++)
    				 if (thing.Contains(this.word.GetAs(j, i)))
    				 	return j;

    	return -1;
	}

	private int FormDeclension (string thing)
    {
    	for (int i = 0; i < 6; i++)
        	for (int j = 0; j < 4; j++)
        		if (thing.Contains(this.word.GetAs(j, i)))
        			return i;

        return -1;
    }
}