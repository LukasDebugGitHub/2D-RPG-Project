using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiyFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private float flashDuration;

    [Header("Flash FX")]
    [SerializeField] private Material hitMat;
    private Material originalMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); 
        originalMat = sr.material;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(flashDuration);

        sr.material = originalMat;
    }
}
