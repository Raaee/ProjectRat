using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeoBA_Audio : MonoBehaviour
{
    private AudioClip PigeonBA;
    

    private void Start()
    {
        
    }

    public void PlayAudio()
    {
        AudioManager.Instance.PlayAudioClip(GetComponent<AudioSource>(), PigeonBA);
    }
}
