using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float forwardSpeed;
    [SerializeField] bool enableMovment;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        MovePlayerWhenInputIsPressed();
    }

    void MovePlayerWhenInputIsPressed()
    {
        if(Input.GetKey(KeyCode.E) && enableMovment)
        {
            MovePlayer();
        }
        
    }
    void MovePlayer()
    {
        rb.velocity = (transform.forward * forwardSpeed);
    }

    public void EnableMovment(bool _enabled)
    {
        enableMovment = _enabled;
    }
}
