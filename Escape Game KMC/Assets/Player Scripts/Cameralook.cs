using UnityEngine;
using UnityEngine.InputSystem;

public class Cameralook : MonoBehaviour
{
    [Header("sensitivity")]
    public float sensitivityX = 2f;
    public float sensitivityY = 2f;

    [Header("clamp")]
    public float minY = -80f;
    public float maxY = 80f;

    public Transform playerBody;  

    private float rotationX = 0f;  

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Mouse.current.delta.x.ReadValue() * sensitivityX;
        float mouseY = Mouse.current.delta.y.ReadValue() * sensitivityY;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
