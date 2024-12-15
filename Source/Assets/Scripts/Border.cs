using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Scripts_Player.Instance.gameObject)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else if (collision.gameObject.tag == "Box")
            Destroy(collision.gameObject);
    }
}