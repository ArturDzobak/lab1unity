using UnityEngine;

public class Pastka : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
            GameManager.Instance.QuantityOfCollision();
        }
    }
}
