using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceTraveled : MonoBehaviour
{
    public float distance;
    public TMP_Text distanceText;
    public bool isRunning = true;

    void Start()
    {
        distance = 0;
        distanceText.text = distance + "m";
        StartDistance();
    }

    void Update()
    {
        if (isRunning)
        {
            distance += Time.deltaTime;
            distanceText.text = ((int)distance).ToString() + "m";
        }
    }

    public void StartDistance()
    {
        isRunning = true;
    }

    public void StopDistance()
    {
        isRunning = false;
    }
}