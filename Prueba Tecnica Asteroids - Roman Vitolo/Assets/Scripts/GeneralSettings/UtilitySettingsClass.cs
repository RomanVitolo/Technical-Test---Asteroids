using UnityEngine;

public class UtilitySettingsClass : MonoBehaviour
{
    public static float minX, maxX, minY, maxY;
    public static void ScreenLimits()
    {
        Camera mainCamera = Camera.main;
        
        if (mainCamera == null) { return; }
        
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        var position = mainCamera.transform.position;
        minX = position.x - cameraWidth / 2f;
        maxX = position.x + cameraWidth / 2f;
        minY = position.y - cameraHeight / 2f;
        maxY = position.y + cameraHeight / 2f;
    }

    public static float randomX, randomY;
    public static void GetLimits()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        
        randomX = Random.Range(0f, screenWidth);
        randomY = screenHeight;
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
    }
}
