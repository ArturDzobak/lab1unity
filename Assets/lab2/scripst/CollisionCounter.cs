using UnityEngine;

public class CollisionCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.QuantityOfCollision();
        }
    }

}
