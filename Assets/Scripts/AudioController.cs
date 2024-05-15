using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip yes;
    [SerializeField] AudioClip no;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayCorrect ()
    {
        AudioSource.PlayClipAtPoint(yes, new Vector3(0, 0, -10));
    }

    public void PlayIncorrect ()
    {
        AudioSource.PlayClipAtPoint(no, new Vector3(0, 0, -10));
    }
}
