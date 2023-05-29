using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FlashEffect : MonoBehaviour
{
    /*
        This script requires a flash material placed at 
        "Assets/Resources/Materials".
    */

    private SpriteRenderer spriteRenderer;
    private Material flashMaterial;
    private Material originalMaterial;
    private Player player;

    private Coroutine flashRoutine;
    private float effectDuration;

    public void Flash()
    {
        flashRoutine = StartCoroutine(StartFlashEffect());
        Invoke("StopFlash", effectDuration);
    }

    private void Awake()
    {
        flashMaterial = Resources.Load("Materials/Flash Material") as Material;
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        effectDuration = player.GetDamageCooldown();
        originalMaterial = spriteRenderer.material;
    }

    private void StopFlash()
    {
        StopCoroutine(flashRoutine);
        spriteRenderer.material = originalMaterial;
    }

    private IEnumerator StartFlashEffect()
    {
        const float flashDuration = 0.25f;

        while (true)
        {
            spriteRenderer.material = flashMaterial;
            yield return new WaitForSeconds(flashDuration);

            spriteRenderer.material = originalMaterial;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}
