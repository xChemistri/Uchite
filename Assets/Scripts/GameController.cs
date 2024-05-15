using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool answered = false;
    private Statement statement;
    private StreakCounter counter;
    private int moving = 0;

    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] TMP_InputField input;
    [SerializeField] CheckButtonScript checker;

    [SerializeField] GameObject correct;
    [SerializeField] GameObject incorrect;

    [SerializeField] CharacterController character;
    private bool charhide = true;

    private AudioController audioController;

    // Start is called before the first frame update
    void FixedUpdate ()
    {
        switch (moving)
        {
            case 0:
            default:
                break;
            case 1:
                correct.GetComponent<Transform>().localPosition =
                new Vector3(-1.6689f, correct.GetComponent<Transform>().localPosition.y-75, 0);

                if (correct.GetComponent<Transform>().localPosition.y <= -340.0f)
                    moving = 0;

                break;
            case 2:
                incorrect.GetComponent<Transform>().localPosition =
                new Vector3(-1.6689f, incorrect.GetComponent<Transform>().localPosition.y-75, 0);

                if (incorrect.GetComponent<Transform>().localPosition.y <= -340.0f)
                    moving = 0;

                break;
            case 3:
                correct.GetComponent<Transform>().localPosition = new Vector3(-1.6689f, 0, 0);
                incorrect.GetComponent<Transform>().localPosition = new Vector3(-1.6689f, 0, 0);
                moving = 0;
                break;
                
        }
    }
    void Start ()
    {
        counter = GameObject.FindWithTag("StreakCounter").GetComponent<StreakCounter>();
        audioController = this.GetComponent<AudioController>();
        New();
    }

    public void Submit ()
    {
    	if (!answered)
    	{
			if (statement.Verify(input.text).Equals(""))
			{
                checker.setColor(2);
                checker.press();
                answered = true;
				counter.Increment();

                correct.GetComponentInChildren<TMPro.TMP_Text>().text = "Nice job!";
                moving = 1;

                audioController.PlayCorrect();
			}
			else
			{
                checker.setColor(0);
                checker.press();
				counter.Reset();
				incorrect.GetComponentInChildren<TMPro.TMP_Text>().text = statement.Verify(input.text);
                moving = 2;
				answered = true;
                audioController.PlayIncorrect();

                character.Hide();
                charhide = true;
			}
        }
        else
        {
            checker.setColor(1);
            checker.depress();
        	New();
        	answered = false;
            moving = 3;
        }
    }

    public void New ()
    {
        statement = new Statement();
        text.text = statement.EnDisplay();
        input.text = null;

        if (charhide)
        {
            character.New();
            charhide = false;
        }
    }
}
