using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Hyperbola
{
    public float xAxis;
    public float yAxis;

    public Hyperbola(float xAxis,float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;

    }
    public Vector2 Evaluate(float t)
    {
        float scale = 2 / (3 - Mathf.Cos(2 * t));
        float y = scale * Mathf.Sin(2 * t) / 2 * yAxis;
        float x = scale * Mathf.Cos(t) * xAxis;

        return new Vector2(x, y);

    }
}

