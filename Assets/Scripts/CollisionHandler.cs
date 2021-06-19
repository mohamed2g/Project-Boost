using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You've hit a freiendly");
                break;
            case "Finish":
                StartSuccessSequence();                
                break;
            default:
                StartCrashSequence();
                
                break;
        }
    }
    
    
    void StartCrashSequence()
    {
        // todo add sfx uppon crash
        // todo add particle effect upon crash
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel" ,levelLoadDelay);
    }
    
    void StartSuccessSequence()
    {
        // todo add sfx uppon success
        // todo add particle effect upon success
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLevel" ,levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1 ;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


}
