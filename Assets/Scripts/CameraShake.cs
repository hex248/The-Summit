using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shaking = false;
    public float interval = 0.0f;
    public float timeElapsed = 0.0f;

    void Update() {
        timeElapsed += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (interval == 0.0f) {
            interval = Random.Range(0.8f, 1.5f);
        }

        if (timeElapsed >= interval && !shaking)
        {
            shaking = true;
            StartCoroutine(Shake(Random.Range(0.15f, 1.3f), Random.Range(0.03f, 0.1f)));
        }
        if (timeElapsed >= interval) {
            interval = Random.Range(0.8f, 1.5f);
            timeElapsed = 0.0f;
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
            if (timeElapsed >= duration)
            {
                shaking = false;
            }
            yield return null;
        }
    }
    

}
