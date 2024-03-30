using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private int streak = 0;
    private bool answered = false;
    private Statement statement;

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
    	if (!answered)
    	{
			if (statement.Verify(input.text).Equals(""))
			{
				Debug.Log("TRUE: " + input.text);
				streak++;
				New();
			}
			else
			{
				Debug.Log("FALSE: " + input.text + ", NOT " + statement.RuStr());
				streak = 0;
				text.text = statement.Verify(input.text);
				input.text = null;
				answered = true;
			}
        }
        else
        {
        	New();
        	answered = false;
        }
    }

    public void New ()
    {
    	streakcnt.text = "" + streak;
        statement = new Statement();
        text.text = statement.EnStr();
        input.text = null;
    }
}
