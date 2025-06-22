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
        /*if (instance != null)
        {
            Debug.LogWarning("UIManager duplicate detected → destroying this one");
            Destroy(gameObject);
            return;
        }

        Debug.Log("UIManager instance initialized");
        instance = this;
        DontDestroyOnLoad(gameObject);*/
        Debug.Log("UIManager initialized via MainController");
    }
    void Start()
    {
        optionsPanel.SetActive(false);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = 1f; 
        optionsButton.gameObject.SetActive(true); 
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
        MainController.Instance.SoundManager.PlayMenuToggleClip();
    }

    void SetVolume(float value)
    {
        AudioListener.volume = value;
       
    }
    public void OnOptionsButtonClick()
    {
        ToggleOptionsPanel();
    }
}
