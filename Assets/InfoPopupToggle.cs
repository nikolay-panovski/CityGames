using UnityEngine;
using UnityEngine.Events;

public class InfoPopupToggle : MonoBehaviour
{
    public UnityEvent triggerEntered;
    public UnityEvent triggerExited;

    private void OnTriggerEnter(Collider other)
    {
        triggerEntered.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExited.Invoke();
    }
}
