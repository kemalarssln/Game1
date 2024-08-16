using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawnScript : MonoBehaviour
{
    public float maxTime = 1f; // Kaç saniyede bir pipe spawnlanacağını belirliyor
    private float timer = 0f;
    public GameObject pipePrefab; // Pipe prefab'i (obje) buraya atanacak
    public float yukseklik = 2f; // Random yüksekliği belirlemek için kullanılacak

    void Start()
    {
        SpawnPipe(); // İlk pipe'ı spawnla
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            SpawnPipe(); // Yeni bir pipe spawnla
            timer = 0f; // Timer'ı sıfırla
        }
    }

    void SpawnPipe()
    {
        // Kameranın alt sınırını hesapla
        float cameraBottomLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        
        // Rastgele Y pozisyonunu belirle
        float randomY = Random.Range(-yukseklik, yukseklik);
        
        // Rastgele Y pozisyonunu kamera alt sınırının üstünde tutmak için sınırla
        randomY = Mathf.Max(randomY, cameraBottomLimit);

        // Yeni pipe oluştur ve pozisyonunu ayarla
        GameObject newPipe = Instantiate(pipePrefab);
        newPipe.transform.position = transform.position + new Vector3(0, randomY, 0);

        // Pipe'ı 15 saniye sonra yok et
        Destroy(newPipe, 10f);
    }
}
