using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Scripts_Player.Instance.gameObject)
            Scripts_Player.Instance.GetDamage();
    }
}
