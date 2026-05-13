using System.Collections;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public AnimationCurve curve;
    public float duration = 1f;

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.parent.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
