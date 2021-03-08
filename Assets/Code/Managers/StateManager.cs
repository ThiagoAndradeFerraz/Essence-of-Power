using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]private EStates currentState;

    public EStates GetCurrentState()
    {
        return currentState;
    }

    public void SetState(EStates state)
    {
        currentState = state;
        Debug.Log(currentState);
    }
}
