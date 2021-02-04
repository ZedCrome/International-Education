using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingPlungers : MonoBehaviour
{
    public GameObject FirePoint;
    private bool m_canShoot = true;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_canShoot == true)
        {
            Shoot();
            m_canShoot = false;
            Invoke("canShoot", 0.5f);
        }
            
    }

    private void canShoot()
    {
        m_canShoot = true;
    }

    private void Shoot()
    {
        GameObject m_plungerAmmo = ObjectPool.instance.SpawnPool("PlungerAmmo", FirePoint.transform.position, FirePoint.transform.rotation);
        if(m_plungerAmmo != null)
        {
            m_plungerAmmo.SetActive(true);
        }
        
    }
}
