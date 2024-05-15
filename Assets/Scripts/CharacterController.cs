using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    private Image image;
    private Transform tr;
    private int direction = 1;

    void Start ()
    {
        image = gameObject.GetComponent<Image>();
        tr = gameObject.GetComponent<Transform>();
        tr.localPosition = new Vector3(-336, 450, 0);
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        switch (direction)
        {
            default:
            case 0:
                break;
            case 1:
                if (tr.localPosition.y < 660)
                    tr.localPosition = new Vector3(-336, tr.localPosition.y+30, 0);
                else
                    direction = 0;
                break;
            case -1:
                if (tr.localPosition.y >= 450)
                    tr.localPosition = new Vector3(-336, tr.localPosition.y-30, 0);
                else
                    direction = 0;
                break;
        }
    }

    public void Hide ()
    {
        direction = -1;
    }

    

    public void New ()
    {
        System.Random gen = new System.Random();

        switch (gen.Next(5))
        {
            default:
            case 0:
                image.sprite = Resources.Load<Sprite>("Characters/GuraG");
                break;
            case 1:
                image.sprite = Resources.Load<Sprite>("Characters/KoroneI");
                break;
            case 2:
                image.sprite = Resources.Load<Sprite>("Characters/OkayuN");
                break;
            case 3:
                image.sprite = Resources.Load<Sprite>("Characters/MinatoA");
                break;
            case 4:
                image.sprite = Resources.Load<Sprite>("Characters/ShionM");
                break;
        }

        direction = 1;
    }
}
