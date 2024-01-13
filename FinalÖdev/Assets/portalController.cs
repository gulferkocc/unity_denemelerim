using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{
    public bool isOrange;
    public float distance = 0.2f;
    public Transform destination;

    void Start()
    {
        if (isOrange == false)
        {
            // FindGameObjectsWithTag fonksiyonu bir dizi döndürür
            GameObject[] teleport2Objects = GameObject.FindGameObjectsWithTag("Teleport2");
            
            // Dizide en az bir nesne varsa
            if (teleport2Objects.Length > 0)
            {
                // Dizinin ilk öğesinin Transform bileşenini al
                destination = teleport2Objects[0].GetComponent<Transform>();
            }
        }
        else
        {
            GameObject[] teleportObjects = GameObject.FindGameObjectsWithTag("Teleport");

            if (teleportObjects.Length > 0)
            {
                destination = teleportObjects[0].GetComponent<Transform>();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance)
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
