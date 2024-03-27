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
        get { return gender; }
    }

    private bool plural = false;
    public bool Plural
    {
        get { return plural; }
    }

    private Adjective[] adjectives;
    private SubjectEntry word = null;

    public Subject (string word)
    {
        this.word = SubjectEntry.Grab(word);
        this.adjectives = new Adjective[0];
        this.gender = this.word.gender;
    }

    public Subject ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\SubjectMasterList").ToArray();
        System.Random gen = new System.Random();

        this.plural = (gen.Next(2) == 1)? true: false;
        this.word = SubjectEntry.Grab(list[gen.Next(list.Length)]);
        this.ExceptionCheck();
        
        this.adjectives = new Adjective[0];

        if (this.word.possible_adjectives != null)
        {
            this.adjectives = new Adjective[1];
            for (int i = 0; i < this.adjectives.Length; i++)
                this.adjectives[i] = new Adjective(this.word.possible_adjectives, (this.plural ? 3 : this.word.gender), this.declension);
        }
    }
    public string RuStr ()
    {
        string str = "";

        if (adjectives.Length == 0)
            return word.GetAs(plural ? 1 : 0, declension);


        foreach (Adjective a in adjectives)
            str += a.RuStr() + " ";
        return (str + word.GetAs(plural ? 1 : 0, declension));
    }

    public string EnStr ()
    {
        string str = "";

        foreach (Adjective a in adjectives)
        {
            str += a.EnStr() + " ";
        }
        
        return (str + (plural ? word.plural : word.translation));
    }

    private void ExceptionCheck ()
    // Used for irregular cases of verbs (ex. no plurals).
    {
        if (word.GetAs(0, 0) == "молоко")
            plural = false;
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

        Verb verb = new Verb(tense, conjugation);
        return verb;
    }
}