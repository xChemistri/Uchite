using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : Translatable
{
    private int value = 0;

    public Number ()
    {
        System.Random gen = new System.Random();
        value = gen.Next(11);
    }
    public Translatable Next ()
    {
        return null;
    }

    public string RuStr ()
    {
        string translation = "";
            switch (value)
            {
                default:
                case 0:
                    translation += "ноль";
                    return translation;
                case 1:
                    translation += "один";
                    return translation;
                case 2:
                    translation += "два";
                    return translation;
                case 3:
                    translation += "три";
                    return translation;
                case 4:
                    translation += "четыре";
                    return translation;
                case 5:
                    translation += "пять";
                    return translation;
                case 6:
                    translation += "шесть";
                    return translation;
                case 7:
                    translation += "семь";
                    return translation;
                case 8:
                    translation += "восемь";
                    return translation;
                case 9:
                    translation += "девять";
                    return translation;
                case 10:
                    translation += "десять";
                    return translation;
            }
    }

    public string EnStr ()
    {
        string translation = "";
            switch (value)
            {
                default:
                case 0:
                    translation += "zero";
                    return translation;
                case 1:
                    translation += "one";
                    return translation;
                case 2:
                    translation += "two";
                    return translation;
                case 3:
                    translation += "three";
                    return translation;
                case 4:
                    translation += "four";
                    return translation;
                case 5:
                    translation += "five";
                    return translation;
                case 6:
                    translation += "six";
                    return translation;
                case 7:
                    translation += "seven";
                    return translation;
                case 8:
                    translation += "eight";
                    return translation;
                case 9:
                    translation += "nine";
                    return translation;
                case 10:
                    translation += "ten";
                    return translation;
            }
    }
}
