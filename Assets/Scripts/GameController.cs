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
    [SerializeField] CheckButtonScript checker;

    // Start is called before the first frame update
    void NewGame ()
    {
        Statement st = new Statement();
        streakcnt.text = "" + streak;
        statement = new Statement();
        text.text = statement.EnStr();
    }

    void Start ()
    {
        if (GameObject.FindWithTag("GameController") != null)
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    public void Submit ()
    {
    	if (!answered)
    	{
			if (statement.Verify(input.text).Equals(""))
			{
				Debug.Log("TRUE: " + input.text);
                checker.setColor(2);
                checker.press();
                answered = true;
				streak++;
			}
			else
			{
				Debug.Log("FALSE: " + input.text + ", NOT " + statement.RuStr());
                checker.setColor(0);
                checker.press();
				streak = 0;
				text.text = statement.Verify(input.text);
				input.text = null;
				answered = true;
			}
        }
        else
        {
            checker.setColor(1);
            checker.depress();
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
