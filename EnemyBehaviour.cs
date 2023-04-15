using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject goal;
    private bool IsPlayer = false;
    private Vector3 now, before;
    private NavMeshAgent agent;
    private Animator animator;
    private ResourseManager RM;
    public AudioSource audio;
    private float HP;

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player");
        RM = FindObjectOfType<ResourseManager>();
        HP = RM.EnemyHP;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        now = transform.position;
        before = transform.position;
    }

    void Update()
    {
        if (IsPlayer && (Vector3.Distance(transform.position, goal.transform.position) > 2f))
        {
            agent.destination = goal.transform.position;
            animator.SetBool("IsHit", false);
        }
        else if (IsPlayer)
        {
            animator.SetBool("IsHit", true);
        }

        now = transform.position;
        if (now != before)
        {
            animator.SetBool("IsMoving", true);
            audio.UnPause();
        }
        else
        {
            animator.SetBool("IsMoving", false);
            audio.Pause();
        }
        before = now;
    }

    void HitPlayer()
    {
        goal.GetComponent<Move>().LossHP(RM.EnemyDamage);
    }

    public void LossHP(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsPlayer = true;
            agent.destination = goal.transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsPlayer = false;
        }
    }
}
