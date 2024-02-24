using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SubjectEntry
{
    public string translation = "";
    public string plural = "";
    public bool isIrregular = true;

    // 0 = MASC, 1 = FEM, 2 = NEU.
    public int gender = 0;
    public int animate = 0;

    // Order in the data base: [SING, PLUR] for ALL cases.
    public string[] nominative;         // Case 0
    public string[] genitive;           // Case 1
    public string[] dative;             // Case 2
    public string[] accusative;         // Case 3
    public string[] instrumental;       // Case 4
    public string[] prepositional;      // Case 5

    public static SubjectEntry Grab (string word)
    {
        string data = File.ReadAllText("Assets\\Dictionary\\" + word + ".json");
        return JsonUtility.FromJson<SubjectEntry>(data);
    }

    public string Translate (int plural)
    {
        return translation;
    }

    public string GetAs(int plural, int declination)
    {
        switch (declination)
        {
            case 0:
            default:
                return nominative[plural];
            case 1:
                return genitive[plural];
            case 2:
                return dative[plural];
            case 3:
                return accusative[plural];
            case 4:
                return instrumental[plural];
            case 5:
                return prepositional[plural];
        }
    }
}
