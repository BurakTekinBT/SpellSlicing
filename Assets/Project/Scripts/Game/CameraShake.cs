using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Shake Variables")]
    public Transform cameraTransform;
    private float shakeDuration = 0.5f;
    private float shakeIntensity = 0.1f;

    [Header("Position")]
    private Vector3 originalPosition;

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    public void Shake()
    {
        originalPosition = cameraTransform.localPosition;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;
            cameraTransform.localPosition = randomPosition;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition;
    }
}
