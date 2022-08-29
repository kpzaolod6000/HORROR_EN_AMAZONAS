using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSendero : MonoBehaviour
{
    [SerializeField]
    private GameObject Chullachaqui;
    
    [SerializeField]
    private GameObject Player;

    private AudioSource audio_;

    private AILocomotion scriptsIALoc;

    public static bool activeIA = false;

    private void Start()
    {
        scriptsIALoc = Chullachaqui.GetComponent<AILocomotion>();
        audio_ = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Chullachaqui.activeSelf == false)
        {
            Chullachaqui.SetActive(true);
            audio_.Play();
            scriptsIALoc.enabled = true;
            activeIA = true;
        }
        if(Chullachaqui.activeSelf == true)
        {
            scriptsIALoc.enabled = true;
        }
    }
}
