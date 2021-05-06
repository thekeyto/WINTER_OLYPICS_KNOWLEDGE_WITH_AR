using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour
{

    public Vector3 force;
    public float gravity;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(force);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity, 0));
    }
}
