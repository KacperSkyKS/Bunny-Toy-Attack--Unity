using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private UpgradePanelUI UpgradePanelUI;
    [SerializeField] private Text Crosshair;
    [SerializeField] private PlayerRotate rotatePlayer;
    [SerializeField] private PlayerRotate rotateCamera;
    private bool isShowingPopup = false;
    void Start()
    {
        UpgradePanelUI.Close();
        popup.gameObject.SetActive(isShowingPopup);

    }
    public void OpenUpgradePanel() {
        UpgradePanelUI.Open();
    }
    public void CloseUpgradePanel()
    {
        UpgradePanelUI.Close();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isShowingPopup)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Crosshair.gameObject.SetActive(true);
                Time.timeScale = 1;
                rotatePlayer.inPopup = false;
                rotateCamera.inPopup = false;
                isShowingPopup = false;
                popup.gameObject.SetActive(isShowingPopup);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Crosshair.gameObject.SetActive(false);
                Time.timeScale = 0;
                rotatePlayer.inPopup = true;
                rotateCamera.inPopup = true;
                isShowingPopup = true;
                popup.gameObject.SetActive(isShowingPopup);
            }
        }
    }
}