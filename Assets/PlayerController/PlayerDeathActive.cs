using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathActive : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject playerHead;
    [SerializeField]
    private Transform chullachaqui;
    [SerializeField]
    private AudioSource playerDeathSound;

    private AudioSource audio_;
    //private AudioSource audio_risa;

    private bool death;
    // Start is called before the first frame update
    void Start()
    {
        audio_ = GetComponent<AudioSource>();
        //audio_risa = playerDeathSound.GetComponent<AudioSource>();
        death = false;
    }

    private void Update()
    {
        if (death) {
            Vector3 pos = cam.WorldToViewportPoint(chullachaqui.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            chullachaqui.position = cam.ViewportToWorldPoint(pos);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            if (death == false)
            {
                if (playerHead.GetComponent<BoxCollider>() == null)
                {
                    playerHead.AddComponent<BoxCollider>();
                }
                if (playerHead.GetComponent<Rigidbody>() == null)
                {
                    Rigidbody playerHeadRigidBody = playerHead.AddComponent<Rigidbody>(); // Add the rigidbody.
                    playerHeadRigidBody.mass = 2;
                }

                death = true;
                audio_.Play();
                playerDeathSound.Play();
                Debug.Log("colision");
            }
            
        }
    }
}
