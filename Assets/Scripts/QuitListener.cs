using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitListener : MonoBehaviour
{
    const int RIGHT_MOUSE_BUTTON = 1;

    bool alreadyQuitting = false;

    void Update()
    {
        if (!alreadyQuitting && Input.GetMouseButtonDown(RIGHT_MOUSE_BUTTON))
        {
            alreadyQuitting = true;
            SceneManager.LoadScene(
                (int)SceneIndexes.MenuScene    
            );
        }
    }
}