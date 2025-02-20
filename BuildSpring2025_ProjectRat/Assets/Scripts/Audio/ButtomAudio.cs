using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomAudio : MonoBehaviour
{
    public AudioClip Scream;
    public void PressButtom() {
        AudioManager.Instance.PlayAudioClip(GetComponent<AudioSource>(), Scream);
    }
}
