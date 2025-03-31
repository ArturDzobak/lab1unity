using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab; 
    public Transform spawnPoint; 
    public float spawnForce = 5f; 

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
