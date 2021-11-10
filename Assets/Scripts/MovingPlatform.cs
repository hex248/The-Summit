﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform myPlatform;
    public Transform myStartPoint;
    public Transform myEndPoint;

    bool isReversing = false;

    public float speed = 0.1f;

    void Start()
    {
        myPlatform.position = myStartPoint.position;
    }

    void FixedUpdate()
    {
        if (!isReversing)
        {
            myPlatform.position = Vector3.MoveTowards(myPlatform.position, myEndPoint.position, speed);
            
            if (myPlatform.position == myEndPoint.position)
            {
                isReversing = true;
            }
        }
        else
        {
            myPlatform.position = Vector3.MoveTowards(myPlatform.position, myStartPoint.position, speed);

            if (myPlatform.position == myStartPoint.position)
            {
                isReversing = false;
            }
        }
    }
}
