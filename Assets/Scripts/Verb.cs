using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Verb
{
    public VerbEntry word;

    public bool infinitive = true;
    public int tense = 1;
    public int conjugation = 0;

    public static Verb Activate (string word)
    {
        Verb ver = new Verb();

        ver.word = VerbEntry.Grab(word);
        return ver;
    }

    public static Verb Random ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\VerbMasterList").ToArray();
        System.Random gen = new System.Random();

        Verb ver = new Verb();
        ver.infinitive = false;
        ver.word = VerbEntry.Grab(list[gen.Next(list.Length)]);
        return ver;
    }

    public string RuString ()
    {
        return word.GetAs(tense, conjugation);
    }

    public string EnString ()
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
}
