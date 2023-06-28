using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI recargaText;
    public TextMeshProUGUI tirosText;

    private int recarga;
    private int tiros;

    private void Start()
    {
        recarga = 0;
        tiros = 0;
        UpdateUI();
    }

    public void SetRecarga(int value)
    {
        recarga = value;
        UpdateUI();
    }

    public void SetTiros(int value)
    {
        tiros = value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        recargaText.text = "Recarga: " + recarga.ToString();
        tirosText.text = "Tiros: " + tiros.ToString();
    }
}
