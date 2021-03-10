using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject player;
    [SerializeField] protected float minimumDistance;

    [SerializeField] protected string nameOfIt;
    [SerializeField] protected int stateOfIt; // Used to control the story flux

    private bool isClose = false;
    private bool wasClose = false;

    [SerializeField] protected UIMng uiManager;

    protected void FindComponents()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uiManager = GameObject.FindGameObjectWithTag("Managers").GetComponent<Transform>().GetChild(2).GetComponent<UIMng>();
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        FindComponents();
    }

    protected void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractionTalk();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            InteractionUse();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            InteractionInventory();
        }
    }

    protected void DetectPlayer()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < minimumDistance)
        {
            wasClose = isClose;
            isClose = true;
            if (isClose == true && wasClose == false)
            {
                uiManager.ShowInteractionOptions(true);
            }
            CheckInput();
        }
        else
        {
            wasClose = isClose;
            isClose = false;
            if (!isClose && wasClose)
            {
                uiManager.ShowInteractionOptions(false);
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        DetectPlayer();
    }

    // Input actions...
    protected abstract void InteractionTalk();
    protected abstract void InteractionUse();
    protected abstract void InteractionInventory();
}
