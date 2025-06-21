using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    [SerializeField] GameObject optionsPanel;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioPlayer audioPlayer;
    [SerializeField] Button optionsButton;

    bool isPaused = false;
   
   
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("UIManager duplicate detected → destroying this one");
            Destroy(gameObject);
            return;
        }

        Debug.Log("UIManager instance initialized");
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        optionsPanel.SetActive(false);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = 1f; // 默认音量
        optionsButton.gameObject.SetActive(true); // 保证按钮显示
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleOptionsPanel();
        }
    }
    public void ToggleOptionsPanel()
    {
        isPaused = !isPaused;

        optionsPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
        // 或者单独调 AudioPlayer 的 volume（更细粒度控制）
    }
    public void OnOptionsButtonClick()
    {
        ToggleOptionsPanel();
    }
}
