using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Scripts_Player.Instance.gameObject && Scripts_Player.Instance._hitpoints < 4)
        {
            Scripts_Player.Instance.GetHeal();
            Destroy(this.gameObject);
        }
    }
}
