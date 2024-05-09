using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Verb : Translatable
{
    private VerbEntry word;

    private int tense = 1;
    private int conjugation = 0;

    public Verb (string word)
    {
        this.word = VerbEntry.Grab(word);
    }

    public Verb (string word, int tense, int conjugation)
    {
        this.word = VerbEntry.Grab(word);
        this.tense = tense;
        this.conjugation = conjugation;
    }

	public Verb (string[] list, int tense, int conjugation)
        {
            System.Random gen = new System.Random();

            word = VerbEntry.Grab(list[gen.Next(list.Length)]);
            this.tense = tense;
            this.conjugation = conjugation;
        }

    public Verb ()
    {
        tense = -1;
        string[] list = File.ReadLines("Assets\\Dictionary\\VerbMasterList").ToArray();
        System.Random gen = new System.Random();

        word = VerbEntry.Grab(list[gen.Next(list.Length)]);
    }

    public Verb (int tense, int conjugation)
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\VerbMasterList").ToArray();
        System.Random gen = new System.Random();
        word = VerbEntry.Grab(list[gen.Next(list.Length)]);

        this.tense = tense;
        this.conjugation = conjugation;
    }

    public Subject RandomDirObj ()
    {
        if (word.predicted == null)
            return null;

        System.Random gen = new System.Random();

        Subject ans = new Subject(word.predicted[gen.Next(word.predicted.Length)]);
        ans.Declension = word.subDeclension;

        return ans;
    }

    public string RuStr ()
    {
        return word.GetAs(tense, conjugation);
    }

    public string EnStr ()
    {
        if (tense == -1) return word.Translate(0);

        switch (tense)
        {
            case -1:
                return word.Translate(0);
            case 0:
            default:
                return word.Translate(1);
            case 1:
                if (conjugation == 2) return word.Translate(3);
                else return word.Translate(2);
            case 2:
                return word.Translate(4);
        }
    }

    public bool Valid ()
	{
		return word != null;
	}

	public bool IsForm (string thing)
    {
    	for (int i = 0; i < 4; i++)
        	if (thing.Contains(this.word.GetAs(0, i)))
        		return true;

        for (int i = 0; i < 6; i++)
        	for (int j = 1; j < 3; j++)
        		if (thing.Contains(this.word.GetAs(j, i)))
        		 	return true;

        return false;
    }

    public string IsFormDetailed (string thing)
    {
        if (FormTense(thing) == -1 && FormConjugation(thing) == -1)
        {
        	return "Sentence entered contains a typo."
        	+ "\n Correct word: " + RuStr();
        }
        else if (FormConjugation(thing) == conjugation)
        {
        	switch (tense)
        	{
        		default:
        		case 0:
        			return "Verb tense does not match past tense."
        			+ "\n Past tense verb was expected: " + RuStr();
        		case 1:
        			return "Verb is not in the present."
        			+ "\n Present tense verb was expected: " + RuStr();
        		case 2:
        			return "Verb is not in the future."
        			+ "\n Future (will do) tense was expected" + RuStr();
        	}
        }
        else // FormTense(thing) == tense
        {
        	if (tense == 0)
        	{
				switch (conjugation)
				{
					default:
					case 0:
						return "For past, conjugation matches gender (like an adjective)."
						+ "\n Masculine conjugation was expected: " + RuStr();
					case 1:
						return "For past, conjugation matches gender (like an adjective)."
						+ "\n Feminine conjugation was expected: " + RuStr();
					case 2:
						return "For past, conjugation matches gender (like an adjective)."
                        + "\n Neuter conjugation was expected: " + RuStr();
					case 3:
						return "For past, conjugation matches gender (like an adjective)."
                        + "\n Plural conjugation was expected: " + RuStr();
				}
        	}
        	else
        	{
        		switch (conjugation)
        		{
        			default:
                    	case 0:
                    		return "Conjugation must match subject perspective."
                    		+ "\n \"I\" conjugation was expected: " + RuStr();
                    	case 1:
                    		return "Conjugation must match subject perspective."
                            + "\n \"You\" conjugation was expected: " + RuStr();
                    	case 2:
                    		return "Conjugation must match subject perspective."
                            + "\n \"He/She/It\" conjugation was expected: " + RuStr();
                    	case 3:
                    		return "Conjugation must match subject perspective."
                            + "\n \"We\" conjugation was expected: " + RuStr();
                        case 4:
                        	return "Conjugation must match subject perspective."
                            + "\n \"You (plural)\" conjugation was expected: " + RuStr();
                        case 5:
                        	return "Conjugation must match subject perspective."
                        	+ "\n \"They\" conjugation was expected: " + RuStr();
        		}
        	}
        }
    }

    private int FormTense (string thing)
   	{
    	for (int i = 0; i < 4; i++)
      		if (thing.Contains(this.word.GetAs(0, i)))
        		return 0;

        for (int i = 1; i < 3; i++)
            for (int j = 0; j < 6; j++)
            	if (thing.Contains(this.word.GetAs(j, i)))
            		return j;

        return -1;
    }

    private int FormConjugation (string thing)
    {
        for (int i = 0; i < 4; i++)
        	if (thing.Contains(this.word.GetAs(0, i)))
                return i;

        for (int i = 1; i < 3; i++)
            for (int j = 0; j < 6; j++)
            	if (thing.Contains(this.word.GetAs(j, i)))
                	return i;

        return -1;
    }

    public Translatable Next ()
    {
        return RandomDirObj();
    }

    public bool HasNext ()
        {
        	if (word.predicted == null) return false;
        	if (word.predicted.Length == 0) return false;
        	return true;
        }
}
