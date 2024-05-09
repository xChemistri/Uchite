using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dictionary : MonoBehaviour
{
    private Translatable word;

    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] TMPro.TMP_Text selection;
    [SerializeField] TMPro.TMP_Text tclass;
    [SerializeField] TMP_InputField input;

    public void Find ()
    {
        Debug.Log("called");
        
        int type = -1;

        AdjectiveEntry ae = AdjectiveEntry.Grab(input.text);
            if (ae != null) type = 0;
        SubjectEntry se = SubjectEntry.Grab(input.text);
            if (se != null) type = 1;
        VerbEntry ve = VerbEntry.Grab(input.text);
            if (ve != null) type = 2;
        
        switch (type)
        {
            default:
                text.text = "Not found!";
                break;
            case 0:
                text.text = ae.GetAs(0,0) + "\n" + ae.GetAs(0,1) + "\n" + ae.GetAs(0,2) + "\n" + ae.GetAs(0,3) + "\n" + ae.GetAs(0,4) + "\n" + ae.GetAs(0,5);
                break;
            case 1:
                text.text = se.GetAs(0,0) + "\n" + se.GetAs(0,1) + "\n" + se.GetAs(0,2)+ "\n" + se.GetAs(0,3)+ "\n" + se.GetAs(0,4)+ "\n" + se.GetAs(0,5);
                break;
            case 2:
                text.text = ve.GetAs(1,0) + "\n" + ve.GetAs(1,1) + "\n" + ve.GetAs(1,2) + "\n" + ve.GetAs(1,3) + "\n" + ve.GetAs(1,4) + "\n" + ve.GetAs(1,5);
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
