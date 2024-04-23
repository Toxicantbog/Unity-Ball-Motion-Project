using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class BallMotion : MonoBehaviour
{
    public double PositionX,VelocityX,AccelerationX;
    public double PositionY,VelocityY,AccelerationY;
    public Vector3 mouse;
    double Kp=0.015;
    double Ki=0.0000001;
    double Kd=0.1;
    public double Ix,Dx,Iy,Dy;
    double ErrorX,ErrorY,PreviousErrorX,PreviousErrorY;

    // Start is called before the first frame update
    void Start()
    {
        PositionX=370;
        PositionY=165;
    }

    // Update is called once per frame
    void Update()
    {
        SetPositionX();
        SetPositionY();
        MousePosition();
        RearrangePosition();
        MoveToPosition();
        Move();
        transform.Translate ((float)VelocityX,(float)VelocityY,0f); 
        PreviousErrorX=ErrorX;
        PreviousErrorY=ErrorY;
    }

    public void SetPositionX()
    {
        PositionX += VelocityX;
    }

    public void SetPositionY()
    {
        PositionY+=VelocityY;
    }
    public void MousePosition()
    {
        mouse[0]=(int)Math.Round(Input.mousePosition[0]);
        mouse[1]=(int)Math.Round(Input.mousePosition[1]);
    }

    public void RearrangePosition()
    {
        if(Input.GetMouseButton(1))
        {
            PositionX=mouse[0];
            PositionY=mouse[1];
        }
    }

    public void MoveToPosition()
    {
        if(Input.GetKey("q"))
        {
            if(Ix==0||Math.Abs(VelocityX)>0.1||Math.Abs(AccelerationX)>0.1||mouse[0]!=Math.Round(PositionX))
            {
                ErrorX = mouse[0]-PositionX;
                Ix += ErrorX;
                Dx = ErrorX-PreviousErrorX;
                AccelerationX=Kp*ErrorX + Ki*Ix + Kd*Dx;
            }
            else
            {
                VelocityX=0;
                AccelerationX=0;
            }

            if(Iy==0||Math.Abs(VelocityY)>0.1||Math.Abs(AccelerationY)>0.1||mouse[1]!=Math.Round(PositionY))
            {
                ErrorY = mouse[1]-PositionY;
                Iy += ErrorY;
                Dy = ErrorY-PreviousErrorY;
                AccelerationY=Kp*ErrorY + Ki*Iy + Kd*Dy;    
            }
            else
            {
                VelocityY=0;
                AccelerationY=0;
            }
            
        }
        else
        {
            Iy=0;
            Dy=0;
            Ix=0;
            Dx=0;
        }

    }

    public void Move()
    {
        VelocityX+=AccelerationX;
        VelocityY+=AccelerationY;
    }

    public Boolean DeadbandX()
    {
        if(Math.Abs(VelocityX)<0.001&&Math.Abs(AccelerationX)<0.001)
        {
            return false;
        }
        return true;
    }
    public Boolean DeadbandY()
    {
        if(Math.Abs(VelocityY)<0.001&&Math.Abs(AccelerationY)<0.001)
        {
            return false;
        }
        return true;
    }
}