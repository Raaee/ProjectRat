using UnityEngine;

public class CameraCollider : MonoBehaviour {
    private void FixedUpdate() {
        Camera cam = GetComponent<Camera>();
        
        float aspect = Screen.width / Screen.height;

        float width = 4.0f * cam.orthographicSize * aspect;
        float height = 2.0f * cam.orthographicSize * 1.2f;
        
        GetComponent<BoxCollider2D>().size = new Vector2(width, height);
    }
}
