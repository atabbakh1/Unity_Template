using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public AudioSource audioToPlay;

    private void OnTriggerEnter(Collider other)
    {
        audioToPlay.Play();
    }
}
