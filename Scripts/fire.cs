using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform camera;
    public void Fire()
    {
        GameObject tempbullet = Instantiate(bullet) as GameObject;
        tempbullet.transform.SetParent(camera);
        tempbullet.transform.position = new Vector3(0, 0, 0);
    }
}
