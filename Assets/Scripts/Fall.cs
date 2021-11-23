using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Lift log;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!log.lifting && !log.falling)
            {
                log.Fall();
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!log.lifting && !log.falling)
            {
                log.Fall();
            }
        }
    }
}
