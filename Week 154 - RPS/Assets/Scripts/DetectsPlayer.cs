﻿using UnityEngine;

public class DetectsPlayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            Debug.Log("Hit player!");
    }
}
