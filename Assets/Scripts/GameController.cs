using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int streak = 0;
    [SerializeField] Statement statement;

    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] TMP_InputField input;
    [SerializeField] TMP_Text streakcnt;

    // Start is called before the first frame update
    void Start ()
    {
        Statement st = new Statement();
        streakcnt.text = "" + streak;
        statement = new Statement();
        text.text = statement.EnStr();
    }

    public void Submit ()
    {
        if (statement.Verify(input.text) == 0)
        {
            Debug.Log("TRUE: " + input.text);

            streak++;

            streakcnt.text = "" + streak;
            statement = new Statement();
            text.text = statement.EnStr();

            
        }
        else
        {
            Debug.Log("FALSE: " + input.text + ", NOT " + statement.RuStr());

            streak = 0;

            streakcnt.text = "" + streak;
            statement = new Statement();
            text.text = statement.EnStr();
        }
    }
}
