using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{

    // %10 noise = .1f noisePercentage
    public static float Noise(float number, float noisePercentage)
    {
        return number + (number * Random.Range(-noisePercentage, noisePercentage));
    }

}