using UnityEngine;

public class RiverFlow : MonoBehaviour
{
    public float flowSpeed = 15f; 

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("LogPrefub")) 
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.right * flowSpeed, ForceMode.Acceleration); 
            }
        }
    }
}
