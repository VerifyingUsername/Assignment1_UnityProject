using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Audio Clips
    [SerializeField]
    private AudioClip[] sandClips;

    [SerializeField]
    private AudioClip[] woodClips;

    [SerializeField]
    private AudioClip[] grassClips;

    [SerializeField]
    private AudioClip[] waterClips;

    [SerializeField]
    private AudioClip[] metalClips;

    [SerializeField]
    private AudioClip[] concreteClips;


    // Audiosource component
    private AudioSource audioSource;


    // Bool floors
    private bool onWater = false;
    private bool onSand = false;
    private bool onGrass = false;
    private bool onWood = false;
    private bool onMetal = false;
    private bool onConcrete = false;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip;

        // Plays random range from the floor arrays length
        if (onWater == true)
        {
            clip = waterClips[Random.Range(0, waterClips.Length)];
        }

        else if (onSand == true)
        {
            clip = sandClips[Random.Range(0, sandClips.Length)];
        }

        else if (onGrass == true)
        {
            clip = grassClips[Random.Range(0, grassClips.Length)];
        }

        else if (onWood == true)
        {
            clip = woodClips[Random.Range(0, woodClips.Length)];
        }

        else if (onMetal == true)
        {
            clip = metalClips[Random.Range(0, metalClips.Length)];
        }

        else if (onConcrete == true)
        {
            clip = concreteClips[Random.Range(0, concreteClips.Length)];
        }
        else
        {
            // If none of the floor types match, exit the method
            return;
        }

        // Random pitch and volume
        float randomPitch = Random.Range(0.5f, 1.5f); 
        float randomVolume = Random.Range(0.5f, 1.0f);

        // Apply random pitch and volume to the AudioSource
        audioSource.pitch = randomPitch;
        audioSource.volume = randomVolume;

        // Play the audio clip
        audioSource.PlayOneShot(clip);
      
    }



    // Checks for trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            onWater = true;
        }

        if (other.gameObject.tag == "Sand")
        {
            onSand = true;
        }

        if (other.gameObject.tag == "Grass")
        {
            onGrass = true;
        }

        if (other.gameObject.tag == "Wood")
        {
            onWood = true;
        }

        if (other.gameObject.tag == "Metal")
        {
            onMetal = true;
        }

        if (other.gameObject.tag == "Ground")
        {
            onConcrete = true;
        }

        Step();
    }

    // Exits the trigger whenever its false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            onWater = false;
        }

        if (other.gameObject.tag == "Sand")
        {
            onSand = false;
        }

        if (other.gameObject.tag == "Grass")
        {
            onGrass = false;
        }

        if (other.gameObject.tag == "Wood")
        {
            onWood = false;
        }

        if (other.gameObject.tag == "Metal")
        {
            onMetal = false;
        }

        if (other.gameObject.tag == "Ground")
        {
            onConcrete = false;
        }

        Step();
    }
}
