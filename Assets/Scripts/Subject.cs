using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Subject 
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

    public static Subject Activate (string word)
    {
        Subject sub = new Subject();

        sub.word = SubjectEntry.Grab(word);
        sub.adjectives = new Adjective[0];
        sub.gender = sub.word.gender;
        return sub;
    }
    public static Subject Random ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\SubjectMasterList").ToArray();
        System.Random gen = new System.Random();

        Subject sub = new Subject();

        sub.plural = (gen.Next(2) == 1)? true: false;
        sub.word = SubjectEntry.Grab(list[gen.Next(list.Length)]);
        sub.ExceptionCheck();
        
        sub.adjectives = new Adjective[1];
        sub.adjectives[0] = Adjective.RandomFromList(sub.word.possible_adjectives);
        sub.adjectives[0].gender = (sub.plural ? 3 : sub.word.gender);
        return sub;
    }

    public string RuString ()
    {
        string str = "";

        foreach (Adjective a in adjectives)
        {
            str += a.RuString() + " ";
        }
        
        return (str + word.GetAs(plural ? 1 : 0, declension));
    }

    public string EnString ()
    {
        string str = "";

        foreach (Adjective a in adjectives)
        {
            str += a.EnString() + " ";
        }
        
        return (str + (plural ? word.plural : word.translation));
    }

    private void ExceptionCheck ()
    // Used for irregular cases of verbs (ex. no plurals).
    {
        if (word.GetAs(0, 0) == "молоко")
            plural = false;
    }
}