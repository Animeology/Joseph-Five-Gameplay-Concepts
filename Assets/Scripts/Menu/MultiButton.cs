using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiButton : MonoBehaviour
{
    public SceneIndexes SceneToLoad;
    public GameObject HideOnClick;

    public void ButtonPressHandler()
    {
        Debug.Log(
            $"Loading scene {SceneToLoad}"
        );

        if (HideOnClick != null)
        {
            HideOnClick.SetActive(false);
        }

        SceneManager.LoadScene(
            (int)(SceneToLoad)
        );
    }
}