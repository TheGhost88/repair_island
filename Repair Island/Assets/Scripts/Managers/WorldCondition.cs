using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Information about the world (Daytime, weather, any other world events)
/// </summary>
public class WorldCondition : MonoBehaviour
{
    public static WorldCondition Instance = null;
    public DayTimeCycle dayTimeCycle;
    public Weather weather;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.Init();
        }
        else
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Init()
    {
        weather = new Weather();
        dayTimeCycle = new DayTimeCycle();
    }

    private void Update()
    {
        dayTimeCycle.Update();
    }

}

[System.Serializable]
public class DayTimeCycle
{
    public int hour;
    public float minute;
    public int day;
    public enum Season { Winter = 0, Spring, Summer, Fall};
    public Season season;
    //The ratio to determine how many real time seconds per game seconds
    const float realTimeToGameTimeRatio = .5f;

    public DayTimeCycle()
    {
        hour = 0;
        minute = 0;
        day = 0;
        season = Season.Summer;
    }
    public void Update()
    {
        minute += Time.deltaTime * realTimeToGameTimeRatio;
        if (minute >= 60f)
        {
            minute -= 60f;
            hour++;
        }
    }
}

[System.Serializable]
public class Weather
{
    public enum StormType { Tranquil = 0, Thunder, Blizzard, Tornado, Hurricane, Meteors, Radiation, Earthquake}
    public StormType currentStormType;
    float timeSinceLastStorm = 0;
    float perciptation;
    int temperature;

    public Weather()
    {
        currentStormType = StormType.Tranquil;
        perciptation = 0f;
        timeSinceLastStorm = 0f;
        temperature = 70;
    }

}
