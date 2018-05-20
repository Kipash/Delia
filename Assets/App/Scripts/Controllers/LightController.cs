using UnityEngine;
using System.Collections;
using Zenject;

public class LightController
{
    [Inject(Id = "MainLight")] Transform light;

    int day = 24 * 60 * 60; //=360°

    public void OnTimeChanged(int hours, int minutes, int seconds)
    {
        float totalSeconds = (hours * 3600) + (minutes * 60) + seconds;
        float angle = ((totalSeconds / day) * 360f) - 100; // 150 - magic value of an offset


        Debug.Log(angle);
        //125 270

        light.gameObject.SetActive(0 < angle && angle < 180);
        light.transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}