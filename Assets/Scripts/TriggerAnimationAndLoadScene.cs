using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAnimationAndLoadScene : MonoBehaviour
{
    public string nextSceneName = "YourNextSceneName";
    public Animator yourAnimator;
    public float interactionDistance = 3f; // Adjust the distance as needed

    private bool isPlayerNear = false;

    void Update()
    {
        // Check if the player is near the collider and pressed the "E" key
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the animation
            if (yourAnimator != null)
            {
                yourAnimator.SetTrigger("YourAnimationTrigger");

                // Invoke the method to load the next scene after the animation duration
                Invoke("LoadNextScene", yourAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
