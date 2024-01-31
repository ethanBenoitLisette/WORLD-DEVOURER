using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class eatEnemy : MonoBehaviour
{
    public GameObject spawnPrefab;
    private UpgradeManager playerUpgradeManager;
    public float life = 100;
    public float MaxLife = 100;
    private PlayerStat playerStat;
    private int collisionsCount = 0; // Variable pour compter les collisions
    private int piecesToSpawn; // Variable pour stocker le nombre de pi�ces � g�n�rer � la mort

    private Image healthBar;
    private Canvas canvas;

    void Start()
    {
        playerUpgradeManager = FindObjectOfType<UpgradeManager>();
        playerStat = FindObjectOfType<PlayerStat>();

        // Cr�e la barre de vie
        CreateHealthBar();
        // D�sactive le Canvas au d�part
        DeactivateCanvas();
    }

    // Fonction pour prendre des d�g�ts
    public void TakeDamage(float damage)
    {
        life -= damage;

       

        // V�rifie si l'ennemi est mort
        if (life <= 0)
        {
            piecesToSpawn = Mathf.CeilToInt(collisionsCount / 2.0f); // Calcule le nombre de pi�ces � g�n�rer
            StartCoroutine(DelayedDestroyAndSpawn(piecesToSpawn));
        }
        else
        {
            StartCoroutine(DelayedSpawn());
        }

        // R�duit la taille de la barre de vie en fonction des d�g�ts
        // Met � jour la barre de vie
        UpdateHealthBar();
    }

    // Fonction pour r�duire la taille de la barre de vie
    void ReduceHealthBar(float damage)
    {
        // Calcule le pourcentage de r�duction en fonction des d�g�ts
        float reductionPercentage = damage / MaxLife;

        // R�duit la taille de la barre de vie
        healthBar.fillAmount = Mathf.Max(0, healthBar.fillAmount - reductionPercentage);
    }

    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator DelayedDestroyAndSpawn(int numberOfPieces)
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        // Fais spawn du nombre correct de pi�ces avant de d�truire l'ennemi
        for (int i = 0; i < numberOfPieces; i++)
        {
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }

        DeactivateCanvas(); // D�sactive le Canvas avant de d�truire l'ennemi
        Destroy(gameObject); // D�truit l'ennemi
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerObject"))
        {
            // Active le Canvas lorsque le joueur entre en collision avec l'ennemi

            ActivateCanvas();


            // Prends des d�g�ts de l'ennemi
            TakeDamage(playerStat.GetCurrentDamage());

            // Incr�mente le compteur de collisions
            collisionsCount++;
        }
    }

    void CreateHealthBar()
    {
        // Cr�e un objet Canvas pour la barre de vie
        GameObject canvasObject = new GameObject("Canvas");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvasObject.transform.SetParent(transform);

        // Cr�e un objet Image pour la barre de vie
        GameObject healthBarObject = new GameObject("HealthBar");
        healthBarObject.transform.SetParent(canvasObject.transform);
        healthBarObject.transform.localPosition = transform.position; 


        healthBar = healthBarObject.AddComponent<Image>();  
        healthBar.color = Color.red;  // Change la couleur initiale � rouge
        healthBar.type = Image.Type.Filled;
        healthBar.fillMethod = Image.FillMethod.Horizontal;
        healthBar.fillAmount = 1f;

        // Ajuste la taille de la barre de vie ici
        RectTransform rectTransform = healthBar.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(5f, 1f); // Ajustez ces valeurs pour d�finir la taille souhait�e

    }

    // Fonction pour mettre � jour la barre de vie
    void UpdateHealthBar()
    {
        // V�rifie si la barre de vie existe
        if (healthBar != null)
        {
            // V�rifie si la vie actuelle est inf�rieure � la vie maximale
            if (life <= MaxLife)
            {
                // Calcule le pourcentage de vie restante
                float healthPercentage = life / MaxLife;

                // Ajuste la largeur de la barre en fonction du pourcentage de vie restante
                RectTransform rectTransform = healthBar.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(5f * healthPercentage, rectTransform.sizeDelta.y);
            }
        }
    }

    void UpdateHealthBarPosition()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        canvas.transform.position = new Vector3(screenPos.x, screenPos.y + 5f, screenPos.z);
    }

    // Fonction pour activer le Canvas
    void ActivateCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = true;
        }
    }

    // Fonction pour d�sactiver le Canvas
    void DeactivateCanvas()
    {
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }
}
