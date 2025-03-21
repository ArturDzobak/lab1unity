using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public float radius = 5f, speed = 2f, heightSpeed = 1f;
    private float angle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = radius * Mathf.Cos(angle);
        float y = heightSpeed * angle;
        float z = radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, y, z);
    }
}
