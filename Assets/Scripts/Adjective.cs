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
			return "Sentence entered contains a typo."
			+ "\n Correct word: " + RuStr();
		}
		else if (FormGender(thing) == gender)
		{
			switch (declension)
			{
				default:
					case 0:
                		return "Nominative cases are used when the object is the subject (What?)."
						+ "\n Missing nominative adjective: " + RuStr();
					case 1:
                    	return "Genitive cases are used in terms of possession (Whose?)."
                    	+ "\n Missing genitive adjective: " + RuStr();
                    case 2:
                    return "Dative cases are used to refer to indirect objects (To whom/what?)."
                    	+ "\n Missing dative adjective: " + RuStr();
                    case 3:
                    case 4:
                    	return "Accusative cases are used to refer to the object of a sentence."
                    	+ "\n Missing accusative adjective: " + RuStr();
                    case 5:
                    	return "Instrumental cases are used to discuss how something is done (With what?)."
                    	+ "\n Missing instrumental adjective: " + RuStr();
                    case 6:
                    	return "Prepositional cases are used to denote the location (Where?)."
                    	+ "\n Missing prepositional adjective: " + RuStr();
                    case 7:
                    	return "Short forms are used when an attribute is temporary."
                    	+ "\n Missing short form: " + RuStr();
			}
		}
		else // FormDeclension(thing) == declension
		{
			switch (gender)
			{
				default:
				case 0:
					return "Adjective gender always matches subject gender. Subject is masculine."
					+ "Expected masculine adjective: " + RuStr();
				case 1:
					return "Adjective gender always matches subject gender. Subject is feminine."
					+ "Expected feminine adjective: " + RuStr();
				case 2:
					return "Adjective gender always matches subject gender. Subject is neuter."
					+ "Expected neuter adjective: " + RuStr();
				case 3:
					return "Adjective plurality matches subject plurality, regardless of gender."
					+ "Expected plural adjective: " + RuStr();
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