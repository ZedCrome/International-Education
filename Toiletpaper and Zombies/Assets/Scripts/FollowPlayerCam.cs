using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{
    public Transform m_targetToFollow;

    [Header("Clamp Positions")]
    public float m_xValue;
    public float m_yValue;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(m_targetToFollow.position.x, -m_xValue, m_xValue),
            Mathf.Clamp(m_targetToFollow.position.y, -m_yValue, m_yValue),
            transform.position.z);
            
    }
}
