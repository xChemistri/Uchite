using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Export : MonoBehaviour
{
    [SerializeField] string stem;
    [SerializeField] string translation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test ()
    {
        Statement s = new Statement();
        Debug.Log(s.RuString() + '-' + s.EnString());
    }
    public void Create ()
    {
        AdjectiveEntry thing = new AdjectiveEntry();
        thing.CreateEntry(stem, translation);

        Debug.Log("Out call");
    }
}
