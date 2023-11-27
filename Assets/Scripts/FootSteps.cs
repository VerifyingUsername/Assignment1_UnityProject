using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
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

    private AudioSource audioSource;

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

        if (onWater == true)
        {
            clip = waterClips[Random.Range(0, waterClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        else if (onSand == true)
        {
            clip = sandClips[Random.Range(0, sandClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        else if (onGrass == true)
        {
            clip = grassClips[Random.Range(0, grassClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        else if (onWood == true)
        {
            clip = woodClips[Random.Range(0, woodClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        else if (onMetal == true)
        {
            clip = metalClips[Random.Range(0, metalClips.Length)];
            audioSource.PlayOneShot(clip);
        }

        else if (onConcrete == true)
        {
            clip = concreteClips[Random.Range(0, concreteClips.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

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
