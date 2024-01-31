using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int biomasse;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null )
        {
            instance = this;
        }
    }



    public void ChangeScore(int  biomasseValue)
    {
        biomasse += biomasseValue;
        text.text = biomasse.ToString();
        Debug.Log("Nouveau solde de biomasse : " + biomasse);
    }
    public int GetBiomasse()
    {
        return biomasse;
    }

   

}
