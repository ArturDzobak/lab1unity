using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 offsetA, offsetB; 
    public float speed = 2f;

    private Vector3 startPosition;
    private bool movingToB = true;

    void Start()
    {
        startPosition = transform.position; 
    }

    void Update()
    {
        Vector3 targetPosition = startPosition + (movingToB ? offsetB : offsetA);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            movingToB = !movingToB;
    }
}
