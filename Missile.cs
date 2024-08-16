using UnityEngine;

public class GuidedMissile : MonoBehaviour
{
    public Transform target;  // Füzenin hedefi
    public float speed = 10f;  // Füzenin hareket hızı
    public float rotateSpeed = 200f;  // Füzenin dönüş hızı
    public float homingSensitivity = 1f;  // Füzenin hedefe yönelme hassasiyeti

    void Update()
    {
        if (target == null) return;

        // Hedef ile füze arasındaki yön vektörü
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        // Füzenin hedefe doğru dönmesini sağla
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);

        // Füzenin ileri doğru hareket etmesini sağla
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // Füzenin hedefe veya başka bir şeye çarpması durumunda çalışacak kodlar
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            // Hedefi vurduğunda yapılacaklar
            Destroy(target.gameObject);  // Hedefi yok et
            Time.timeScale = 0;  // Oyunu durdur
        }

        // Füze herhangi bir şeye çarptığında yok et
        Destroy(gameObject);
    }
}
