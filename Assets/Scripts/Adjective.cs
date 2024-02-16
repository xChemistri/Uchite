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

    public static AdjectiveEntry Create (string word)
    {
        string data = File.ReadAllText("Assets\\Dictionary\\" + word + ".json");
        return JsonUtility.FromJson<AdjectiveEntry>(data);
    }

    public void CreateEntry (string stem, string translation)
    {
        this.translation = translation;
        isIrregular = false;

        nominative = new[] {stem+"ый", stem+"ая", stem+"ое", stem+"ые"};
        genitive = new[] {stem+"ого", stem+"ой", stem+"ого", stem+"ых"};
        dative = new[] {stem+"ому", stem+"ой", stem+"ому", stem+"ым"};
        accusative_anim = new[] {stem+"ого", stem+"ую", stem+"ого", stem+"ых"};
        accusative_inam = new[] {stem+"ый", stem+"ую", stem+"ое", stem+"ые"};
        instrumental = new[] {stem+"ым", stem+"ой", stem+"ым", stem+"ыми"};
        prepositional = new[] {stem+"ом", stem+"ой", stem+"ом", stem+"ых"};
        shortform = new[] {stem, stem+"о", stem+"а", stem+"ы"};
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
