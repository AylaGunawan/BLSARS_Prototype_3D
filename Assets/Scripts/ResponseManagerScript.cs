using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseManagerScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("MacBook Pro Microphone", true, 10, 44100);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
