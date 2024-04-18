using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class BallMotion : MonoBehaviour
{
    public double PositionX,VelocityX;
    public double PositionY,VelocityY;
    public double Speed,AccelerationXY;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetPositionX();
        SetPositionY();
        ChangeValues();
        transform.Translate ((float)VelocityX,(float)VelocityY,0f); 
        GetSpeed();
    }

    public void ChangeValues()
    {
        if(Input.GetKey("a")){
            SetVelocityX(-AccelerationXY);
        }
        if(Input.GetKey("d")){  
            SetVelocityX(AccelerationXY);
        }
        if(Input.GetKey("w")){
            SetVelocityY(AccelerationXY);
        }
        if(Input.GetKey("s")){
            SetVelocityY(-AccelerationXY);
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


