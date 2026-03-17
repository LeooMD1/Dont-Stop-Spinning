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

            transform.localPosition += new Vector3(0, Time.fixedDeltaTime * 1000, 0);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue += 20;
                break;
            case 2:
                randomValue += 10;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.localPosition.y >= 330)
                transform.localPosition = new Vector2(transform.localPosition.x, -330);

            transform.localPosition += new Vector3(0, 10, 0);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }

        if (transform.localPosition.y == -330)
            stoppedSlot = "Cherry";
        else if (transform.localPosition.y == -230)
            stoppedSlot = "Banana";
        else if (transform.localPosition.y == -155)
            stoppedSlot = "Kiwi";
        else if (transform.localPosition.y == -70)
            stoppedSlot = "Orange";
        else if (transform.localPosition.y == 25)
            stoppedSlot = "Grape";
        else if (transform.localPosition.y == 110)
            stoppedSlot = "Mango";
        else if (transform.localPosition.y == 210)
            stoppedSlot = "7";
        else if (transform.localPosition.y == 290)
            stoppedSlot = "6";

        rowStopped = true;
    }
} 
