using UnityEngine;

public class TouchRotateAndZoom : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    public float zoomSpeed = 0.005f;

    public float minScaleFactor = 0.5f;  // setengah dari skala awal
    public float maxScaleFactor = 1.5f;  // 1.5x dari skala awal

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        // One finger: Rotate Y only
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationY = -touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(Vector3.up * rotationY, Space.Self);
            }
        }
        // Two fingers: Pinch to zoom
        else if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 prevTouch0 = touch0.position - touch0.deltaPosition;
            Vector2 prevTouch1 = touch1.position - touch1.deltaPosition;

            float prevDistance = (prevTouch0 - prevTouch1).magnitude;
            float currentDistance = (touch0.position - touch1.position).magnitude;

            float deltaDistance = currentDistance - prevDistance;

            float scaleFactor = 1 + deltaDistance * zoomSpeed;
            Vector3 targetScale = transform.localScale * scaleFactor;

            // Clamp based on initial scale
            targetScale.x = Mathf.Clamp(targetScale.x, initialScale.x * minScaleFactor, initialScale.x * maxScaleFactor);
            targetScale.y = Mathf.Clamp(targetScale.y, initialScale.y * minScaleFactor, initialScale.y * maxScaleFactor);
            targetScale.z = Mathf.Clamp(targetScale.z, initialScale.z * minScaleFactor, initialScale.z * maxScaleFactor);

            transform.localScale = targetScale;
        }
    }
}
