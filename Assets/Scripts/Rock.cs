using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject obj;
    public Transform start;
    public Transform end;
    public bool moving;
    public bool moved;
    public float moveSpeed = 0.3f;

    public GameObject parentMound;

    void Start()
    {
        moving = false;
        moved = false;
        obj.transform.position = start.position;
        obj.transform.rotation = start.rotation;
    }
    
    void FixedUpdate()
    {
        if (moving)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end.position, moveSpeed);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, end.rotation, moveSpeed);

            
            if (obj.transform.position == end.position && obj.transform.rotation == end.rotation)
            {
                moving = false;
                moved = true;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !moving && !moved)
            {
                moving = true;
                parentMound.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
