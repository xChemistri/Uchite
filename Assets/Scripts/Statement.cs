using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement 
{
    private readonly int CHOICES = 1;
    private Translatable[] sentence;


    public Statement ()
    {
        System.Random gen = new System.Random();

        switch (gen.Next(CHOICES + 1))
        {
            default:
            case 1:
                sentence = new Translatable[4];
                sentence[0] = new Subject();
                sentence[1] = sentence[0].Next();
                sentence[2] = sentence[1].Next();
                break;
        }
    }

    public string EnStr ()
    {
        string translation = "";

        foreach (Translatable word in sentence)
        {
            if (word == null) break;
            translation += word.EnStr() + " ";
        }

        return translation.Substring(0, translation.Length-1);
    }

    public int Verify (string line)
    {
        if (line.ToLower().Contains(RuStr().ToLower()))
            return 0;
        return 1;
    }

    public string RuStr ()
    {
        string translation = "";

        foreach (Translatable word in sentence)
        {
            if (word == null) break;
            
            translation += word.RuStr() + " ";
        }

        return translation.Substring(0, translation.Length-1);
    }
}
