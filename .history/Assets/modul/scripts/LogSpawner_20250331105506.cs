using UnityEngine;
using System;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab; 
    public Transform spawnPoint; 
    public float spawnForce = 5f;

    void Start()
    {
        Vector3 a = new Vector3(1, 5, 4);
        Vector3 b = new Vector3(2, -2, -6);

        float dotProductAB = Vector3.Dot(a, b);

        float dotProductBB = Vector3.Dot(b, b);

        Vector3 projection = (dotProductAB / dotProductBB) * b;

        Debug.Log("������� a �� b: " + projection);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnLog();
        }
    }

    void SpawnLog()
    {
        GameObject log = Instantiate(logPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = log.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * spawnForce, ForceMode.Impulse);
        }
    }
}
