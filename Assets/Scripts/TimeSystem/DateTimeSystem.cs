using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// <para>In-game Date time system</para>
/// 
/// <para>
/// <br>HOW TO USE:</br>
///     <br>- To get hour from Date time system you need to call DateTimeSystem.GameClockInstance.hour</br>
///     <br>- It's the same for other time elements like minutes, day, month, year</br>
/// </para>
/// </summary>
[Serializable]
public class DateTimeSystem : MonoBehaviour
{
    // UI references
    [Header("UI for text")]
    public TextMeshProUGUI[] UI_TIME_TEXT;
    public TextMeshProUGUI[] UI_DATE_TEXT;

    [Header("Game Minute / Realtime Second")]
    public float realSecPerGameMin = 1;

    [Header("Time Format Display")]
    public TimeFormat timeFormat = TimeFormat.Hour_24;
    public DateFormat dateFormat = DateFormat.DD_MM_YYYY;

    // Singleton instance
    public static DateTimeSystem GameClockInstance;

    // UI text display
    private string _timeForUiDisplay;
    private string _dateForUiDisplay;
    private bool isAm = false;

    [HideInInspector]
    public int hour { get; private set; }
    [HideInInspector]
    private int min;

    public int Min
    {
        get { return min; }
        set
        {
            min = value;
            OnTimeChanged();
        }
    }

    [HideInInspector]
    public int day { get; private set; }
    [HideInInspector]
    public int month { get; private set; }
    [HideInInspector]
    public int year { get; private set; }

    // Real world max element format
    int maxHr = 24;
    int maxMin = 60;
    int maxDay = 30;
    int maxMonth = 12;

    // Runtime timer
    float timer = 0;

    // Re-built format
    public enum TimeFormat
    {
        Hour_24,
        Hour_12
    }

    public enum DateFormat
    {
        MM_DD_YYYY,
        DD_MM_YYYY,
        YYYY_MM_DD,
        YYYY_DD_MM
    }

    #region Event to trigger when time change

    // Create and event handler
    public event System.EventHandler MinuteLoopEvent;

    // Function called when min variable change
    protected virtual void OnTimeChanged()
    {
        MinuteLoopEvent?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    private void Awake()
    {
        // Singleton pattern
        if (GameClockInstance == null)
        {
            GameClockInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Get start time from User system. ACTUALLY WE WILL LOAD FROM SAVE FILE
        /*hour = System.DateTime.Now.Hour;
        min = System.DateTime.Now.Minute;
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;*/
        hour = 7;
        min = 0;
        day = 6;
        month = 9;
        year = 2021;

        // Only use for 12 hours display
        if (hour < 12)
        {
            isAm = true;
        }
        else
        {
            isAm = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= realSecPerGameMin)
        {
            Min++; // Using Min rather than min when assign to make Event work
            if (min >= maxMin)
            {
                Min = 0; // Using Min rather than min when assign to make Event work
                hour++;
                if (hour >= maxHr)
                {
                    hour = 0;
                    day++;
                    if (day >= maxDay)
                    {
                        day = 1;
                        month++;
                        if (month >= maxMonth)
                        {
                            month = 1;
                            year++;
                        }
                    }
                }
            }

            SetTimeToUIWithFormat();

            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    public DateTime GetDay()
    {
        return new DateTime(year,month,day);
    }
    public void GoToNextDay() {
        timer = 0;
        Min = 0;
        hour = 6;
        day++;
        if (day >= maxDay)
        {
            day = 1;
            month++;
            if (month >= maxMonth)
            {
                month = 1;
                year++;
            }
        }
    }

    #region UI format for display

    void SetTimeToUIWithFormat()
    {
        switch (timeFormat)
        {
            case TimeFormat.Hour_12:
                {
                    int h;
                    if (hour >= 13)
                    {
                        h = hour - 12;
                    }
                    else if (hour == 0)
                    {
                        h = 12;
                    }
                    else
                    {
                        h = hour;
                    }

                    _timeForUiDisplay = h + ":";

                    if (min <= 9)
                    {
                        _timeForUiDisplay += "0" + min;
                    }
                    else
                    {
                        _timeForUiDisplay += min;
                    }

                    if (isAm)
                    {
                        _timeForUiDisplay += " AM";
                    }
                    else
                    {
                        _timeForUiDisplay += " PM";
                    }
                    break;
                }
            case TimeFormat.Hour_24:
                {
                    if (hour <= 9)
                    {
                        _timeForUiDisplay = "0" + hour + ":";
                    }
                    else
                    {
                        _timeForUiDisplay = hour + ":";
                    }

                    if (min <= 9)
                    {
                        _timeForUiDisplay += "0" + min;
                    }
                    else
                    {
                        _timeForUiDisplay += min;
                    }
                    break;
                }

        }

        switch (dateFormat)
        {
            case DateFormat.MM_DD_YYYY:
                {
                    _dateForUiDisplay = day + "/" + month + "/" + year;
                    break;
                }
            case DateFormat.DD_MM_YYYY:
                {
                    _dateForUiDisplay = month + "/" + day + "/" + year;
                    break;
                }
            case DateFormat.YYYY_DD_MM:
                {
                    _dateForUiDisplay = year + "/" + day + "/" + month;
                    break;
                }
            case DateFormat.YYYY_MM_DD:
                {
                    _dateForUiDisplay = year + "/" + month + "/" + day;
                    break;
                }
        }

        for (int i = 0; i < UI_TIME_TEXT.Length; i++)
        {
            UI_TIME_TEXT[i].text = _timeForUiDisplay;
        }

        for (int i = 0; i < UI_DATE_TEXT.Length; i++)
        {
            UI_DATE_TEXT[i].text = _dateForUiDisplay;
        }
    }

    #endregion
}
