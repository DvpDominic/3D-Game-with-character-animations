using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour {

    float speed = 4;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;

    public float rotX;
    public float rotY;
    public float rotZ;

    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Rigidbody rb;
    Animator anim;
    AudioSource footstepAS;

    // Use this for initialization
    void Start() {

        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        footstepAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {


        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("walk");
            footstepAS.Play();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("run");
            footstepAS.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += Vector3.forward * Time.deltaTime * 2 * speed;
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("pistolhold");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetTrigger("pet");
        }
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Mouse1) || Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetTrigger("stop");
            footstepAS.Stop();
        }

        /*rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);

            moveDir.y -= gravity * Time.deltaTime;*/


        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;

        if ( rotX < -90)
        {
            rotX = -90;
        } 
        else if (rotX > 90)
        {
            rotX = 90;
        }

        transform.rotation = Quaternion.Euler(0, rotY, 0);
        //gameObject.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }
    }
