using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecking : MonoBehaviour
{
    public EnemyCheck enemyCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyCheck.enemyPassed = true;
            Debug.Log("Enemy Passed");
        }

        else if (other.tag == "Enemy" && enemyCheck.enemyPassed == true)
        {
            return;
        }
    }
}
