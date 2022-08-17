using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.Audio;

//[System.Serializable]
public class EnemyControllerX : MonoBehaviour
{
    //public string clipname;
    //public AudioClip clip;
    //[Range(0f,1f)] public float volume;
    //[Range(0.1f, 3f)] public float pitch;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private AudioClip alert;

    private float alertTimer;

    //private Animator animator;

    NavMeshAgent navMeshAgent; //vihollisen navmesh
    //private float distanceToTarget = Mathf.Infinity;

    [SerializeField] private Vector3 direction;
    [SerializeField] private float moveSpeed = 2;

    [SerializeField] private float turnSpeed = 6;

    [SerializeField] private GameObject[] path; // luodaan liikkumisalue
    private int pathIndex; // luodaan liikkuminen taulukon mukaan
    private Transform playerTransform; // pelaajan sijainti

    private bool followPlayer;
    [SerializeField] private float followingTime = 10;
    private float timer;

    [SerializeField] private float raycastHeight = -0.4f; //vihollisen raycast korkeus

    void Start()
    {
        //enemyShoot = GetComponent<EnemyShooter>();
        
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Invoke("PlaySound", Random.Range(2f, 4f));
        audioSource = GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        FollowPlayer();

        if (followPlayer == true) //enemy ampuu
        {
            //enemyShoot.enemyShoot = true;
            timer += Time.deltaTime;
        }
        else
        {
            Followpath();
        }
        if (timer > followingTime) //enemy lopettaa ampumisen jos ei voi seurata en‰‰ pelaajaa
        {
            //enemyShoot.enemyShoot = false;
            followPlayer = false;
        }
    }

    private void Followpath() //m‰‰ritell‰‰n vihollisen liikkumarata, mieti miten saisit ett‰ t‰t‰ k‰sky‰ ei luettaisi jatkuvasti. timer systeemi?
    {
        navMeshAgent.SetDestination(path[pathIndex].transform.position);

        if (Vector3.Distance(transform.position, path[pathIndex].transform.position) < 4)
        {
            pathIndex += 1;
            if (pathIndex >= path.Length) pathIndex = 0;
        }
    }

    private void FollowPlayer()
    {
        RaycastHit hitInfo; //vihollinen jahtaa pelaajaa raycasti avulla
        if (Physics.Raycast(transform.position -Vector3.down * raycastHeight, transform.forward, out hitInfo, 20f))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                followPlayer = true; // seurataa pelaaja tietyn ajan (timer)
                timer = 0; //s‰teen osuessa timer nollataan
                Debug.Log("follow player");

                EnemySound();               
            }
        }

        if (followPlayer == true) //jos seurataan pelaajaa
        {
            navMeshAgent.SetDestination(playerTransform.position);

            alertTimer += Time.deltaTime;
                if (alertTimer > 2)
            {
                alertTimer = 0;
                audioSource.PlayOneShot(alert, 1);
            }


            
            return;
        }
    }

    private void EnemySound()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }




    //private void AnimationControls()
    //{
    //    if (rb.velocity.x != 0 && directions.x == 0 && isGrounded == true) isSliding = true;
    //    else isSliding = false;

    //    if (isSliding && isFacingRight) desireAngle = 45;
    //    if (isGrounded && !isFacingRight) desireAngle = -45;

    //    if (isGrounded == false)
    //    {
    //        animator.SetBool("IsIdling", false);
    //        animator.SetBool("IsRunning", false);
    //        animator.SetBool("IsJumping", true);
    //    }

    //    else if (directions.x == 0 && directions.y == 0)
    //    {
    //        animator.SetBool("IsIdling", true);
    //        animator.SetBool("IsRunning", false);
    //        animator.SetBool("IsJumping", false);
    //    }

    //    else
    //    {
    //        animator.SetBool("IsIdling", false);
    //        animator.SetBool("IsRunning", true);
    //        animator.SetBool("IsJumping", false);
    //    }
    //}
}