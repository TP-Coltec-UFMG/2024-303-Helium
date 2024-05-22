using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int targetFrameRate = 30;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }
}
