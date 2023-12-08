using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutsceneDirector;
    public BoxCollider triggerCollider;
    public GameObject bookObject; // Reference to the book GameObject.
    public float proximityDistance = 3f;

    public bool loadNextSceneEnabled = true; // Option to enable or disable loading the next scene.

    [SerializeField]
    private string nextSceneName; // Serialized field for the next scene name.

    private bool hasCutscenePlayed = false;

    private void Start()
    {
        // Ensure the cutscene director is not null before using it.
        if (cutsceneDirector == null)
        {
            cutsceneDirector = GetComponent<PlayableDirector>();
        }

        if (cutsceneDirector == null)
        {
            Debug.LogError("Cutscene director not assigned or found. Attach a PlayableDirector component or assign it in the inspector.");
        }

        // Initially hide the book.
        if (bookObject != null)
        {
            bookObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Book GameObject not assigned. Attach a GameObject or assign it in the inspector.");
        }

        // Subscribe to the cutscene finished event.
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped += OnCutsceneFinished;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the cutscene finished event to avoid memory leaks.
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped -= OnCutsceneFinished;
        }
    }

    private void Update()
    {
        // Check if the player is near the trigger collider.
        if (IsPlayerNearCollider() && !hasCutscenePlayed)
        {
            // Check if the 'T' key is pressed using Unity's Input System.
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                // Play the cutscene.
                PlayCutscene();

                // Show the book after the cutscene is played.
                if (bookObject != null)
                {
                    bookObject.SetActive(true);
                }

                // Note: Loading next scene is handled in OnCutsceneFinished method.
            }
        }
    }

    private bool IsPlayerNearCollider()
    {
        // Check if the triggerCollider is assigned.
        if (triggerCollider != null)
        {
            // Calculate the distance between the player and the collider center.
            float distance = Vector3.Distance(transform.position, triggerCollider.bounds.center);

            // Check if the player is within the specified proximity distance.
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
        // Check if the cutscene director is assigned.
        if (cutsceneDirector != null)
        {
            // Play the cutscene.
            cutsceneDirector.Play();
            hasCutscenePlayed = true; // Set the flag to true to indicate that the cutscene has been played.
        }
        else
        {
            Debug.LogError("Cutscene director not assigned. Attach a PlayableDirector component or assign it in the inspector.");
        }
    }

    private void OnCutsceneFinished(PlayableDirector director)
    {
        // This method is called when the cutscene finishes playing.
        // Check if the option to load the next scene is enabled.
        if (loadNextSceneEnabled)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Check if the next scene name is not empty.
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // Load the next scene.
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not specified. Please provide a valid scene name in the inspector.");
        }
    }
}


