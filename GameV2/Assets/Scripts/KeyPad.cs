using UnityEngine;
using UnityEngine.UI;
public class KeyPad : MonoBehaviour
{
    private static string correctCode = "3803"; //Customize to your code and align with the clue in the scene
    private static string currentEntry = ""; //Tracks what we have been inputting

    public string thisKey = ""; //A value you can assign in the inspector to match the model

    public AudioSource audioSource; //The KeyPad AudioSource to play sound
    public AudioClip errorSound; //Resetting the pin error sound
    public AudioClip successSound;
    public AudioClip hitKey;
    public AudioClip clearSound;
    public Animator animator; //Animator reference!
    public GameObject textbox;

    private void OnTriggerEnter(Collider other) //If a Key is touched
    {
        if (other.CompareTag("Player")) //If the player was what touched the key
        {
            
            currentEntry += thisKey; //Add this key's value to our curret Entry 
            if (thisKey == "Clear")
            {
                currentEntry = "";
                audioSource.PlayOneShot(clearSound);
                textbox.GetComponent<Text>().text = "0";
            }
            else
            {
                if (currentEntry.Length > 3) //If our entry is more than 3 characters
                {
                    if (currentEntry == correctCode) //If our entry matches the correct Code
                    {
                        animator.SetTrigger("Unlock"); // Direct link to the animator which is set on a grandparent.
                        audioSource.PlayOneShot(successSound); // Play sound when correct code is entered. 
                        currentEntry = ""; //Reset current Entry to nothing
                        textbox.GetComponent<Text>().text = "0";
                    }
                    else //If we didn't enter the right code
                    {
                        currentEntry = ""; //Reset current Entry to nothing
                        audioSource.PlayOneShot(errorSound); //Play sound when incorrect code is entered 
                        textbox.GetComponent<Text>().text = "0";
                    }
                }
                else //Our current Entry is not more than 3 characters in length
                {
                    audioSource.PlayOneShot(hitKey);
                    textbox.GetComponent<Text>().text = currentEntry;
                }
            }
        }
        

    }
}