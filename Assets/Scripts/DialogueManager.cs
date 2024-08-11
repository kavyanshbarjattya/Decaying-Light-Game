using System.Collections;
using TMPro;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    [TextArea(10,10)]
    [SerializeField] string dialogue;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] AudioSource audioSource;

    [SerializeField] TextMeshProUGUI buttonText;


    private void Awake()
    {
        dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    private float displayDuration = 30f;

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(DisplayText());
    }

    private IEnumerator DisplayText()
    {
        audioSource.Play();

        string[] words = dialogue.Split(' ');
        float timeBetweenWords = displayDuration / words.Length;

        dialogueText.text = "";

        foreach (string word in words)
        {
            foreach (char letter in word)
            {
                dialogueText.text += letter;
                yield return new WaitForSecondsRealtime((timeBetweenWords / word.Length) / 2); 
            }
            dialogueText.text += " "; 
            yield return new WaitForSecondsRealtime(timeBetweenWords);  
        }
        yield return new WaitForSecondsRealtime(2f);
        buttonText.text = "Next";
    }

    public void SkipPrologue()
    {
        audioSource.Stop();
        StopCoroutine(DisplayText());
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}