using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StreakCounter : MonoBehaviour
{
    private int streak, longestStreak;
    private bool newlStreak;

    [SerializeField] Sprite noStreak;
    [SerializeField] Sprite newStreak;
    [SerializeField] Sprite longStreak;
    
    [SerializeField] TMP_Text currCount;
    [SerializeField] TMP_Text longCount;
    [SerializeField] Image icon;

    void Start ()
    {
        FetchData();
        UpdateIcon();
    }
    
    public int Increment ()
    {
        ++streak;
        
        if (streak > longestStreak)
        {
            longestStreak = streak;
            newlStreak = true;
        }
        
        UpdateIcon();
        WriteData();

        return streak;
    }

    public int Reset ()
    {
        streak = 0;
        newlStreak = false;

        UpdateIcon();
        WriteData();

        return streak;
    }

    public int Streak ()
    {
        return streak;
    }

    public int LongestStreak ()
    {
        return longestStreak;
    }

    private void FetchData ()
    {
        streak =
            PlayerPrefs.HasKey("CurrentStreak") ? PlayerPrefs.GetInt("CurrentStreak") : 0;
        longestStreak =
            PlayerPrefs.HasKey("LongestStreak") ? PlayerPrefs.GetInt("LongestStreak") : 0;
        newlStreak =
            PlayerPrefs.HasKey("NewStreak") ? ((PlayerPrefs.GetInt("NewStreak") == 1) ? true : false) : false;


        longCount.text = ""+longestStreak;
        currCount.text = ""+streak;

    }

    private void WriteData ()
    {
        longCount.text = ""+longestStreak;
        currCount.text = ""+streak;

        PlayerPrefs.SetInt("CurrentStreak", streak);
        PlayerPrefs.SetInt("LongestStreak", longestStreak);
        PlayerPrefs.SetInt("NewStreak", newlStreak ? 1 : 0);
    }

    private void UpdateIcon ()
    {
        icon.sprite =
            streak == 0 ? noStreak :
                newlStreak ? longStreak : newStreak;
    }
}
