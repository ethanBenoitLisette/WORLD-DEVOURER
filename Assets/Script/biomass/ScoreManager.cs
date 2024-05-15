using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public TextMeshProUGUI gainText;
    int biomasse;

    public float autoEarnInterval = 10f;
    public int autoEarnAmount = 5;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        StartCoroutine(AutoEarnBiomasse());
    }

    IEnumerator AutoEarnBiomasse()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoEarnInterval);
            ChangeScore(autoEarnAmount);
            ShowGainText(autoEarnAmount);
            Debug.Log("Biomasse gagnée automatiquement : " + autoEarnAmount);
        }
    }

    public void ChangeScore(int biomasseValue)
    {
        biomasse += biomasseValue;
        text.text = biomasse.ToString();
        Debug.Log("Nouveau solde de biomasse : " + biomasse);
    }

    public int GetBiomasse()
    {
        return biomasse;
    }

    void ShowGainText(int amount)
    {
        gainText.text = "+" + amount.ToString(); 
        StartCoroutine(HideGainText()); 
    }

    IEnumerator HideGainText()
    {
        yield return new WaitForSeconds(1f); 
        gainText.text = ""; 
    }
}
