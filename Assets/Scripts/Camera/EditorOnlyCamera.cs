using UnityEngine;

public class EditorOnlyCamera : MonoBehaviour
{
    void Awake()
    {
        // Não faz diferença no editor, apenas após a build.
        #if !UNITY_EDITOR
            Destroy(gameObject);
        #endif
    }
}
