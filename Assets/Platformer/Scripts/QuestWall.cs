using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWall : MonoBehaviour
{
    public int CoinRequirements;
    public bool isButtonRequired;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isButtonRequired)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                CheckRequirements(collision.gameObject);
            }
        }
    }

    public void CheckRequirements(GameObject obj)
    {
        if (obj.GetComponent<PlayerStats>().Score >= CoinRequirements)
        {
            Destroy(gameObject);
        }
    }
}
