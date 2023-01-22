using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWallCheck : MonoBehaviour
{
    public QuestWall QuestWallObj;

    bool isInteractable;
    GameObject PlayerObj;

    private void Update()
    {
        if (isInteractable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                QuestWallObj.CheckRequirements(PlayerObj);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isInteractable = true;
            PlayerObj = collision.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            isInteractable = false;
        }
    }
}
