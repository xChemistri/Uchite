using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Verb
{
    public string infinitive = "";
    public string pair = "";
    public bool imperfective = true;
    public bool isIrregular = true;

    // Order in the data base (PRESENT/FUTURE):
    // 1stS, 2ndS, 3rdS, 1stPl, 2ndPl, 3rdPl
    // я     ты    он    мы     вы     они
    // Order in the data base (PAST):
    // MASC, FEMN, NEUT, PLUR

    public string[] past;
    public string[] present;
    public string[] future;

    public static Verb Grab (string word)
    {
        string data = File.ReadAllText("Assets\\Dictionary\\" + word + ".json");
        return JsonUtility.FromJson<Verb>(data);
    }

    public Verb Pair ()
    {
        if (pair == "")
            return null;

        string data = File.ReadAllText("Assets\\Dictionary\\" + pair + ".json");
        return JsonUtility.FromJson<Verb>(pair);
    }
    public string Translate (int mode)
    {
        // MODE:
        // 0 = Infinitive
        // 1 = English Singul
        // 2 = English Plural

        switch (mode)
        {
            case 0:
            default:
                return infinitive;
            case 1:
                return infinitive.Substring(2, infinitive.Length);
            case 2:
                return infinitive.Substring(2, infinitive.Length) + "s";
        }
    }

    public string GetAs(int tense, int subject)
    {
        switch (tense)
        {
            case 0:
                return past[subject];
            case 1:
            default:
                return present[subject];
            case 2:
                return future[subject];
        }
    }
}
