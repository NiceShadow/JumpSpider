using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Transform player;
    Animator animator;

    [SerializeField]
    bool playerInSight;

    RaycastHit hit;
    Ray ray;

    float timeSinceLastAttack;
    public float timeToAttack = 3;
    public float detectionRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, player.position - transform.position);

        if (Physics.Raycast(ray, out hit, detectionRange) == true)
        {
            if (hit.collider.tag == "Player")
            {
                playerInSight = true;
                Debug.DrawRay(transform.position, (player.position - transform.position).normalized * detectionRange, Color.green);
            }
        }
        else
        {
            playerInSight = false;
            Debug.DrawRay(transform.position, (player.position - transform.position).normalized * detectionRange, Color.red);
        }

        if (playerInSight)
        {
            timeSinceLastAttack += Time.deltaTime;
            if (timeSinceLastAttack >= timeToAttack)
            {
                Attack();
            }
        }
        else
        {
            timeSinceLastAttack -= Time.deltaTime;
            if (timeSinceLastAttack < 0) timeSinceLastAttack = 0;
        }

    }

 public void Attack()
    {
        timeSinceLastAttack = 0;
        animator.SetTrigger("attack");
    }

}
