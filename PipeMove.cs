using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed;
    public float minSize = 0.10f; // Minimum Y ölçeği
    public float maxSize = 0.5f;  // Maksimum Y ölçeği
    public float ratio = 10f;     // Oran (pozitif)
    public float offset = -4.74f; // Negatif offset (Y pozisyonunu daha negatif yapar)

    void Start()
    {
        // Y scale'i minSize ile maxSize arasında rastgele belirle
        float randomYScale = Random.Range(minSize, maxSize);

        // Objeyi yeniden ölçeklendir
        transform.localScale = new Vector3(transform.localScale.x, randomYScale, transform.localScale.z);

        // Orana göre Y pozisyonunu hesapla: Y scale arttıkça Y pozisyonu daha negatif olur
        float calculatedYPosition = -randomYScale * ratio + offset;

        // Pozisyonu güncelle
        transform.position = new Vector3(transform.position.x, calculatedYPosition, transform.position.z);
    }

    void Update()
    {
        // Objeyi sola doğru hareket ettir
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
