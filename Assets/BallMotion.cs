using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class BallMotion : MonoBehaviour
{
    public double PositionX,VelocityX,AccelerationX;
    public double PositionY,VelocityY,AccelerationY;
    public double Speed,AccelerationXY;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AccelerationX=AccelerationXY;
        AccelerationY=AccelerationXY;
        SetPositionX();
        SetPositionY();
        ChangeValues();
        transform.Translate ((float)VelocityX,(float)VelocityY,0f); 
        GetSpeed();
    }

    public void ChangeValues()
    {
        if(Input.GetKey("a")){
            SetVelocityX(-AccelerationX);
        }
        if(Input.GetKey("d")){  
            SetVelocityX(AccelerationX);
        }
        if(Input.GetKey("w")){
            SetVelocityY(AccelerationY);
        }
        if(Input.GetKey("s")){
            SetVelocityY(-AccelerationY);
        }
    }
    public void SetVelocityX(double acceleration)
    {
        VelocityX += acceleration;
    }
    
    public void SetPositionX()
    {
        PositionX += VelocityX;
    }

    public void SetVelocityY(double acceleration)
    {
        VelocityY += acceleration;
    }

    public void SetPositionY()
    {
        PositionY += VelocityY;
    }

    public void GetSpeed(){
        Speed = math.sqrt(Math.Pow(Math.Abs(VelocityX),2)+Math.Pow(Math.Abs(VelocityY),2)); 
    }
}


