using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using System.IO;

[System.Serializable]
public class AdjectiveEntry
{
    public string translation = "";
    public bool isIrregular = true;
    
    //Order goes from [MASC, FEM, NEU, PL] in ALL cases.
    public string[] nominative;         //Int 0
    public string[] genitive;           //Int 1
    public string[] dative;             //Int 2
    public string[] accusative_anim;    //Int 3
    public string[] accusative_inam;    //Int 4
    public string[] instrumental;       //Int 5
    public string[] prepositional;      //Int 6
    public string[] shortform;          //Int 7

    public static AdjectiveEntry Grab (string word)
    {
        string data = File.ReadAllText("Assets\\Dictionary\\Words\\" + word + ".json");
        return JsonUtility.FromJson<AdjectiveEntry>(data);
    }
    
    public string Translate ()
    {
        return translation;
    }
    public string GetAs(int gender, int declination)
    {
        switch (declination)
        {
            case 0:
            default:
                return nominative[gender];
            case 1:
                return genitive[gender];
            case 2:
                return dative[gender];
            case 3:
                return accusative_anim[gender];
            case 4:
                return accusative_inam[gender];
            case 5:
                return instrumental[gender];
            case 6:
                return prepositional[gender];
            case 7:
                return shortform[gender];
        }
    }
}
