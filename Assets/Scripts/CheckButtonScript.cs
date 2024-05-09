using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtonScript : MonoBehaviour
{
    private int color = 1;
    private bool depressed = false;
    [SerializeField] Image top;
    [SerializeField] Image bottom;

    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    [SerializeField] Sprite green;

    [SerializeField] Sprite dered;
    [SerializeField] Sprite deblue;
    [SerializeField] Sprite degreen;

    // 0 = RED, 1 = BLUE, 2 = GREEN

    public void press ()
    {
        depressed = true;
    }

    public void depress ()
    {
        depressed = false;
    }

    public void setColor (int color)
    {
        this.color = color;
        top.sprite = color == 0 ? red : (color == 1 ? blue : green);
    }

    void Start ()
    {

    }

    void Update ()
    {
        if (depressed && top.transform.localPosition.y > -5)
            top.transform.localPosition =
                new Vector3(top.transform.localPosition.x, top.transform.localPosition.y-1, top.transform.localPosition.z);
        else if (!depressed && top.transform.localPosition.y < 5)
            top.transform.localPosition =
                new Vector3(top.transform.localPosition.x, top.transform.localPosition.y+1, top.transform.localPosition.z);;

        top.sprite = !depressed ? (color == 0 ? red : (color == 1 ? blue : green))
            : color == 0 ? dered : (color == 1 ? deblue : degreen);
    }
}
