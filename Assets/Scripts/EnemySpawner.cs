using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime;
    public float maxMut;
    public float waveRestart;

    public bool maxMet = false;

    public GameObject enemy;

    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());
        spawnTime = Random.Range(2, 6);
    }

    void Update()
    {
        GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemyList.Length;
        //Debug.Log(enemyCount);

        if(enemyCount >= maxMut)
        {
            maxMet = true;
        }

        if (maxMet == true && enemyCount == 0)
        {
            maxMet = false;
            StartCoroutine(Spawning());
        }


    }
    #region Manual Spawning Code
    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //StartCoroutine(BreakInSpawning());
          spawnToggle = true; 
        }

        if (spawnToggle == true)
        {
            StartCoroutine(BreakInSpawning());
        }

    }
    */
    #endregion

    //This is the coroutine started earlier
    IEnumerator Spawning()
    {
        yield return new WaitForSeconds(waveRestart);
        if (maxMet == false)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemy, transform.position, transform.rotation);
            enemyCount += 1;

            if (enemyCount < maxMut)
            {
                StartCoroutine(Spawning());
            }


        }
    }

    

}
