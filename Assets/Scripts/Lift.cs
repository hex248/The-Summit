using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public bool lifting;
    public bool falling;
    public GameObject obj;
    public Transform start;
    public Transform end;
    public float liftSpeed = 0.05f;
    public float fallSpeed = 0.3f;

    public BoxCollider blocker;
    
    void Start()
    {
        lifting = false;
        falling = false;
        obj.transform.position = end.position;
        obj.transform.rotation = end.rotation;
    }
    
    void FixedUpdate()
    {
        if (lifting)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end.position, liftSpeed);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, end.rotation, liftSpeed);

            if (obj.transform.position == end.position && obj.transform.rotation == end.rotation)
            {
                lifting = false;
                blocker.isTrigger = true;
            }
        }
        else if (falling)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, start.position, fallSpeed);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, start.rotation, fallSpeed);

            if (obj.transform.position == start.position && obj.transform.rotation == start.rotation)
            {
                falling = false;
                blocker.isTrigger = false;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !falling && !lifting)
            {
                lifting = true;
            }
        }
    }

    public void Fall()
    {
        falling = true;
    }
}
