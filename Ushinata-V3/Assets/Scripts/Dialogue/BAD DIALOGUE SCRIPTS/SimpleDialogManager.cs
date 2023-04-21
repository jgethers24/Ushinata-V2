using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleDialogManager : MonoBehaviour
{
    [SerializeField] public GameObject dialogBox;
    [SerializeField] ChoiceBox choiceBox;
    [SerializeField]
    private TMP_Text dialogText;
    [SerializeField] int lettersPerSecond;

    //public event System.Action OnShowDialog;
    //public event System.Action OnCloseDialog;

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public static SimpleDialogManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog,List<string>choices = null)
    {
        //OnShowDialog?.Invoke();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
        
        if (choices != null && choices.Count > 1)
        {
            yield return choiceBox.ShowChoices(choices);
        }
    }
    public void HandleUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        //{
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine = 0;
                dialogBox.SetActive(false);
                //OnCloseDialog?.Invoke();
            }
        //}
    }
    public void HideDialog(Dialog dialog)
    {
        currentLine = 0;
        dialogBox.SetActive(false);
        //StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line)
    {
        //isTyping = true;
        dialogText.text = "";
        foreach ( var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        //isTyping = false;
    }

}
