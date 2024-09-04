using UnityEngine;

public class PersistentCamera : MonoBehaviour
{
    private static PersistentCamera instance;

    void Awake()
    {
        // Permite singleton da câmera com filtros        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
