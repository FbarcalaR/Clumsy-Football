using UnityEngine;

public class CameraCustom : MonoBehaviour
{
    public SpriteRenderer spriteToBeSeen;

    public void Start()
    {
        float widthToBeSeen = spriteToBeSeen.bounds.size.x;
        Camera.main.orthographicSize = widthToBeSeen * Screen.height / Screen.width * 0.5f;
    }
}
