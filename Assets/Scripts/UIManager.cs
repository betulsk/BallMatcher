using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject tryAgainButton;
    [SerializeField] private Text levelText;
    private void Start()
    {
        levelText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
    public void Fail()
    {
        gameOverPanel.SetActive(true);
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Win(int sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
