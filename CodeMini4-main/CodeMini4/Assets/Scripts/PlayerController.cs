using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float Maxjump = 1f;

    public Animator PlayerAni;
    public Rigidbody PlayerRb;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        JumpPlayer();
    }

    void Movement()
    {
        //movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            PlayerAni.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            PlayerAni.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerAni.SetBool("Running", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            PlayerAni.SetBool("Running", true);
        }
        //idle
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            PlayerAni.SetBool("Running", false);
        }
    }
    void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Maxjump == 0)
        {
            PlayerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            PlayerAni.SetTrigger("Jumping");
            Maxjump++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Maxjump = 0;
        }
    }
}
