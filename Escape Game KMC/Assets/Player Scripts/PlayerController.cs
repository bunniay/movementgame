using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Glide Settings")]
    public string targetTag = "Interactable";  
    public float maxInteractDistance = 5f;       
    public float glideDuration = 1.2f;           
    public LayerMask raycastMask = ~0;         

    [Header("Camera Settings")]
    public Camera playerCamera;               

    private Rigidbody rb;
    private bool isGliding = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        if (isGliding) return;

        if (Input.GetMouseButtonDown(0))
            TryGlide();
    }

    void TryGlide()
    {
        Ray ray = new Ray(playerCamera.transform.position,
                          playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxInteractDistance, raycastMask))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                StartCoroutine(GlideTo(hit.collider.transform.position));
            }
        }
    }

    IEnumerator GlideTo(Vector3 targetPos)
    {
        isGliding = true;

        rb.isKinematic = true;

        Vector3 startPos = transform.position;
        float elapsed = 0f;

        while (elapsed < glideDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / glideDuration); // 부드러운 가속/감속
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }

        transform.position = targetPos;

        rb.isKinematic = false;
        rb.linearVelocity = Vector3.zero;

        isGliding = false;
    }
}