using UnityEngine;
using System.Collections;

public class VideoEndHandler : MonoBehaviour
{
    public GameObject objectToDisable;    // GameObject to disable after delay
    public GameObject objectToEnable;     // GameObject to enable after delay
    public float delaySeconds = 420f;      // Adjustable delay in seconds

    void Awake()
    {
        StartCoroutine(HandleDelay());
    }

    IEnumerator HandleDelay()
    {
        yield return new WaitForSeconds(delaySeconds);

        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);
    }
}
