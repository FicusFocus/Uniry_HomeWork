using UnityEngine;

public class MenuButton : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Time.timeScale = 0;
    }

    public void ShowPanel(GameObject menuPanel)
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false); ;
    }

    public void DisablePanel(GameObject menuPanel)
    {
        menuPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
