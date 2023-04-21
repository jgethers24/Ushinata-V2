using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBox : MonoBehaviour
{
    bool choiceSelected = false;

    [SerializeField] ChoiceText choiceTextPrefab;
    public IEnumerator ShowChoices(List<string> choices)
    {
        choiceSelected = false;
        gameObject.SetActive(true);

        foreach (Transform child in transform)
            Destroy(child.gameObject);
        foreach(var choice in choices)
        {
            var choiceTextObj = Instantiate(choiceTextPrefab, transform);
            choiceTextObj.Textfield.text = choice;
        }

        yield return new WaitUntil(() => choiceSelected = true);
    }
}
