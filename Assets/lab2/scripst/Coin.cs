using UnityEngine;
using System;
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}
