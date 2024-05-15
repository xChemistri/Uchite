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
        string[] list = Resources.Load<TextAsset>("Dictionary/AdjectiveMasterList").text.Split("\n");
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

	public bool Valid ()
	{
		return word != null;
	}

    public Translatable Next ()
    {
    	Subject sub = new Subject(word.predicted);
    	this.gender = (sub.Plural ? 3 : sub.Gender);
    	return sub;
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
			return RuStr() + "\n\nYou'll get it next time, we promise!";
		}
		else if (FormGender(thing) == gender)
		{
			switch (declension)
			{
				default:
					case 0:
                		return RuStr() + "\n\nNominative cases are used when the object is the subject (What?).";
					case 1:
                    	return RuStr() + "\n\nGenitive cases are used in terms of possession (Whose?).";
                    case 2:
                    return RuStr() + "\n\nDative cases are used to refer to indirect objects (To whom/what?).";
                    case 3:
                    case 4:
                    	return RuStr() + "\n\nAccusative cases are used to refer to the object of a sentence.";
                    case 5:
                    	return RuStr() + "\n\nInstrumental cases are used to discuss how something is done (With what?)..";
                    case 6:
                    	return RuStr() + "\n\nPrepositional cases are used to denote the location (Where?).";
                    case 7:
                    	return RuStr() + "\n\nShort forms are used when an attribute is temporary.";
			}
		}
		else // FormDeclension(thing) == declension
		{
			switch (gender)
			{
				default:
				case 0:
					return RuStr() + "\n\nAdjective gender always matches subject gender.\nSubject is masculine.";
				case 1:
					return RuStr() + "\n\nAdjective gender always matches subject gender.\nSubject is feminine.";
				case 2:
					return RuStr() + "\n\nAdjective gender always matches subject gender.\nSubject is neuter.";
				case 3:
					return RuStr() + "\n\nAdjective plurality matches subject plurality, regardless of gender.\nThere are multiple subjects.";
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

    public bool HasNext ()
    {
    	if (word.predicted == null) return false;
    	if (word.predicted.Length == 0) return false;
    	return true;
    }
}