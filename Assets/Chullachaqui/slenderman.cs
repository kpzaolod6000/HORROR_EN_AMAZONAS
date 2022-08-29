using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slenderman : MonoBehaviour {

    
    public Transform objetivo;
    float pantalla = 0.8f;
    Rigidbody rb;
    public bool Visible = false;
    public float velocidad = 10;
    public float punto;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Esvisible();
        transform.LookAt(objetivo.position);
        if (!Visible)
        {
           // rb.MovePosition(transform.position + transform.forward * Time.deltaTime*velocidad);
            transform.position = transform.position + transform.forward * velocidad * Time.deltaTime;
        }
	}

    void Esvisible()
    {
        Vector3 delante = objetivo.forward;
        Vector3 otro = (this.transform.position - objetivo.position).normalized;
        punto = Vector3.Dot(delante, otro);
        if (punto > pantalla)
        {
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }
    
}
