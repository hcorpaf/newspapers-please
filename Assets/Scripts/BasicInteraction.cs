using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInteraction : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip [] audios;
    public float pitchMin = 0.9f;
    public float pitchMax = 1.2f;
    public float volMin = 0.9f;
    public float volMax = 1.2f;
    public GameObject particles;




    void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
    
    void PlaySound()
        {
            AudioClip clip = audios[Random.Range(0, audios.Length)];
            float volume = Random.Range(volMin,volMax);
            audioSource.pitch = Random.Range(pitchMin,pitchMax);
            audioSource.PlayOneShot(clip, volume);
        }


    void OnMouseDown(){
        PlaySound();
        if(particles != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(particles, mousePos, Quaternion.identity);
            
        }

    }

}
