using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    Vector3 touchStart;
    private float zoomOutMin = 5;
    private float zoomOutMax = 20;

    private bool canInteract=true;

    private void Start()
    {
        CodePanel.closeBtnClicked += allowInteraction;
        Navigation.codePanelOpened += disableInteraction;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (!SceneManager.GetSceneByBuildIndex(level).name.StartsWith("Level"))
        {
            disableInteraction();
        }
        else
        {
            allowInteraction();
        }
    }

    private void disableInteraction()
    {
        canInteract = false;
    }

    private void allowInteraction()
    {
        canInteract = true;
    }

    void Update()
    {
        if (!canInteract)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}