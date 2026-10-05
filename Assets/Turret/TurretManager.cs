using UnityEngine;
using UnityEngine.InputSystem;

public class TurretManager : MonoBehaviour
{
    public GameObject turretBase;
    public GameObject turretTorso;
    public float rotateSpeed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        turretBase.transform.Rotate(0, Mouse.current.delta.ReadValue().x * rotateSpeed, 0);
        turretTorso.transform.Rotate(-Mouse.current.delta.ReadValue().y * rotateSpeed, 0, 0);
    }
}
