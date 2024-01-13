using UnityEngine;

public class OtomatikGezgin : MonoBehaviour
{
    public float moveSpeed = 1f; // Hızı ayarlamak için bir değişken
    public float moveDistance = 30f; // Hareket edilecek mesafe
    private float startingPositionX; // Başlangıç pozisyonunu kaydet

    void Start()
    {
        startingPositionX = transform.position.x; // Başlangıç pozisyonunu kaydet
    }

    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        float newX = startingPositionX + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector2(newX, transform.position.y);
    }
}
