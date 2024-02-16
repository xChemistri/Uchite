using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    public enum GENDER
    {
        MALE, 
        FEMALE, 
        NEUTER, 
        PLURAL
    }

    public enum CASE
    {
        NOMINATIVE,
        GENITIVE, 
        DATIVE, 
        ACCUSATIVE, 
        INSTRUMENTAL, 
        PREPOSITIONAL, 
        VOCATIVE
    }

    [SerializeField] private GENDER gender;
    [SerializeField] private CASE declension;
    [SerializeField] private string word;

    public GENDER Gender ()
    {
        return gender;
    }

    private CASE Case ()
    {
        return declension;
    }
}
