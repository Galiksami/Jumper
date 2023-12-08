using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public BoxCollider triggerCollider;
    public GameObject bookObject; 
    public float proximityDistance = 3f;

    public bool loadNextSceneEnabled = true; 

    [SerializeField]
    private string nextSceneName; 

    private bool hasCutscenePlayed = false;

    private void Start()
    {
        
        if (cutsceneDirector == null)
        {
            cutsceneDirector = GetComponent<PlayableDirector>();
        }

        if (cutsceneDirector == null)
        {
            Debug.LogError("Cutscene director not assigned or found. Attach a PlayableDirector component or assign it in the inspector.");
        }

        
        if (bookObject != null)
        {
            bookObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Book GameObject not assigned. Attach a GameObject or assign it in the inspector.");
        }

        
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped += OnCutsceneFinished;
        }
    }

    private void OnDestroy()
    {
        
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped -= OnCutsceneFinished;
        }
    }

    private void Update()
    {
        
        if (IsPlayerNearCollider() && !hasCutscenePlayed)
        {
            
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                
                PlayCutscene();

                
                if (bookObject != null)
                {
                    bookObject.SetActive(true);
                }

                
            }
        }
    }

    private bool IsPlayerNearCollider()
    {
        
        if (triggerCollider != null)
        {
            
            float distance = Vector3.Distance(transform.position, triggerCollider.bounds.center);

           
            return distance <= proximityDistance;
        }
        else
        {
            Debug.LogError("Trigger collider not assigned. Attach a BoxCollider component or assign it in the inspector.");
            return false;
        }
    }

    private void PlayCutscene()
    {
        
        if (cutsceneDirector != null)
        {
            // Play the cutscene.
            cutsceneDirector.Play();
            hasCutscenePlayed = true; 
        }
        else
        {
            Debug.LogError("Cutscene director not assigned. Attach a PlayableDirector component or assign it in the inspector.");
        }
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        
        if (loadNextSceneEnabled)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            
        }
    }
}


