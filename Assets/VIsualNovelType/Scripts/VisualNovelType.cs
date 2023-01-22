using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

[System.Serializable]
public class Dialogue
{
    public Sprite Char;
    public Sprite Mud;
    public string Lines;
    public Sprite TextBorder;
}

public class VisualNovelType : MonoBehaviour
{
    public GameObject BorderChar;
    public GameObject BorderMud;
    public TextMeshProUGUI DialogueBox;
    string dialogueBox;
    public SpriteRenderer Char;
    public SpriteRenderer Mud;
    public SpriteRenderer TextBorder;
     
    public List<Dialogue> DialogueList = new List<Dialogue>();
    int currentDialogue = 1;

   




//Start is called before the first frame update
void Start()
    {
       
    }

   

    

    // Update is called once per frame
    void Update()
    {
        SwapPortrait();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetText();
            TextBorder.sprite = DialogueList[currentDialogue].TextBorder;
            
        }

        /*
        dialogueBox = DialogueBox.text;
        if (dialogueBox.Contains(""))
            {
            TextBorder.gameObject.GetComponent<Image>().enabled = false;
        }
            else
            {
            TextBorder.enabled = true;
        }
        */
        
    }


    public void SwapPortrait()
    {
            dialogueBox = "";
            dialogueBox = DialogueBox.text;
            if (dialogueBox.Contains("Charmander:"))
            {
                this.BorderChar.SetActive(true);
                this.BorderMud.SetActive(false);
  
        }
            else if (dialogueBox.Contains("Mudkip:"))
            { 
                this.BorderChar.SetActive(false);
                this.BorderMud.SetActive(true);
            
        }
            else
            {
                this.BorderChar.SetActive(false);
                this.BorderMud.SetActive(false);
            
            }
    }

    public void SetText()
    {
        dialogueBox = DialogueList[currentDialogue].Lines;
        Char.sprite = DialogueList[currentDialogue].Char;
        Mud.sprite = DialogueList[currentDialogue].Mud;
        TextBorder.sprite = DialogueList[currentDialogue].TextBorder;
        DialogueBox.text = dialogueBox.Replace("Mudkip:", "<color=#00FFFF>Mudkip:</color>").Replace("Charmander:", "<color=yellow>Charmander:</color>");
        currentDialogue++;
        
        
    }
}


