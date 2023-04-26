using UnityEngine;

public class MultiButtonListener : MonoBehaviour
{
    public LayerMask layerMask;

    const float MAX_CLICK_DISTANCE = 50;

    const int LEFT_MOUSE_BUTTON = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                Input.mousePosition
            );

            bool rayHitButton = Physics.Raycast(
                ray,
                hitInfo: out RaycastHit hit,
                maxDistance: MAX_CLICK_DISTANCE,
                layerMask
            );

            if (rayHitButton)
            {
                GameObject clickedGO = hit.transform.gameObject;
                MultiButton buttonMB = clickedGO.GetComponent<MultiButton>();
                if (buttonMB != null)
                {
                    buttonMB.ButtonPressHandler();
                }

            }
        }
    }
}
