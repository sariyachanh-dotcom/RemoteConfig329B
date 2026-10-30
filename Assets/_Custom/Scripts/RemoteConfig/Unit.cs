using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int lifeTime=10;
    private Transform target;
    private Rigidbody rb;
    public float multiplySpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody>();
        Invoke(nameof(Despawn), lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            rb.AddForce((target.position - transform.position)* multiplySpeed,ForceMode.Acceleration);
            transform.LookAt(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
