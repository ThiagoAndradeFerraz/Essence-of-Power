using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMng : MonoBehaviour
{
    [Header("Main containers")]
    [SerializeField] private Transform dialogueContainer;

    [Header("Dialogue related")]
    [SerializeField] private Transform charactersPanel, dialoguePanel;
    [SerializeField] private Image imgCharacterLeft, imgCharacterRight, imgCharacterCenter;
    [SerializeField] private Text characterName, characterSpeech;

    [Header("Interaction options")]
    [SerializeField] private Transform interactionPanel;
    [SerializeField] private Text txtNameIntr, txtOptions;

    private void GetUiElements()
    {
        #region MAIN CONTAINERS
        // Dialogue...
        dialogueContainer = GameObject.FindGameObjectWithTag("DialogueUIContainer").GetComponent<Transform>();
        #endregion

        #region DIALOGUE COMPONENTS
        // === CHARACTERS IMAGES ===
        charactersPanel = dialogueContainer.GetChild(0).GetComponent<Transform>();
        imgCharacterLeft = charactersPanel.GetChild(0).GetComponent<Image>();
        imgCharacterRight = charactersPanel.GetChild(1).GetComponent<Image>();
        imgCharacterCenter = charactersPanel.GetChild(2).GetComponent<Image>();
        //----------------------------------------
        // === DIALOGUE TEXT ===
        dialoguePanel = dialogueContainer.GetChild(1).GetComponent<Transform>();
        characterName = dialoguePanel.GetChild(0).GetComponent<Text>();
        characterSpeech = dialoguePanel.GetChild(1).GetComponent<Text>();
        #endregion

        #region INTERACTION OPTIONS WHEN PLAYER IS CLOSE OF OBJECT
        interactionPanel = GameObject.FindGameObjectWithTag("InteractionPanel").GetComponent<Transform>();
        txtNameIntr = interactionPanel.GetChild(0).GetComponent<Text>();
        txtOptions = interactionPanel.GetChild(1).GetComponent<Text>();
        #endregion

    }

    // Start is called before the first frame update
    void Start()
    {
        GetUiElements();
    }

    #region DIALOGUE UI

    public void TurnOnOffDialogueUI(bool command)
    {
        imgCharacterLeft.enabled = command;
        imgCharacterRight.enabled = command;
        imgCharacterCenter.enabled = command;
        dialoguePanel.GetComponent<Image>().enabled = command;
        
        if(command == false)
        {
            characterName.text = " ";
            characterSpeech.text = " ";
        }
    }

    public void ShowDialogueUI(Dialogue dialogue)
    {
        characterName.text = dialogue.talkingChar;
        characterSpeech.text = dialogue.line;

        string facesPath = "Images/Faces/";

        if (dialogue.leftChar != null)
        {
            string path = facesPath + dialogue.leftChar;
            imgCharacterLeft.sprite = Resources.Load<Sprite>(path);
        }

        if (dialogue.rightChar != null)
        {
            string path = facesPath + dialogue.rightChar;
            imgCharacterRight.sprite = Resources.Load<Sprite>(path);
        }
    }

    #endregion

    #region OPTIONS THAT APPEAR WHEN PLAYER IS CLOSE OF OBJECT

    public void ShowInteractionOptions(bool command)
    {
        interactionPanel.GetComponent<Image>().enabled = command;
        txtNameIntr.enabled = command;
        txtOptions.enabled = command;
    } 

    #endregion


}
