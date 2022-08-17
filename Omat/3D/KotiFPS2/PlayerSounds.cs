using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSound();
    }

    private void PlayerSound()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
