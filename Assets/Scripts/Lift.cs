using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public bool moving;
    public GameObject obj;
    public Transform start;
    public Transform end;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        obj.transform.position = start.position;
        obj.transform.rotation = start.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, end.position, speed);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, end.rotation, speed);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !moving)
            {
                // move
                moving = true;
                Debug.Log("a");
            }
        }
    }
}
