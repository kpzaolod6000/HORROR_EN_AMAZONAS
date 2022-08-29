using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAnimationAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    private Transform Chullachaqui;

    [SerializeField]
    private GameObject ChullachaquiObject;

    [SerializeField]
    private AudioSource audioGlitch;

    private Animator animFocus;
    

    private float distance;
    private float angle;
    public static float timeNotLooking = 0;
    private bool isLooking;

    void Start()
    {
        animFocus = GetComponent<Animator>();
        isLooking = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Chullachaqui.position, transform.position);
        angle = Vector3.Angle(transform.forward, Chullachaqui.position - transform.position);
        if (angle < 70 && distance < 35 && ChullachaquiObject.activeSelf == true)
        {
            animFocus.SetBool("LookAt", true);
            isLooking = true;
            timeNotLooking = 0;
        }
        else
        {
            animFocus.SetBool("LookAt", false);
            isLooking = false;
            timeNotLooking += Time.deltaTime;
        }

        if(isLooking == true && audioGlitch.isPlaying == false)
        {
            audioGlitch.Play();
        }
        else if (isLooking == false && audioGlitch.isPlaying == true)
        {
            audioGlitch.Stop();
        }
    }


}
