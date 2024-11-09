using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip jump;
    public AudioClip destroyObject;
    public AudioClip destroyPlayer;

    private void Start() {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip); 
    }

}
