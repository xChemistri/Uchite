using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence 
{
    private Subject sub;
    private Verb ver;

    public Sentence ()
    {
        sub = Subject.Random();
        ver = Verb.Random();

        if ( sub.IsPlural() )
            ver.conjugation = 5;
        else
            ver.conjugation = 2;
    }

    public string EnString ()
    {
        return sub.EnString() + " " + ver.EnString();
    }

    public string RuString ()
    {
        return sub.RuString() + " " + ver.RuString();
    }
}
