using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))] // audiosource tulee suoraan inspectoriin

public class EnemyController : MonoBehaviour
{
    //m‰‰ritell‰‰n mitk‰ toimintoja on
    private AiSpaceState currentState; // AiBaseState perustila
    public readonly EnemyIdleState idleState = new EnemyIdleState(); // voidaan vain lukea
    public readonly EnemyFollowState followState = new EnemyFollowState();
    public readonly AttackState attackState = new AttackState();

    public NavMeshAgent agent;
    public GameObject player;
  
   [SerializeField] private Rigidbody projectile;
   [SerializeField] public Transform firepoint;

    private Animator animator;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;

    private float timer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        ChangeState (idleState); //kun peli alkaa, aloitetaan aina idle animaatiosta
    }

    void Update()
    {
        currentState.Update(this);
        if (Input.GetKeyDown(KeyCode.Space)) EnemyShoot();

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        SetAnimator();      
    }

    public void ChangeState (AiSpaceState state)// valitaan tila/toiminto mik‰ on p‰‰ll‰
    {
        if (currentState != null) currentState.ExitState(this); //jos ei ole null -> ExitState
        currentState = state;
        currentState.EnterState(this);
    }

    public void EnemyShoot()
    {      
       Rigidbody clone = Instantiate(projectile, firepoint.position, Quaternion.identity); //luodaan panos
        clone.AddForce(firepoint.forward * 20, ForceMode.Impulse); //panoksen voima, forward = z-suunta

       
        //Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right, Color.red, 11);
    }

    private void SetAnimator()
    {
        if (agent.velocity.magnitude > 0.1f)  // jos agentin nopeus on > 0.1f
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdling", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdling", true);
        }
    }

    public void SetAudio() //t‰ll‰ voidaan soittaa taulukosta haluttuja ‰‰ni‰ ja timer s‰‰det‰‰n ‰‰nien toisto nopeus
    {     
        if (audioSource.isPlaying == false)
        {
            timer += Time.deltaTime;
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            if (timer > 1)
            {
                audioSource.PlayOneShot(audioSource.clip);
                timer = 0;
            }                     
        }
    }
}
