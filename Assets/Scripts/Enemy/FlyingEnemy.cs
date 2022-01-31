using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEnemy : MonoBehaviour
{

    public Transform organ;
    protected Transform player;
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

    public UnityEvent onShoot;

    public virtual void Awake()
    {
        damages = 1f;
        speed = 5f;
        attackRange = 2f;
        followUntil = 1f;
        visionDistance = 20f;
        fireRate = 1f;
        shotDuration = new WaitForSeconds(0.5f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SetPlayer(Transform p)
    {
        player = p;
    }

    public virtual void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserAudio = GetComponent<AudioSource>();

        laserLine.widthMultiplier = 0.1f;
    }

    public virtual void Update()
    {
        bool p = PlayerInSight();

        if(organ && !p && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            organ.GetComponent<OrganHealth>().GetHit(damages);
            //Debug.Log("ORGAN LIFE : " + organ.GetComponent<OrganHealth>().currentLife);
        }

        else if (p)
        {
            Move();
            Attack();
        }
    }

    private bool PlayerInSight()
    {
        if(player == null)
        {
            Debug.Log("PLAYER NULL");
            return false;
        }

        targetDirection = Vector3.Normalize(player.position - transform.position);
        targetDistance = Vector3.Distance(player.position, transform.position);

        //LayerMask elayer = ~LayerMask.NameToLayer("Enemy"); // Maybe usefull later

        RaycastHit hit;
        if(Physics.Raycast(transform.position, targetDirection, out hit, visionDistance))
        {
            if(hit.transform.tag == "Player")
            {
                // Debug.Log("PLAYER FOUND");
                return true;
            }
        }
        // Debug.Log("PLAYER NOT FOUND");

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

            player.GetComponent<PlayerHealth>().GetHit(damages);

            laserLine.SetPosition (0, transform.position);
            laserLine.SetPosition (1, player.position);
            onShoot?.Invoke();

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
