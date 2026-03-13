using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    private float randomValue;
    private float timeInterval;
    public Button button;

    public bool rowStopped;
    public string stoppedSlot;

    private void Start()
    {
        rowStopped = true;
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        stoppedSlot = "";
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        yield return null;
        rowStopped = false;

        for (int i = 0; i < 30; i++)
        {
            if (transform.localPosition.y >= 330)
                transform.localPosition = new Vector2(transform.localPosition.x, -330);

            transform.localPosition += new Vector3(0, Time.deltaTime * 1000, 0);

            yield return new WaitForEndOfFrame();
        }
    }
}
