using UnityEngine;
using TMPro; // Important: This script uses TextMeshPro
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    [Header("UI Settings")]
    public TextMeshProUGUI textElement; // Drag your UI text here
    public string message = "Hello fellow Witch Apprentice! This is the tutorial! Why don't you use your mouse and click the star?";
    public float typingSpeed = 0.05f;

    [Header("Trigger Settings")]
    public bool triggerOnlyOnce = true;
    private bool hasTriggered = false;

    private void Start()
    {
        // Clear the text at the start of the game
        if (textElement != null) textElement.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (triggerOnlyOnce) hasTriggered = true;

            // Stop any current typing and start the new message
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
    }

    // This is for 2D games
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (triggerOnlyOnce) hasTriggered = true;
            StopAllCoroutines();
            StartCoroutine(TypeText());
        }
    }

    IEnumerator TypeText()
    {
        textElement.text = ""; // Clear current text

        foreach (char letter in message.ToCharArray())
        {
            textElement.text += letter; // Add one letter at a time
            yield return new WaitForSeconds(typingSpeed); // Wait before next letter
        }
    }
}