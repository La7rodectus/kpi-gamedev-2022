using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hero")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}