using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingPlungers : MonoBehaviour
{
    public GameObject FirePoint;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
            
    }

    private void Shoot()
    {
        GameObject m_plungerAmmo = ObjectPool.instance.SpawnPool("PlungerAmmo", FirePoint.transform.position, FirePoint.transform.rotation);
        if(m_plungerAmmo != null)
        {
            m_plungerAmmo.SetActive(true);
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

    }
}
