using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public float maxTime = 1f; // Kaç saniyede bir pipe spawnlanacağını belirliyor
    private float timer = 0f;
    public GameObject pipePrefab; // Pipe prefab'i (obje) buraya atanacak
    public float yukseklik = 2f; // Random yüksekliği belirlemek için kullanılacak
    public Transform planeTransform; // Planenin Transform bileşeni buraya atanacak

    void Start()
    {
        spawnPipe(); // İlk pipe'ı spawnla
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            spawnPipe(); // Yeni bir pipe spawnla
            timer = 0f; // Timer'ı sıfırla
        }
    }

    void spawnPipe()
    {
        // Planenin alt sınırını belirle (planeTransform'un y pozisyonu)
        float planeBottomLimit = planeTransform.position.y;

        // Rastgele Y pozisyonunu belirle
        float randomY = Random.Range(0,0);
        
        // Rastgele Y pozisyonunu plane alt sınırının üstünde tutmak için sınırla
        randomY = Mathf.Max(randomY, planeBottomLimit);

        // Yeni pipe oluştur ve pozisyonunu ayarla
        GameObject newPipe = Instantiate(pipePrefab);
        newPipe.transform.position = transform.position + new Vector3(0, randomY, 0);

        // Pipe'ı 15 saniye sonra yok et
        Destroy(newPipe, 15f);
    }
}
