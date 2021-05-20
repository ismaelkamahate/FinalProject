using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumps : MonoBehaviour
{
    public float jumph;
    public float jumpforce;
    private Vector3 jump;
    private Rigidbody rigg;

    private bool isgrounded; //new

    void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rigg.AddForce(jump * jumpforce, ForceMode.Impulse);
            isgrounded = false;
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "floor")
            isgrounded = true;
    }
}
