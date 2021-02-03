using Unity.Mathematics;
using UnityEngine;

public class Testgun : MonoBehaviour
{

    //public Sprite artwork;
    public GameObject bullet;
    public GameObject player;
    

    public float timeBetweenBullets;
    
    // Start is called before the first frame update
    void Start()
    {
        timeBetweenBullets = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position, quaternion.identity);
        }
    }
}
