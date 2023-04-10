using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIManager : MonoBehaviour
{
    public GameObject connectOptions_Panel;
    public GameObject connectWithName_Panel;

    #region Unity Methods
    void Start()
    {
        connectOptions_Panel.SetActive(true);
        connectWithName_Panel.SetActive(false);
    }

    

    #endregion
}
