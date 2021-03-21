using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    private int rInt;
    private bool stop = false;

    private GameObject enemy;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(initialWait());
        enemy = GameObject.Find("echoarmodels");
        enemy.tag = "enemy";
        enemy.SetActive(false);
        // Runs wait()
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {

        // Waits for x seconds
        while (!stop)
        {
            // Random integer between 10 and 30
            rInt = Random.Range(5, 10);
            yield return new WaitForSeconds((float)rInt);
            GameObject x = Instantiate(enemy, this.gameObject.transform);
            
            x.SetActive(true);
            Rigidbody rb = x.AddComponent(typeof(Rigidbody)) as Rigidbody;
            BoxCollider bc = x.AddComponent(typeof(BoxCollider)) as BoxCollider;
            bc.isTrigger = true;
            bc.size = new Vector3(5f, 10f, 5f);
            enemy e = x.AddComponent(typeof(enemy)) as enemy;
            x.layer = 10;

        }
    }

    IEnumerator initialWait()
    {
        yield return new WaitForSeconds(2f);
    }
}