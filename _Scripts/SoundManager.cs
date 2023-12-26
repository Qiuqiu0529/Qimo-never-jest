using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource audioSource,audioSource1;
    [SerializeField]
    private AudioClip clickAudio, bagAudio,lockdigitSound,doorOpen,pushBox,keySound,shuitong,bird,putong;

    private void Awake()
    {
        instance = this;

        //DontDestroyOnLoad(gameObject);
    }
    public void BirdAudio()
    {
        audioSource1.clip = bird;
        audioSource1.Play();
    }
    public void PutongAudio()
    {
        audioSource1.clip = putong;
        audioSource1.Play();
    }
    public void ClickAudio()
    {
        audioSource.clip = clickAudio;
        audioSource.Play();
    }
    public void ShuitongAudio()
    {
        audioSource1.clip = shuitong;
        audioSource1.Play();
    }
    public void KeyAudio()
    {
        audioSource1.clip = keySound;
        audioSource1.Play();
    }
    public void PushBoxAudio()
    {
        audioSource.clip = pushBox;
        audioSource.Play();
    }
    public void DoorOpenAudio()
    {
        audioSource.clip = doorOpen;
        audioSource.Play();
    }
    public void DigitAudio()
    {
        audioSource.clip = lockdigitSound;
        audioSource.Play();
    }
    public void BagAudio()
    {
        audioSource.clip = bagAudio;
        audioSource.Play();
    }

}
