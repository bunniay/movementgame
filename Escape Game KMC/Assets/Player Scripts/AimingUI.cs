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
        if (player == null || player.playerCamera == null) return;

        Ray ray = new Ray(player.playerCamera.transform.position,
                        player.playerCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * player.maxInteractDistance, Color.red);

        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo,
                                    player.maxInteractDistance,
                                    player.raycastMask);

        bool isInteractable = hit && hitInfo.collider.CompareTag(player.targetTag);
        bool isGoal         = hit && hitInfo.collider.CompareTag("GoalPoint");

        if (isGoal)
            crosshairImage.color = Color.green;       
        else if (isInteractable)
            crosshairImage.color = highlightColor;   
        else
            crosshairImage.color = normalColor;     
    }
}