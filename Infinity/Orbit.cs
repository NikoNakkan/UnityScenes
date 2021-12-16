using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
    public Transform orbitObject;
    public Hyperbola orbitPath;

    [Range(0f,1f)]
    public float orbitProgress=0f;
    public float orbitPeriod=3f;
    public bool orbitActive = true;
    private int multiplier = 4;


    void Start () {
        if (orbitObject == null)
        {
            orbitActive = false;
            return;
        }
        setOrbitingObjectPosition();
        StartCoroutine("AnimateOrbit");
	}
    void setOrbitingObjectPosition()
    {
        Vector2 position = orbitPath.Evaluate(orbitProgress);
        orbitObject.localPosition = new Vector3(position.x, position.y, 0f);

    }
    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
            orbitPeriod = 0.1f;
        float orbitSpeed = 1f / orbitPeriod;
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
           // orbitProgress %= 1f;
            setOrbitingObjectPosition();
            yield return null;
        }
    }
    void Update()
    {
        SpeedUpByZ();
        SlowDownByX();
        InitializeMiddleSuceessEvent();

    }


    private void SpeedUpByZ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            orbitPeriod = orbitPeriod / 2f;
            RestartAnimation();
           

        }
        if (Input.GetKeyUp(KeyCode.Z))
            orbitPeriod = orbitPeriod * 2f;
        RestartAnimation();
    }
    private void SlowDownByX()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            orbitPeriod = orbitPeriod * multiplier;
            RestartAnimation();


        }
        if (Input.GetKeyUp(KeyCode.X))
            orbitPeriod = orbitPeriod / multiplier;
        RestartAnimation();
    }
    private void InitializeMiddleSuceessEvent()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            MiddleSuccessEvent();
        }
    }



    private void RestartAnimation()
    {
        StopCoroutine("AnimateOrbit");
        StartCoroutine("AnimateOrbit");
    } 
    

    private void MiddleSuccessEvent()
    {
        Vector2 dimensions2D= GameObject.Find("MyMainSphere").transform.position;
        float x = dimensions2D.x;
        float y = dimensions2D.y;
       
        if(Apoluto(y)<=0.001&& Apoluto(x) <= 0.001)
        {
            print("WTF BROOOOOOOOOOOOOO APEIROPODAROUSAS KANEKIS");
        }

        else if (Apoluto(y) <= 0.05 && Apoluto(x) <= 0.05)
        {
            print("PERFECT");
        }

        else if (Apoluto(y) <= 0.1 && Apoluto(x) <= 0.1)
        {
            print("MAMA MIA");
        }

        else if ( Apoluto(y)<= 0.2 && Apoluto(x) <= 0.2)
        {
            print("Nice");
            
        }
        
        
        

    }
    private float Apoluto(float x)
    {
        if (x < 0)
        {
            x = -x;
        }
        return x;
    }

}
