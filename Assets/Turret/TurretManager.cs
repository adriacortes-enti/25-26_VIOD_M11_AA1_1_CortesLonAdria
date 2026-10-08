using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TurretManager : MonoBehaviour
{
    public GameObject turretBase;
    public GameObject turretTorso;
    public GameObject turretShooter;
    public float rotateSpeed = 0.1f;
    public GameObject bullet;
    public float bulletSpeed = 1000;
    InputSystem_Actions input;
    GameObject shotBullet;

    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Update()
    {
        turretBase.transform.Rotate(0, Mouse.current.delta.ReadValue().x * rotateSpeed, 0);
        turretTorso.transform.Rotate(-Mouse.current.delta.ReadValue().y * rotateSpeed, 0, 0);

        if (input.Player.Attack.WasPressedThisFrame())
        {
            shotBullet = Instantiate(bullet, turretShooter.transform.position, turretShooter.transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            shotBullet.GetComponent<Rigidbody>().AddForce(turretShooter.transform.forward * bulletSpeed);
        }
    }
}
