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
        string[] list = File.ReadLines("Assets\\Dictionary\\AdjectiveMasterList").ToArray();
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

    public Translatable Next ()
    {
        return null;
    }

}