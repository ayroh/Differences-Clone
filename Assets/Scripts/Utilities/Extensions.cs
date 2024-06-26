using UnityEngine;

public static class Extentions
{

    // %10 noise = .1f noisePercentage
    public static float Noise(float number, float noisePercentage)
    {
        return number + (number * Random.Range(-noisePercentage, noisePercentage));
    }

    public static float RandomWithNegativeChance(float minInclusivePositive, float maxInclusivePositive)
    {
        float number = Random.Range(minInclusivePositive, maxInclusivePositive);
        return (Random.Range(-1f, 1f) > 0) ? number : -number;
    }

}