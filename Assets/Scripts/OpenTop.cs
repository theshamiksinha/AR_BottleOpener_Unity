using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTop : MonoBehaviour
{
    public float rotationSpeed = 40f;  
    private bool isRotating = false;   
    private float targetAngle = 90f;  
    private float currentAngle = 0f;   

    void Update()
    { 
        if (isRotating)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;  
 
            if (currentAngle + rotationStep >= targetAngle)
            {
                rotationStep = targetAngle - currentAngle; 
                isRotating = false; 
            } 
            
            transform.Rotate(new Vector3(0, -rotationStep, 0));
 
            currentAngle += rotationStep;
        }
    }
 
    public void StartRotation()
    {
        isRotating = true;
        currentAngle = 0f; 
    }
}
