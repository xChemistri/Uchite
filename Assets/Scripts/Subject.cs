using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject 
{
    public Adjective[] adjectives;
    public SubjectEntry word = null;

    public static Subject Activate (string word)
    {
        word = SubjectEntry.Grab(word);
    }

    public static Subject Random ()
    {
        File.ReadAllText("Assets\\Dictionary\\" + word + ".json");
    }
}