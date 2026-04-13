using UnityEngine;
using TMPro;
using System.Collections;

public class Triggertext : MonoBehaviour
{
    public TextMeshProUGUI textElement;

    [Header("List of Messages")]
    [TextArea(3, 10)]
    public string[] messages; // inspector to make list for multiple messages 

    public float typingSpeed = 0.05f;
    public float delayBetweenMessages = 1f; // how long for next msg

    private Coroutine sequenceCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (sequenceCoroutine != null) StopCoroutine(sequenceCoroutine);
            sequenceCoroutine = StartCoroutine(PlayMessageSequence());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (sequenceCoroutine != null) StopCoroutine(sequenceCoroutine);
            textElement.text = "";
        }
    }

    IEnumerator PlayMessageSequence()
    {
        // Loop through every message in your list
        foreach (string sentence in messages)
        {
            textElement.text = ""; // Clear for new sentence

            // Type the sentence letter by letter
            foreach (char letter in sentence.ToCharArray())
            {
                textElement.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            // Wait after the sentence is finished before starting the next one
            yield return new WaitForSeconds(delayBetweenMessages);
        }
    }
}