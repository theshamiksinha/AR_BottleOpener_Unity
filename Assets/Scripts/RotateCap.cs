using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 70f;    
    public float liftSpeed = 0.075f;     
    public float liftDistance = 0.10f;  
    private bool isRotating = false;  
    private float targetAngle = 90f;   
    private float currentAngle = 0f;    
    private float liftedDistance = 0f;  

    private Vector3 startPosition;     

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        if (isRotating)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            float liftStep = liftSpeed * Time.deltaTime;

            if (currentAngle + rotationStep >= targetAngle)
            {
                rotationStep = targetAngle - currentAngle; 
                isRotating = false;
            }
 
            if (liftedDistance + liftStep >= liftDistance)
            {
                liftStep = liftDistance - liftedDistance;
            }
 
            transform.Rotate(new Vector3(0, rotationStep, 0));
 
            transform.position += new Vector3(0, liftStep, 0);
 
            currentAngle += rotationStep;
            liftedDistance += liftStep;
 
            if (currentAngle >= targetAngle && liftedDistance >= liftDistance)
            {
                isRotating = false;
            }
        }
    }
 
    public void StartRotation()
    {
        if (!isRotating)
        {
            isRotating = true;
            currentAngle = 0f;        
            liftedDistance = 0f;      
            startPosition = transform.position;
        }
    }
}
