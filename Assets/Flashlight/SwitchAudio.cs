using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    
    private AudioSource audio_;
    private InputManagerPlayer inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManagerPlayer.Instance;
        audio_ = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (inputManager.PlayerEnableFlashLight())
        {
            audio_.volume = 1f;
            audio_.Play();
        }


    }
}
