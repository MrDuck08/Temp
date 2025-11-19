using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{

    [SerializeField] List<GameObject> dialogeBundle = new List<GameObject>();
    List<GameObject> dialogueInBundle = new List<GameObject>();

    int onWhatDialogueBundle = 0;
    int onWhatDialogue = 0;

    bool inDialogue = false;

    #region Text

    TextMeshProUGUI text;
    string textToWrite;
    int characterIndex;
    [SerializeField] float timePerCharacter;
    float timer;

    bool writeText = false;

    #endregion

    PlayerScript playerScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        onWhatDialogueBundle = 0;

        playerScript = FindObjectOfType<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {

        if (writeText)
        {

            timer -= Time.deltaTime;

            if (timer <= 0)
            {

                timer += timePerCharacter;
                characterIndex++;
                text.text = textToWrite.Substring(0, characterIndex);

                if (characterIndex >= textToWrite.Length)
                {

                    writeText = false;

                }

            }



        }


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter)) || Input.GetMouseButtonDown(0))
        {
            if (inDialogue)
            {
                NextDialogue();
            }

        }

    }

    public void StartDialogue()
    {

        foreach (Transform child in dialogeBundle[onWhatDialogueBundle].transform)
        {

            dialogueInBundle.Add(child.gameObject);
            child.gameObject.SetActive(false);

        }

        playerScript.DoNothingTOF(true);

        inDialogue = true;

        onWhatDialogueBundle++;

        dialogueInBundle[onWhatDialogue].SetActive(true); // Start Dialogue
        WhatTextToWrite(dialogueInBundle[onWhatDialogue].GetComponentInChildren<TextMeshProUGUI>());

    }

    void NextDialogue()
    {

        dialogueInBundle[onWhatDialogue].SetActive(false);

        onWhatDialogue++;

        if (onWhatDialogue >= dialogueInBundle.Count)
        {
            playerScript.DoNothingTOF(false);
            inDialogue = false;
            return;

        }

        dialogueInBundle[onWhatDialogue].SetActive(true);
        WhatTextToWrite(dialogueInBundle[onWhatDialogue].GetComponentInChildren<TextMeshProUGUI>());

    }


    void WhatTextToWrite(TextMeshProUGUI textToChange)
    {

        // Resetar Texten till när den ska skriva ny text + Lägger in vilken text

        text = textToChange;
        textToWrite = textToChange.text;
        textToChange.text = "";
        characterIndex = 0;

        writeText = true;

    }
}
