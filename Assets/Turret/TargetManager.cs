using TMPro;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject destroyed;
    public float timer;
    public float timerCooldown;
    public ScoreManager scoreCounter;

    public int scoreVal = 100;
    public bool moving = false;
    public float moveSpeed = 1;
    public bool isObstacle = false;
    bool invertDir = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerCooldown && timerCooldown != 0)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;

            timerCooldown = 0;
        }

        if (moving)
        {
            if (invertDir)
            {
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            if (transform.position.x >= 7.5) invertDir = true;
            else if (transform.position.x <= -4.5) invertDir = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CapsuleCollider>())
        {
            if (!isObstacle)
            {
                Instantiate(destroyed, transform.position, transform.rotation);
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                timerCooldown = timer + 3;
            }
            
            scoreCounter.UpdateScore(scoreVal);
        }

        
    }
}
