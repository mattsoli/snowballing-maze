using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public GameObject[] winPanelImages;
    public TextMeshProUGUI restartText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.winPanelImages.Length; i++)
        {
            this.winPanelImages[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActiveWinPanel(bool isActive)
    {
        this.winPanel.SetActive(isActive);
    }

    public void ActiveGameOverPanel(bool isActive)
    {
        this.gameOverPanel.SetActive(isActive);
    }
}
