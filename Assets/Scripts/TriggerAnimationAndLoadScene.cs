using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerAnimationAndLoadScene : MonoBehaviour
{
    public string nextSceneName = "YourNextSceneName";
    public Animator yourAnimator;
    public float interactionDistance = 3f; 

    private bool isPlayerNear = false;

    void Update()
    {
        
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            
            if (yourAnimator != null)
            {
                yourAnimator.SetTrigger("YourAnimationTrigger");

                
                Invoke("LoadNextScene", yourAnimator.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

    private void LoadNextScene()
    {
        
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
