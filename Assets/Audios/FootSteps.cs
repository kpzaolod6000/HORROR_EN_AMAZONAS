using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private CharacterController cc;
    private AudioSource audio_;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        audio_ = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (cc.isGrounded == true && cc.velocity.magnitude > 0.0f && audio_.isPlaying == false)
        {
            audio_.volume = Random.Range(0.4f, 0.7f);
            //audio_.pitch = Random.Range(0.0f, 1.1f);
            audio_.Play();
        }


    }
}
