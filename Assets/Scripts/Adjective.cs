using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class AdjectiveEntry
{
    [SerializeField] private string translation;
    [SerializeField] private bool isIrregular;
    [SerializeField] private string entry;

    public void Initialize()
    {

    }

    public string GetAs(Word.GENDER gen, Word.CASE cas)
    {
        string part = entry.Substring(0, entry.Length-2);

        if (isIrregular)
        {
            return "irregular";
        }
        else
        {
            switch (cas)
            {
                case Word.CASE.NOMINATIVE:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                case Word.CASE.GENITIVE:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                case Word.CASE.DATIVE:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                case Word.CASE.ACCUSATIVE:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                case Word.CASE.INSTRUMENTAL:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                case Word.CASE.PREPOSITIONAL:
                    switch (gen)
                    {
                        case Word.GENDER.MALE:
                        case Word.GENDER.FEMALE:
                        case Word.GENDER.NEUTER:
                        case Word.GENDER.PLURAL:
                        default:
                            return "heheheha";
                    }
                default:
                    return "heheheha";
            }
        }
    }
}
