using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public Transform player;


    protected float speed;
    protected float fireRate;
    protected float attackRange;
    protected float followUntil;
    protected float visionDistance;
    protected WaitForSeconds shotDuration;
    protected AudioSource laserAudio;
    protected LineRenderer laserLine; 
    protected Vector3 targetDirection;
    protected float targetDistance;
    protected float nextFire; 
    protected float damages;
    protected LayerMask enemyLayer;

    public virtual void Awake()
    {
        damages = 1f;
        speed = 5f;
        attackRange = 10f;
        followUntil = 7f;
        visionDistance = 40f;
        fireRate = 1f;
        shotDuration = new WaitForSeconds(0.5f);
    }

    public virtual void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();

        laserLine.widthMultiplier = 0.1f;
    }

    public virtual void Update()
    {
        if(PlayerInSight())
        {
            Move();
            Attack();
        }
    }

    private bool PlayerInSight()
    {
        if(player == null)
        {
            return false;
        }

        targetDirection = Vector3.Normalize(player.position - transform.position);
        targetDistance = Vector3.Distance(player.position, transform.position);

        //int layers = LayerMask.NameToLayer("Enemy"); // Maybe usefull later

        RaycastHit hit;
        if(Physics.Raycast(transform.position, targetDirection, out hit, visionDistance))
        {
            if(hit.transform.name == "Player")
            {
                return true;
            }
        }

        return false;
    }



    public virtual void Move()
    {
        if(targetDistance > followUntil)
        {
            transform.position = transform.position + targetDirection * speed * Time.deltaTime;
        }
    }

    public virtual void Attack()
    {
        if(targetDistance <= attackRange && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine (Shot());

            laserLine.SetPosition (0, transform.position);
            laserLine.SetPosition (1, player.position);
        }

    }

    // public void GetHit(float damages)
    // {
    //     currentLife -= damages;
    // }

    private IEnumerator Shot()
    {
        //laserAudio.Play ();

        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }

}
