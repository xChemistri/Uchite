using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class Adjective 
{
    public int gender = 0;
    public int declension = 0;
    public AdjectiveEntry word = null;

    public static Adjective Activate (string word)
    {
        Adjective adj = new Adjective();
        adj.word = AdjectiveEntry.Grab(word);
        return adj;
    }

    public static Adjective Random ()
    {
        string[] list = File.ReadLines("Assets\\Dictionary\\AdjectiveMasterList").ToArray();
        System.Random gen = new System.Random();

        Adjective adj = new Adjective();
        adj.word = AdjectiveEntry.Grab(list[gen.Next(0, (list.Length - 1))]);
        
        return adj;
    }

    public string RuString ()
    {
        return word.GetAs(gender, declension);
    }

    public string EnString ()
    {
        return word.Translate();
    }
}
