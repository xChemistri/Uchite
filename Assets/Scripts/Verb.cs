using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Verb : Translatable
{
    public VerbEntry word;

    public bool infinitive = true;
    public int tense = 1;
    public int conjugation = 0;

    public Verb (string word)
    {
        this.word = VerbEntry.Grab(word);
    }

    public Verb ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\VerbMasterList").ToArray();
        System.Random gen = new System.Random();

        infinitive = false;
        word = VerbEntry.Grab(list[gen.Next(list.Length)]);
    }

    public Subject RandomDirObj ()
    {
        if (word.predicted_subjects == null)
            return null;

        System.Random gen = new System.Random();

        Subject ans = new Subject(word.predicted_subjects[gen.Next(word.predicted_subjects.Length)]);
        ans.SetDeclension(word.subDeclension);

        return ans;
    }
    public string RuStr ()
    {
        return word.GetAs(tense, conjugation);
    }

    public string EnStr ()
    {
        if (infinitive) return word.Translate(0);

        switch (tense)
        {
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

    public Translatable Next ()
    {
        return RandomDirObj();
    }
}
