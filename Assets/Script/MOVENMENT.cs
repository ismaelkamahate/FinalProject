using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MOVENMENT : MonoBehaviour
{
    Animator SIR;

    private Rigidbody rb;
    public Vector3 fwd, bwd, lft, rgt;
    private int count;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start() //like setup
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        SIR = GetComponent<Animator>();
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SIR.SetInteger("D", 0);
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += lft;
            SIR.SetInteger("D", 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += rgt;
            SIR.SetInteger("D", 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}