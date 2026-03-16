using UnityEngine;
using UnityEngine.UI;

public class AimingUI : MonoBehaviour
{
    public PlayerController player;
    public Image crosshairImage;
    public Color normalColor = Color.white;
    public Color highlightColor = Color.yellow;

    void Update()
    {

        Ray ray = new Ray(player.playerCamera.transform.position,
                          player.playerCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * player.maxInteractDistance,
                      Color.red); 

        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo,
                                   player.maxInteractDistance,
                                   player.raycastMask);

        if (hit)
        {
            Debug.Log("Raycast hit: " + hitInfo.collider.name
                      + " / Tag: " + hitInfo.collider.tag);
        }

        bool isTarget = hit && hitInfo.collider.CompareTag(player.targetTag);
        crosshairImage.color = isTarget ? highlightColor : normalColor;
    }
}