using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    bool shaking = false;

    private void FixedUpdate()
    {


        Debug.Log(shaking);
        if (Input.GetKeyDown(KeyCode.F) && !shaking)
        {
            shaking = true;
            StartCoroutine(Shake(Random.Range(0.15f, 1.3f), Random.Range(0.05f, 0.1f)));
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float timeElapsed = 0.0f;

        while (timeElapsed < duration)
        {
            // shake
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            timeElapsed += Time.deltaTime;
            if (timeElapsed == duration)
            {
                shaking = false;
            }
            yield return null;
        }
    }
    

}
