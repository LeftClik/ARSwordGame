using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieRelocater : MonoBehaviour
{

    [SerializeField]
    GameObject zombie;


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        zombie.transform.SetParent(GameObject.Find("zombie").transform, transform.parent);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
