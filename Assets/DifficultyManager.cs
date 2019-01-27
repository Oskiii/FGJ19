using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private string[] DayNames = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
    public int Day { get; private set; }
    public string DayString
    {
        get
        {
            return DayNames[Day];
        }
    }

    public static DifficultyManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        Day = PlayerPrefs.GetInt("Day", 0);
    }

    public void Increase()
    {
        Day += 1;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Day", Day);
    }
}