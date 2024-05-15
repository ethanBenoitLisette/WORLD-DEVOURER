using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonAddInsect : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddInsect()
    {
        UpgradeManager.instance.AddInsect();
    }
}
