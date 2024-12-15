using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Scripts_Player.Instance.gameObject)
        {
            if (Scripts_Player.Instance._keys == Scripts_Player.Instance._keyStart)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
