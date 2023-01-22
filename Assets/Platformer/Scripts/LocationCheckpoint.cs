using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCheckpoint : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            PlayerPrefs.SetFloat("PlayerX", 178.75f);
            PlayerPrefs.SetFloat("PlayerY", -10.988f);
            PlayerPrefs.SetFloat("Playerz", 0f);
            PlayerPrefs.SetInt("PlayerCoins", collision.gameObject.GetComponent<PlayerStats>().Score);
        }
    }
}
