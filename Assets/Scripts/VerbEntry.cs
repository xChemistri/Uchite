using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VerbEntry
{   
    public string infinitive = "";
    public string engpast = "";
    public string engpresent = "";

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

    public string[] predicted_subjects;
    public int subDeclension;

    public static VerbEntry Grab (string word)
    {
        string data = File.ReadAllText("Assets\\Dictionary\\Words\\" + word + ".json");
        return JsonUtility.FromJson<VerbEntry>(data);
    }

    public VerbEntry Pair ()
    {
        if (pair == "")
            return null;

        string data = File.ReadAllText("Assets\\Dictionary\\Words\\" + pair + ".json");
        return JsonUtility.FromJson<VerbEntry>(pair);
    }
    public string Translate (int mode)
    {
        // MODE:
        // 0 = Infinitive
        // 1 = Past
        // 2 = Present
        // 3 = 3rd Person Present
        // 4 = Future

        switch (mode)
        {
            case 0:
            default:
                return "to " + engpresent;
            case 1:
                return engpast;
            case 2:
                return engpresent;
            case 3:
                return engpresent + "s";
            case 4:
                return "will " + engpresent;
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
