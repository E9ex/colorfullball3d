using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public IEnumerator camerashakes (float duration, float magnitude)//magnittude titreşimin buyuklüyü bunu dısardan vereceğiz.
    {
        Vector3 originalpos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed< duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalpos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalpos;
    }
}
