using UnityEngine;

public class CycloidMovement : MonoBehaviour
{
    public float a = 2f, speed = 2f;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += speed * Time.deltaTime;
        float x = a * (time - Mathf.Sin(time));
        float y = a * (1 - Mathf.Cos(time));
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
