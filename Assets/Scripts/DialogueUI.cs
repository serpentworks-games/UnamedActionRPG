using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class DialogueUI : DialogueUIBehaviour
{
    public GameObject dialogueContainer;
    public TextMeshProUGUI lineText;
    public GameObject continuePrompt;
    [Tooltip("How quickly to show the text, in sec/char")]
    public float textSpeed = 0.025f;
    public List<Button> optionButtons;

    [HideInInspector]
    public bool isActive;

    OptionChooser SetSelectedOption;

    private void Awake()
    {
        if (dialogueContainer != null)
        {
            dialogueContainer.SetActive(false);
        }

        lineText.gameObject.SetActive(false);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }

        if (continuePrompt != null)
        {
            continuePrompt.SetActive(false);
        }
    }

    public override IEnumerator RunLine(Line line)
    {
        isActive = true;
        // Show the text
        lineText.gameObject.SetActive(true);

        if (textSpeed > 0.0f)
        {
            // Display the line one character at a time
            var stringBuilder = new StringBuilder();

            foreach (char c in line.text)
            {
                stringBuilder.Append(c);
                lineText.text = stringBuilder.ToString();
                yield return new WaitForSeconds(textSpeed);
            }
        }
        else
        {
            // Display the line immediately if textSpeed == 0
            lineText.text = line.text;
        }

        // Show the 'press any key' prompt when done, if we have one
        if (continuePrompt != null)
            continuePrompt.SetActive(true);

        // Wait for any user input
        while (Input.anyKeyDown == false)
        {
            yield return null;
        }

        // Hide the text and prompt
        lineText.gameObject.SetActive(false);


        if (continuePrompt != null)
            continuePrompt.SetActive(false);
    }

    public override IEnumerator DialogueComplete()
    {
        Debug.Log("Complete!");
        isActive = false;
        // Hide the dialogue interface.
        if (dialogueContainer != null)
            dialogueContainer.SetActive(false);

        yield break;
    }

    public override IEnumerator DialogueStarted()
    {
        Debug.Log("Dialogue starting!");

        // Enable the dialogue controls.
        if (dialogueContainer != null)
            dialogueContainer.SetActive(true);

        yield break;
    }

    public override IEnumerator NodeComplete(string nextNode)
    {
        return base.NodeComplete(nextNode);
    }

    public override IEnumerator RunCommand(Command command)
    {
        // "Perform" the command
        Debug.Log("Command: " + command.text);

        yield break;
    }

    public override IEnumerator RunOptions(Options optionsCollection, OptionChooser optionChooser)
    {
        // Do a little bit of safety checking
        if (optionsCollection.options.Count > optionButtons.Count)
        {
            Debug.LogWarning("There are more options to present than there are" +
                             "buttons to present them in. This will cause problems.");
        }

        // Display each option in a button, and make it visible
        int i = 0;
        foreach (var optionString in optionsCollection.options)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = optionString;
            i++;
        }

        // Record that we're using it
        SetSelectedOption = optionChooser;

        // Wait until the chooser has been used and then removed (see SetOption below)
        while (SetSelectedOption != null)
        {
            yield return null;
        }

        // Hide all the buttons
        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    public void SetOption(int selectedOption)
    {

        // Call the delegate to tell the dialogue system that we've
        // selected an option.
        SetSelectedOption(selectedOption);

        // Now remove the delegate so that the loop in RunOptions will exit
        SetSelectedOption = null;
    }

}
