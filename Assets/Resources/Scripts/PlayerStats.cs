using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IAttackable
{
    [SerializeField] private int health;



    #region sprite_values
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField] private Color flashColor;
    [SerializeField] private int flashCount;
    private float duration = 2f;
    #endregion
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        FlashColor();
    }

    public void FlashColor()
    {
        StartCoroutine(FlashCoroutine(flashColor, duration, flashCount));
    }

    IEnumerator FlashCoroutine(Color flashColor, float duration, int flashCount)
    {
        
        float timePerFlash = duration / flashCount;
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(timePerFlash / 2);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(timePerFlash / 2);
        }
        spriteRenderer.color = originalColor;
        
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
