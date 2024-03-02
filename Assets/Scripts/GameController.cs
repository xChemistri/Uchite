using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int streak = 0;
    [SerializeField] Statement statement;

    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] TMPro.TextMeshProUGUI input;
    [SerializeField] TMPro.TextMeshProUGUI streakcnt;

    // Start is called before the first frame update
    void Start ()
    {
        Statement st = new Statement();
        streakcnt.text = "" + streak;
        statement = new Statement();
        text.text = statement.RuString();
    }

    public void Submit ()
    {
        if (statement.Verify(input.text))
        {
            Debug.Log("TRUE: " + input.text + ", " + statement.EnString());

            streak++;

            streakcnt.text = "" + streak;
            statement = new Statement();
            text.text = statement.RuString();

            
        }
        else
        {
            Debug.Log("FALSE: " + input.text + ", NOT " + statement.EnString());

            streak = 0;

            streakcnt.text = "" + streak;
            statement = new Statement();
            text.text = statement.RuString();
        }
    }
}
