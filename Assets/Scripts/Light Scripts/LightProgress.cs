using UnityEngine;

public class LightProgress : MonoBehaviour
{
    public GameObject TotalIndicator;
    public GameObject LitIndicator;

    void Update()
    {
        float litScale = LightZone.Progress01;

        LitIndicator.transform.localScale = new Vector3(
            litScale, litScale, litScale
        );

        if (LightZone.AllAreLit)
        {
            TotalIndicator.SetActive(false);
        }
    }

}
