using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody rb;
    private Vector3 leftStickInput;
    private Vector3 rightStickInput;

    public GameObject bulletSpawn;
    public GameObject bullet;
    public float fireRate;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerInput();

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, bulletSpawn.transform);
            Debug.Log("Fired");
        }
    }

    private void GetPlayerInput()
    {
        leftStickInput = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        //Debug.Log(leftStickInput);
        rightStickInput = new Vector3(Input.GetAxis("R_Horizontal"), 0, Input.GetAxis("R_Vertical"));
    }

    private void FixedUpdate()
    {
        Vector3 curMovement = leftStickInput * playerSpeed * Time.deltaTime;
        rb.velocity = curMovement;
        //Debug.Log(rb.velocity);
        //Debug.Log(curMovement);

        if(rightStickInput.magnitude > 0f)
        {
            Vector3 curRotation = Vector3.left * rightStickInput.x + Vector3.forward * rightStickInput.z;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.up);

            rb.MoveRotation(playerRotation);
        }
    }
    

}
