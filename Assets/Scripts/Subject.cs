using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Subject : Translatable
{
    private int declension = 0;
    public int Declension
    {
        set { declension = value; }
        get { return declension; }
    }

    private int gender = 0;
    public int Gender
    {
        get { return this.gender; }
    }

    private bool plural = false;
    public bool Plural
    {
        get { return plural; }
    }

    private SubjectEntry word = null;

    public Subject (string word)
    {
        string path = ("Dictionary/Subject/" + word);
        path = path.Substring(0,path.Length-1);
        TextAsset ta = Resources.Load<TextAsset>(path);
        if (ta == null) return;
        
        this.word = SubjectEntry.Grab(word);
        this.gender = this.word.gender;
    }

    public Subject ()
    {   
        string[] list = Resources.Load<TextAsset>("Dictionary/SubjectMasterList").text.Split("\n");
        System.Random gen = new System.Random();

        this.plural = (gen.Next(2) == 1)? true: false;
        this.word = SubjectEntry.Grab(list[gen.Next(list.Length)]);
        this.gender = this.word.gender;
        this.ExceptionCheck();
    }

     public Subject (string[] list)
        {
            System.Random gen = new System.Random();

            this.plural = (gen.Next(2) == 1)? true: false;
            this.word = SubjectEntry.Grab(list[gen.Next(list.Length)]);
            this.gender = this.word.gender;
            this.ExceptionCheck();
        }

    public string RuStr ()
    { return word.GetAs(plural ? 1 : 0, declension); }

    public string EnStr ()
    { return (plural ? word.plural : word.translation); }

    private void ExceptionCheck ()
    // Used for irregular cases of verbs (ex. no plurals).
    {
        if (word.GetAs(0, 0) == "молоко")
            plural = false;
    }

    public bool Valid ()
	{
		return word != null;
	}

	public bool IsForm (string thing)
    {
    	for (int i = 0; i < 6; i++)
    		for (int j = 0; j < 2; j++)
    			if (thing.Contains(this.word.GetAs(j, i)))
    			 	return true;

    	return false;
    }

    	public string IsFormDetailed (string thing)
    	{
    		if (FormPlural(thing) == -1 && FormDeclension(thing) == -1)
    		{
    			return RuStr() + "\n\nSentence entered contains a typo.";
    		}
    		else if (FormPlural(thing) == (plural ? 1 : 0))
    		{
    			switch (declension)
    			{
    				default:
    				case 0:
    					return RuStr() + "\n\nNominative cases are used when the object is the subject (What?)."
    					+ "\n Missing nominative.";
    				case 1:
    					return RuStr() + "\n\nGenitive cases are used in terms of possession (Whose?)."
    					+ "\n Missing genitive.";
    				case 2:
    					return RuStr() + "\n\nDative cases are used to refer to indirect objects (To whom/what?)."
    					+ "\n Missing dative.";
    				case 3:
    					return RuStr() + "\n\nAccusative cases are used to refer to the object of a sentence."
    					+ "\n Missing accusative.";
    				case 4:
    					return RuStr() + "\n\nInstrumental cases are used to discuss how something is done (With what?)."
    					+ "\n Missing instrumental." ;
    				case 5:
    					return RuStr() + "\n\nPrepositional cases are used to denote the location (Where?)."
    					+ "\n Missing prepositional.";
    			}
    		}
    		else // FormDeclension(thing) == declension
    		{
    			switch (plural)
    			{
    				default:
    				case false:
    					return RuStr() + "\n\nThere is only one subject in this sentence."
    					+ "\n Missing singular.";
    				case true:
    					return RuStr() + "\n\nThere is multiple subjects in this sentence."
    					+ "\n Missing plural.";
    			}
    		}
    	}
    	private int FormPlural (string thing)
    	{
    		for (int i = 0; i < 6; i++)
        			for (int j = 0; j < 2; j++)
        				 if (thing.Contains(this.word.GetAs(j, i)))
        				 	return j;

        	return -1;
    	}

    	private int FormDeclension (string thing)
        {
        	for (int i = 0; i < 6; i++)
            	for (int j = 0; j < 2; j++)
            		if (thing.Contains(this.word.GetAs(j, i)))
            			return i;

            return -1;
        }

    // Markovian Sequences
    public Translatable Next()
    {
        System.Random gen = new System.Random();
        int tense = gen.Next(3);
        int conjugation = 0;

        switch (tense)
        {
            case 0:
                conjugation = plural ? 3 : gender;
                break;
            default:
            case 1:
            case 2:
                switch (word.GetAs(plural ? 1 : 0, declension))
                {
                    case "я":
                        conjugation = 0;
                        break;
                    case "ты":
                        conjugation = 1;
                        break;
                    case "он":
                    case "она":
                    case "оно":
                        conjugation = 2;
                        break;
                    case "мы":
                        conjugation = 3;
                        break;
                    case "вы":
                        conjugation = 4;
                        break;
                    case "они":
                        conjugation = 5;
                        break;
                    default:
                        conjugation = plural ? 5 : 2;
                        break;
                }
                break;
        }

        Verb verb = new Verb(word.predicted, tense, conjugation);
        return verb;
    }

    public bool HasNext ()
        {
        	if (word.predicted == null) return false;
        	if (word.predicted.Length == 0) return false;
        	return true;
        }
}