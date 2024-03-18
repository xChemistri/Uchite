using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement 
{
    private Subject sub;
    private Verb ver;
    private Subject diro;

    public Statement ()
    {
        sub = Subject.Random();
        ver = Verb.Random();
        diro = ver.RandomDirObject();

        if ( sub.IsPlural() )
            ver.conjugation = 5;
        else
            ver.conjugation = 2;

        switch (sub.RuString())
        {
            
            case "я":
                ver.conjugation = 0;
                break;
            case "ты":
                ver.conjugation = 1;
                break;
            case "мы":
                ver.conjugation = 3;
                break;
            case "вы":
                ver.conjugation = 4;
                break;
            default:
                break;
        }
    }

    public string EnString ()
    {
        System.Random gen = new System.Random();

        switch (sub.RuString())
        {
            case "я":
            case "ты":
            case "он":
            case "она":
            case "мы":
            case "вы":
            case "они":
                return sub.EnString() + " " +
                ver.EnString() + " " +
                (diro == null ? "" : diro.EnString());
            default:
                return 
                (gen.Next(2) == 1 ? "The " : (sub.IsPlural() ? "Some " : "A ")) +
                sub.EnString() + " " + ver.EnString()  + " " + (diro == null ? "" : diro.EnString());
        }
    }

    public bool Verify (string line)
    {
        string ans = line.ToLower();
        string trans = sub.EnString() + " " + ver.EnString() + (diro == null ? "" : " " + diro.EnString());
        trans = trans.ToLower();

        if (ans.Contains(trans))
            return true;
        else
            return false;
    }

    public string RuString ()
    {
        return sub.RuString() + " " + ver.RuString() + " " + (diro == null ? "" : diro.RuString());
    }
}
