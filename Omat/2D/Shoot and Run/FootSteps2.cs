using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]// tämä vaaditaan, jotta voidaan käyttää Audiosource,  tämä tuo myös Audiosourcen inspektoriin automaattisesti koodin mukana

public class FootSteps2 : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] footsteps;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetKeyDown(KeyCode.Space)) PlayFootstep();
    }

    public void PlayFootstep()
    {
        AudioClip clip = footsteps[Random.Range(0, footsteps.Length)];
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        float volume = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(clip, 1f);
    }
}
