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
        string[] list = Resources.Load<TextAsset>("Dictionary/VerbMasterList").text.Split("\n");
        System.Random gen = new System.Random();

        word = VerbEntry.Grab(list[gen.Next(list.Length)]);
    }

    public Verb (int tense, int conjugation)
    {
        string[] list = Resources.Load<TextAsset>("Dictionary/VerbMasterList").text.Split("\n");
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
        if (FormTense(thing) == tense)
        {
        	if (tense == 0)
        	{
				switch (conjugation)
				{
					default:
					case 0:
						return RuStr() + "\n\nFor past, conjugation matches gender."
						+ "\n Similar to an adjective.";
					case 1:
						return RuStr() + "\n\nFor past, conjugation matches gender."
						+ "\n Similar to an adjective.";
					case 2:
						return RuStr() + "\n\nFor past, conjugation matches gender."
                        + "\n Similar to an adjective.";
					case 3:
						return RuStr() + "\n\nFor past, conjugation matches gender."
                        + "\n Similar to an adjective.";
				}
        	}
        	else
        	{
        		switch (conjugation)
        		{
        			default:
                    	case 0:
                    		return RuStr() + "\n\nConjugation must match subject perspective."
                    		+ "\n \"I\" am the subject.";
                    	case 1:
                    		return RuStr() + "\n\nConjugation must match subject perspective."
                            + "\n \"You\" are the subject.";
                    	case 2:
                    		return RuStr() + "\n\nConjugation must match subject perspective."
                            + "\n \"He/She/It\" is the subject.";
                    	case 3:
                    		return RuStr() + "\n\nConjugation must match subject perspective."
                            + "\n \"We\" are the subject.";
                        case 4:
                        	return RuStr() + "\n\nConjugation must match subject perspective."
                            + "\n \"You (all)\" are the subject.";
                        case 5:
                        	return RuStr() + "\n\nConjugation must match subject perspective."
                        	+ "\n \"They\" are the subject.";
        		}
        	}
        }
        else if (FormConjugation(thing) == conjugation)
        {
                    switch (tense)
                    {
                        default:
                        case 0:
                            return RuStr() + "\n\nVerb tense does not match past tense.";
                        case 1:
                            return RuStr() + "\n\nVerb is not in the present.";
                        case 2:
                            return RuStr() + "\n\nVerb is not in the future.";
                    }
                }

        return RuStr() + "\n\nYou'll get it soon!";
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
