using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    public enum Gender
    {
        MALE, FEMALE, NEUTER, PLURAL
    }

    public enum Case
    {
        NOM, GEN, DAT, ACC, INST, PREP
    }

    private string[][] translations;
    private string word;

    string translate(Gender gender, Case declension)
    {
        return translations[(int)gender][(int)declension];
    }

    void Start() {}
    void Update() {}
}
