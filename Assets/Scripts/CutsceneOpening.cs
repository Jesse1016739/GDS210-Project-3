using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOpening : MonoBehaviour
{
    GameObject spawner;
    GameObject playerControl;
    GameObject canvasLink;



    void Awake()
    {
        //turns off enemy spawns and player controls before everything starts
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        spawner.SetActive(false);
        playerControl = GameObject.FindGameObjectWithTag("Player");
        playerControl.GetComponent<PlayerController>().enabled = false;
        canvasLink = GameObject.FindGameObjectWithTag("Cutscene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this starts off player controls and all with R1/Fire
        if (Input.GetButtonDown("Fire1"))
        {
            spawner.SetActive(true);
            playerControl.GetComponent<PlayerController>().enabled = true;
            canvasLink.SetActive(false);
        }
    }

}
