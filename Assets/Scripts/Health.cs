using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    //Red color with 10% opacity
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    bool isDead;
    bool damaged;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void FixedUpdate()
    {
        //Flashes the red color when damaged
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        //Fades away the red color if damgaged
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Dead!");
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
    }
}