using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class HyperbolaRenderer : MonoBehaviour {

    
    LineRenderer lr;

    [Range(3, 128)]
    public int segments;
    public Hyperbola hyperbola;

     void Awake()
    {
        print("Done");
        lr = GetComponent <LineRenderer > () ;
        calculateHyperbola();
    }

    void calculateHyperbola()
    {
        Vector3[] points = new Vector3[segments + 1];
        for(int i = 0; i < segments; i++)
        {
            float angle = ((float)i / (float)segments) * 360 * Mathf.Deg2Rad;
            Vector2 info2D =hyperbola.Evaluate(angle);
            points[i] = new Vector3(info2D.x, info2D.y, 0f);
        }
        points[segments] = points[0];
        lr.positionCount = segments + 1;
        lr.SetPositions(points);
        
    }
    private void OnValidate()
    {
        if(Application.isPlaying)
        calculateHyperbola();
    }
}