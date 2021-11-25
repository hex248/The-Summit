using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform pickup;
    public Transform start;
    public float startY;
    public Transform end;
    public float endY;

    public bool isReversing = false;

    public float speed = 0.1f;

    void Start()
    {
        pickup.position = start.position;
        startY = start.position.y;
        endY = end.position.y;
    }
    
    void FixedUpdate()
    {
        if (!isReversing)
        {
            pickup.position = Vector3.MoveTowards(pickup.position, end.position, speed);

            if (pickup.position == end.position)
            {
                isReversing = true;
            }
        }
        else
        {
            pickup.position = Vector3.MoveTowards(pickup.position, start.position, speed);

            if (pickup.position == start.position)
            {
                isReversing = false;
            }
        }
    }
}
