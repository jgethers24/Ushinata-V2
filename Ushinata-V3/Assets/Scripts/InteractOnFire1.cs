using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractOnFire1 : MonoBehaviour {

    enum InteractionState
    {
        None,
        Idle,
        Talking
    }

    public Image ConversationPanel;
    public Text ConversationSpeaker;
    public Text ConversationText;

    InteractionState CurrentInteractionState;
    int CurrentTalkerId;

    public DialogueDatabase MyTalkerDatabase;

	// Use this for initialization
	void Start () {
        CurrentInteractionState = InteractionState.None;
        CurrentTalkerId = 0;
        SetInteractionState(InteractionState.Idle);
    }
	
	// Update is called once per frame
	void Update () {
        if(CurrentInteractionState == InteractionState.Idle)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                TalkyPerson[] talkyPerson = FindObjectsOfType<TalkyPerson>();
                for (int i = 0; i < talkyPerson.Length; ++i)
                {
                    if (talkyPerson[i].TalkInteractionCollider.bounds.Contains(transform.position))
                    {
                        CurrentTalkerId = talkyPerson[i].TalkerId;
                        SetInteractionState(InteractionState.Talking);
                        break;
                    }
                }
            }
        }
        else if(CurrentInteractionState == InteractionState.Talking)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SetInteractionState(InteractionState.Idle);
            }
        }
	}

    void SetInteractionState(InteractionState newState)
    {
        if(newState != CurrentInteractionState)
        {
            CurrentInteractionState = newState;
            switch(CurrentInteractionState)
            {
                case InteractionState.Idle:
                    ConversationPanel.enabled = false;
                    ConversationSpeaker.enabled = false;
                    ConversationText.enabled = false;
                    break;
                case InteractionState.Talking:
                    ConversationPanel.enabled = true;
                    ConversationSpeaker.enabled = true;
                    ConversationText.enabled = true;

                    ConversationSpeaker.text = MyTalkerDatabase.GetTalkerName(CurrentTalkerId);
                    ConversationText.text = MyTalkerDatabase.GetTalkerText(CurrentTalkerId);
                    break;
            }
        }
    }

    public bool IsInteracting()
    {
        return CurrentInteractionState == InteractionState.Talking;
    }
}
