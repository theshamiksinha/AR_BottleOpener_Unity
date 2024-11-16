using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnRotateCap : MonoBehaviour
{
    public float rotationSpeed = 70f; 
    public float liftSpeed = 0.075f;      
    public float liftDistance = 0.10f;  
    private bool isReversing = false;  
    private float targetAngle = 0f; 
    private float currentAngle = 90f; 
    private float liftedDistance = 0f;  

    private Vector3 startPosition; 

    void Start()
    {
        startPosition = transform.position + new Vector3(0, liftDistance, 0);  
    }

    void Update()
    {
         
        if (isReversing)
        {
            float rotationStep = rotationSpeed * Time.deltaTime; 
            float liftStep = liftSpeed * Time.deltaTime;         
 
            if (currentAngle - rotationStep <= targetAngle)
            {
                rotationStep = currentAngle - targetAngle; 
                isReversing = false; 
            }
 
            if (liftedDistance - liftStep <= 0)
            {
                liftStep = liftedDistance;  
            }
 
            transform.Rotate(new Vector3(0, -rotationStep, 0));
 
            transform.position -= new Vector3(0, liftStep, 0);
 
            currentAngle -= rotationStep;
            liftedDistance -= liftStep;
 
            if (currentAngle <= targetAngle && liftedDistance <= 0)
            {
                isReversing = false;
            }
        }
    }
 
    public void StartReverse()
    {
        isReversing = true;
        liftedDistance = liftDistance;  
        currentAngle = 90f;           
    }
}
