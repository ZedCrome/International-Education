using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletPaperHealth : MonoBehaviour
{
    public int m_currentHealth = 6;
    public List<GameObject> m_toiletPaper;
    private GameObject m_toBeDeleted;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && m_currentHealth >= 0)
        {
            m_currentHealth--;
            Debug.Log(m_currentHealth);
            m_toBeDeleted = m_toiletPaper[Random.Range(0, m_toiletPaper.Count)];
            m_toiletPaper.Remove(m_toBeDeleted);
            Destroy(m_toBeDeleted);
            if (m_currentHealth <= 0)
                NextScene();
        }
    }
    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    
}
