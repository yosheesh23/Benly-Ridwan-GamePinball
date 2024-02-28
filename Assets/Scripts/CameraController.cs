using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;
    public Transform target;

    private Vector3 defaultPosition;

    public bool hasTarget {get { return target != null; } }

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        if (hasTarget)
        {
             Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
             Vector3 targetPosition = target.position + (targetToCameraDirection * length);

             transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTranform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTranform;
        length = targetLength;
    }

    public void GoBackToDefault()
    {
        target = null;

        //gerakan ke posisi default dalam waktu return time
        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTime));

    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            //pindahkan posisi camera secara bertahap

            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
