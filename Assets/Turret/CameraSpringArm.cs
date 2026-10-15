using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CameraSpringArm : MonoBehaviour
{
    public float distance;
    Vector3 hitPosition;
    public GameObject mainCam;
    InputSystem_Actions input;
    public float rotateSpeed;

    private void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, -transform.forward * distance, Color.red);

        if (Physics.Raycast(transform.position, -transform.forward, out hit, distance))
        {
            Debug.DrawRay(transform.position, -transform.forward * hit.distance, Color.green);
            hitPosition = hit.point;
        }
        else
        {
            hitPosition = transform.position - transform.forward * distance;
        }

        mainCam.transform.position = hitPosition;

        transform.Rotate(input.Player.Move.ReadValue<Vector2>().y * rotateSpeed * Time.deltaTime, -input.Player.Move.ReadValue<Vector2>().x * rotateSpeed * Time.deltaTime, 0);
    }
}
