using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statement 
{
    private readonly int CHOICES = 2;
    private Translatable[] sentence;


    public Statement ()
    {
        System.Random gen = new System.Random();

        switch (gen.Next(CHOICES + 1))
        {
            default:
            case 1:
                sentence = new Translatable[3];
                sentence[0] = new Subject();
                Create();
                break;
            case 2:
                sentence = new Translatable[1];
                sentence[0] = new Subject();
                break;
        }
    }

    private void Create ()
    {
        for (int i = 1; i < sentence.Length; i++)
            sentence[i] = sentence[i-1].Next();
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
