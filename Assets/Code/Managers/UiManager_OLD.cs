using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Interaction options (talk, use and inventory)
    private GameObject interactionPanel;
    private Text txtInteractionName, txtInteractionTalk, txtInteractionUse, txtInteractionInventory;
    private Image iconInteractionTalk, iconInteractionUse, iconInteractionInventory;

    // Speech UI
    [SerializeField]private GameObject dialoguePanel;
    [SerializeField] private Text txtCharName, txtSpeech;
    [SerializeField] private Image imgCharLeft, imgCharCenter, imgCharRight;

    private StateManager stateManager;


    // Start is called before the first frame update
    void Start()
    {
        GetComponents();
        
    }

    private void GetComponents()
    {
        stateManager = FindObjectOfType<StateManager>();


        // Interaction Panel...
        interactionPanel = GameObject.FindGameObjectWithTag("InteractionPanel");
        txtInteractionName = interactionPanel.transform.GetChild(0).GetComponent<Text>();
        txtInteractionTalk = interactionPanel.transform.GetChild(1).GetComponent<Text>();
        iconInteractionTalk = interactionPanel.transform.GetChild(2).GetComponent<Image>();
        txtInteractionUse = interactionPanel.transform.GetChild(3).GetComponent<Text>();
        iconInteractionUse = interactionPanel.transform.GetChild(4).GetComponent<Image>();
        txtInteractionInventory = interactionPanel.transform.GetChild(5).GetComponent<Text>();
        iconInteractionInventory = interactionPanel.transform.GetChild(6).GetComponent<Image>();

        // Dialogue Panel
        dialoguePanel = GameObject.FindGameObjectWithTag("DialoguePanel");
        txtCharName = dialoguePanel.transform.GetChild(0).GetComponent<Text>();
        txtSpeech = dialoguePanel.transform.GetChild(1).GetComponent<Text>();
        imgCharLeft = dialoguePanel.transform.GetChild(2).GetComponent<Image>();
        imgCharRight = dialoguePanel.transform.GetChild(3).GetComponent<Image>();
        imgCharCenter = dialoguePanel.transform.GetChild(4).GetComponent<Image>();

    }


    private void ShowInteractionPanel(string name, bool command)
    {
        interactionPanel.GetComponent<Image>().enabled = command;
        iconInteractionTalk.enabled = command;
        iconInteractionUse.enabled = command;
        iconInteractionInventory.enabled = command;

        txtInteractionName.text = command ? name : " "; // NAME VALUE MUST BE DYNAMIC!
        txtInteractionTalk.text = command ? "[E]" : " ";
        txtInteractionUse.text = command ? "[R]" : " ";
        txtInteractionInventory.text = command ? "[T]" : " ";
    }

    public void OnInteractionShown(string name, bool command)
    {
        ShowInteractionPanel(name, command);
    }

    // -------------------------------------------------------------------------------

    public void OnDialogueCalled(string name, bool command)
    {
        ShowDialogue(command);
    }

    public void ShowDialogue(bool command)
    {
        stateManager.SetState(EStates.DIALOGUE);


        // mock
        string characterName = "Cassandra";
        string speechLine = "Uma porta... está trancada";

        txtCharName.text = characterName;
        txtSpeech.text = speechLine;

        dialoguePanel.GetComponent<Image>().enabled = command;


    }


}
