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
    
    public static Vector3 RandomSpawnObjects()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = 0;
        
        Vector3 vector = new Vector3(x, y, z);

        return vector;
    }
    
    //GetLimits() Can be refactor for better performance
    public static float ScreenRatio, Width, Height;
    public static Vector3 GetLimits()
    {
        float spawnDistance = 10f; 
        Vector3 randomPos = Random.insideUnitCircle.normalized * spawnDistance;
        randomPos.z = 0f;

        ScreenRatio = (float)Screen.width / (float)Screen.height;
        Width = Camera.main.orthographicSize * ScreenRatio;
        Height = Camera.main.orthographicSize;
        
        randomPos.x = Mathf.Clamp(randomPos.x, -Width, Width);
        randomPos.y = Mathf.Clamp(randomPos.y, -Height, Height);

        return randomPos;
    }
}
