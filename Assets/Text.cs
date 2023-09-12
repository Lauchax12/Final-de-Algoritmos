using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text text;
    [SerializeField] string tipe;
    private void Update()
    {
        text.text= LocalitationManager.instance.GetText(tipe);
    }
}
