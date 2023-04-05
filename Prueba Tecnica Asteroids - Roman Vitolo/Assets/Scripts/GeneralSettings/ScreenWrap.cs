using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        CheckScreenWrap();
    }

    private void CheckScreenWrap()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0f || viewportPosition.x > 1f)
        {
            viewportPosition.x = 1f - viewportPosition.x;
        }

        if (viewportPosition.y < 0f || viewportPosition.y > 1f)
        {
            viewportPosition.y = 1f - viewportPosition.y;
        }

        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
    }
}
