using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject destroyed;
    public float timer;
    public float timerCooldown;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerCooldown && timerCooldown != 0)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;

            timerCooldown = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CapsuleCollider>())
        {
            Instantiate(destroyed, transform.position, transform.rotation);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            timerCooldown = timer + 3;
        }
    }
}
