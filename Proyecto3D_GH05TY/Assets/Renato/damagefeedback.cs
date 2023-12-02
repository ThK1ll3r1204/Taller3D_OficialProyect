using System.Collections;
using UnityEngine;

public class damagefeedback : MonoBehaviour
{
    private Renderer playerRenderer;
    private Material originalColor;
    public Material damageColor;

    public float damageDuration = 0.2f;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material;
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        StartCoroutine(FlashDamage());
    }

    private IEnumerator FlashDamage()
    {
        int blinkCount = 3; // Cambia esto según la cantidad de destellos que desees

        for (int i = 0; i < blinkCount; i++)
        {
            playerRenderer.material = damageColor;

            // Espera un breve período de tiempo
            yield return new WaitForSeconds(damageDuration / 2);

            // Vuelve al color original
            playerRenderer.material = originalColor;

            // Espera otro breve período de tiempo antes del próximo destello
            yield return new WaitForSeconds(damageDuration / 2);
        }
    }
}

