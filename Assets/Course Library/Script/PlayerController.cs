using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }
}
