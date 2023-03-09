using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    [SerializeField] private Transform _target;

    [SerializeField] private float _duration;
    [SerializeField] private float _delay;
    // Start is called before the first frame update

    void Start()
    {

    }

    [ContextMenu("Start Target Movement")]
    private void TestStartCoroutine()
    {
        StartCoroutine(TargetMovement());
    }

    [ContextMenu("Start Delayed Action")]
    private void TestDelayedAction()
    {
        StartCoroutine(DelayedAction(_delay, TestStartCoroutine));
    }

    private IEnumerator TargetMovement()
    {
        Debug.Log($"[{GetType().Name}][TargetMovement] Start");
        var timeCounter = 0f;
        _target.position = _startPoint.position;
        while (timeCounter < _duration)
        {
            var normalizedTime = timeCounter / _duration;
            _target.position = Vector3.Lerp(_startPoint.position, _endPoint.position, normalizedTime);

            timeCounter += Time.deltaTime;
            yield return null;
        }

        Debug.Log($"[{GetType().Name}][TargetMovement] Complete");
    }

    private IEnumerator DelayedAction(float time, System.Action action)
    {
        Debug.Log($"[{GetType().Name}][DelayedAction] Start");
        yield return new WaitForSeconds(time);

        action?.Invoke();
        Debug.Log($"[{GetType().Name}][DelayedAction] Complete");
    }

}