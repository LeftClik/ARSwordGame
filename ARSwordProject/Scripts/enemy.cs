using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Rigidbody rb;
    public float speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("AR Camera").transform;
        rb = this.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
        transform.LookAt(player);
        Vector3 targetAngle = transform.eulerAngles + 180f * Vector3.up;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngle, Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}