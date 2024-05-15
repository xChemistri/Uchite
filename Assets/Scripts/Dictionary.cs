using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dictionary : MonoBehaviour
{
    private int iclass = 0;
    private int itype = -1;

    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] TMPro.TMP_Text selection;
    [SerializeField] TMPro.TMP_Text tclass;
    [SerializeField] TMP_InputField input;

    private AdjectiveEntry ae;
    private SubjectEntry se;
    private VerbEntry ve;

    public void SwitchClass (int dir)
    {
        iclass += dir;
        switch (itype)
        {
             default:
                iclass = 0;
                tclass.text = "";
                selection.text = "";
                text.text = "";
                break;
            case 0:
                iclass = iclass < 0 ? 3 : iclass > 3 ? 0 : iclass;
                switch (iclass)
                {
                    default:
                    case 0:
                        selection.text = "Masculine";
                        break;
                    case 1:
                        selection.text = "Feminine";
                        break;
                    case 2:
                        selection.text = "Neuter";
                        break;
                    case 3:
                        selection.text = "Plural";
                        break;
                }
                text.text = ae.GetAs(iclass,0) + "\n" + ae.GetAs(iclass,1) + "\n" + ae.GetAs(iclass,2) + "\n" + ae.GetAs(iclass,3) + "\n" + ae.GetAs(iclass,4) + "\n" + ae.GetAs(iclass,5);
                break;
            case 1:
                iclass = iclass < 0 ? 1 : iclass > 1 ? 0 : iclass;
                switch (iclass)
                {
                    default:
                    case 0:
                        selection.text = "Singular";
                        break;
                    case 1:
                        selection.text = "Plural";
                        break;
                }
                text.text = se.GetAs(iclass,0) + "\n" + se.GetAs(iclass,1) + "\n" + se.GetAs(iclass,2)+ "\n" + se.GetAs(iclass,3)+ "\n" + se.GetAs(iclass,4)+ "\n" + se.GetAs(iclass,5);
                break;
            case 2:
                iclass = iclass < 0 ? 2 : iclass > 2 ? 0 : iclass;
                switch (iclass)
                {
                    default:
                    case 0:
                        selection.text = "Past";
                        tclass.text = "Он\nОна\nОно\nОни";
                        break;
                    case 1:
                        selection.text = "Present";
                        tclass.text = "Я\nТы\nОн\nМы\nВы\nОни";
                        break;
                    case 2:
                        selection.text = "Future";
                        tclass.text = "Я\nТы\nОн\nМы\nВы\nОни";
                        break;
                }
                text.text =
                    iclass == 0 ?
                    ve.GetAs(iclass,0) + "\n" + ve.GetAs(iclass,1) + "\n" + ve.GetAs(iclass,2) + "\n" + ve.GetAs(iclass,3):
                    ve.GetAs(iclass,0) + "\n" + ve.GetAs(iclass,1) + "\n" + ve.GetAs(iclass,2) + "\n" + ve.GetAs(iclass,3) + "\n" + ve.GetAs(iclass,4) + "\n" + ve.GetAs(iclass,5);
                break;
        }
    }
    

    public void Find ()
    {
        itype = -1;
        iclass = 0;
        ae = null; se = null; ve = null;

        ae = AdjectiveEntry.Grab(input.text + " ");
            if (ae != null) itype = 0;
        se = SubjectEntry.Grab(input.text + " ");
            if (se != null) itype = 1;
        ve = VerbEntry.Grab(input.text + " ");
            if (ve != null) itype = 2;
        
        switch (itype)
        {
            default:
                text.text = "Not found!";
                break;
            case 0:
                tclass.text = "No.\nGe.\nDa.\nAc.\nIn.\nPr.";
                text.text = ae.GetAs(0,0) + "\n" + ae.GetAs(0,1) + "\n" + ae.GetAs(0,2) + "\n" + ae.GetAs(0,3) + "\n" + ae.GetAs(0,4) + "\n" + ae.GetAs(0,5);
                break;
            case 1:
                tclass.text = "No.\nGe.\nDa.\nAc.\nIn.\nPr.";
                text.text = se.GetAs(0,0) + "\n" + se.GetAs(0,1) + "\n" + se.GetAs(0,2)+ "\n" + se.GetAs(0,3)+ "\n" + se.GetAs(0,4)+ "\n" + se.GetAs(0,5);
                break;
            case 2:
                iclass = 1;
                tclass.text = "Я\nТы\nОн\nМы\nВы\nОни";
                text.text = ve.GetAs(1,0) + "\n" + ve.GetAs(1,1) + "\n" + ve.GetAs(1,2) + "\n" + ve.GetAs(1,3) + "\n" + ve.GetAs(1,4) + "\n" + ve.GetAs(1,5);
                break;
        }

        SwitchClass(0);
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