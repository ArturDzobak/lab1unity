using UnityEngine;

public class TargetSelector : MonoBehaviour
{
    public Camera cam;
    public PlayerController player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // À Ã
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Food") || hit.collider.CompareTag("Exit"))
                {
                    player.MoveTo(hit.point);
                }
            }
        }
    }
}
