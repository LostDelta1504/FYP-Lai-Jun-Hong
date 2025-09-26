using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;   // so we can see IInteractable

public class LoadSceneOnInteract : MonoBehaviour
{
    [SerializeField] string sceneToLoad = "EndGameScene";
    [SerializeField] float loadDelay = 0f;
    [SerializeField] bool oneShot = true;
    bool triggered;

    void OnTriggerEnter(Collider other)
    {
        if (triggered && oneShot) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        if (loadDelay <= 0f) SceneManager.LoadScene(sceneToLoad);
        else StartCoroutine(LoadAfterDelay());
    }

    System.Collections.IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneToLoad);
    }
}

