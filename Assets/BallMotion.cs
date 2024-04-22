using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class BallMotion : MonoBehaviour
{
    public double PositionX,VelocityX,AccelerationX;
    public Vector3 mouse;
    public double Kp=0.001;
    public double Ki=0.00001;
    public double Kd=0.07;
    double I,D;
    double Error,PreviousError;

    // Start is called before the first frame update
    void Start()
    {
        PositionX=370;
    }

    // Update is called once per frame
    void Update()
    {
        SetPositionX();
        MousePosition();
        RearrangePosition();
        MoveToPosition();
        Move();
        transform.Translate ((float)VelocityX,0f,0f); 
        PreviousError=Error;
    }

    public void SetPositionX()
    {
        PositionX += VelocityX;
    }

    public void MousePosition()
    {
        mouse=Input.mousePosition;
    }

    public void RearrangePosition()
    {
        if(Input.GetMouseButton(1))
        {
            PositionX=mouse.x;
        }
    }

    public void MoveToPosition()
    {
        if(Input.GetKey("q"))
        {
            Error = mouse.x-PositionX;
            I += Error;
            D = Error-PreviousError;
            AccelerationX=Kp*Error + Ki*I + Kd*D;
            AccelerationLimit(AccelerationX);
            if(Deadband())
            {
                VelocityX=0;
                AccelerationX=0;
            }
        }
    }

    public void Move()
    {
        VelocityX+=AccelerationX;
    }

    public void AccelerationLimit(double acceleration)
    {
        if(acceleration>0.1)
        {
            AccelerationX=0.1;
        }
        else if(acceleration<-0.1)
        {
            AccelerationX=-0.1;
        }
    }

    public double PID(double tempPositionX,double tempMousePosition)
    {
        Error = tempMousePosition-tempPositionX;
        I += Error;
        D = Error-PreviousError;
        return Kp * Error + Ki * I + Kd * D;
    }

    public Boolean Deadband()
    {
        if(Math.Abs(VelocityX)<0.0001&&Math.Abs(AccelerationX)<0.00001)
        {
            return true;
        }
        return false;
    }
}


