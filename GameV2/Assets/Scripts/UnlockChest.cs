using UnityEngine;
using UnityEngine.Events;

public class UnlockChest : MonoBehaviour
{
    public string tag;
    public UnityEvent chestUnlocked; //A Unity Event we can assign actions to in the Editor

    private void OnTriggerEnter(Collider other) //If something touches the Chest
    {
        if(other.CompareTag(tag)) //if that thing is tagged as "Key"
        {
            chestUnlocked.Invoke(); //Run all actions in our chestUnlocked Unity Event
        }
    }
}
