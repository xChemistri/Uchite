using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Subject : Translatable
{
    private int declension = 0;
    private int gender = 0;
    private bool plural = false;

    private Adjective[] adjectives;
    private SubjectEntry word = null;

    public int GetDeclension ()
    {
        return declension;
    }

    public void SetDeclension (int declension)
    {
        this.declension = declension;
    }

    public int GetGender ()
    {
        return gender;
    }

    public bool IsPlural ()
    {
        return plural;
    }

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
            {
                this.adjectives[i] = Adjective.RandomFromList(this.word.possible_adjectives);
                this.adjectives[i].gender = (this.plural ? 3 : this.word.gender);
            }
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
        Verb verb = new Verb();

        switch (word.GetAs(plural ? 1 : 0, declension))
        {
            case "я":
                verb.conjugation = 0;
                break;
            case "ты":
                verb.conjugation = 1;
                break;
            case "он":
            case "она":
            case "оно":
                verb.conjugation = 2;
                break;
            case "мы":
                verb.conjugation = 3;
                break;
            case "вы":
                verb.conjugation = 4;
                break;
            case "они":
                verb.conjugation = 5;
                break;
            default:
                verb.conjugation = plural ? 5 : 2;
                break;
        }

        return verb;
    }
}