using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Create Enemy Data", order = 0)]
public class EnemyData : ScriptableObject
{
    [Header("EnemyStats")]
    public int m_Health;
    public float m_Speed;

    [Header("Target")]
    public GameObject m_Target;
}



