using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public Vector3 pointA, pointB;
    public float speed = 2f;
    private bool movingToB = true;

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, movingToB ? pointB : pointA, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movingToB ? pointB : pointA) < 0.1f)
            movingToB = !movingToB;
    }
}
