using UnityEngine;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown colorDropdown;
    [SerializeField] private TMP_Dropdown patternDropdown;
    [SerializeField] private TMP_Text previewText;
    
    private string[] colors = { "黒色", "白色", "灰色", "茶色", "焦茶色" };
    private string[] patterns = { "トラ", "ミケ", "ブチ", "ハチワレ", "シャム", "サビ" };
    
    private int selectedColorIndex = 0;
    private int selectedPatternIndex = 0;

    void Start()
    {
        InitializeDropdowns();
        LoadPlayerName();
        UpdatePreview();
    }

    void InitializeDropdowns()
    {
        colorDropdown.ClearOptions();
        colorDropdown.AddOptions(new System.Collections.Generic.List<string>(colors));
        
        patternDropdown.ClearOptions();
        patternDropdown.AddOptions(new System.Collections.Generic.List<string>(patterns));
        
        colorDropdown.onValueChanged.AddListener(OnColorChanged);
        patternDropdown.onValueChanged.AddListener(OnPatternChanged);
    }

    void LoadPlayerName()
    {
        selectedColorIndex = PlayerPrefs.GetInt("PlayerColorIndex", 0);
        selectedPatternIndex = PlayerPrefs.GetInt("PlayerPatternIndex", 0);
        
        colorDropdown.value = selectedColorIndex;
        patternDropdown.value = selectedPatternIndex;
    }

    public void OnColorChanged(int index)
    {
        selectedColorIndex = index;
        UpdatePreview();
        SavePlayerName();
    }

    public void OnPatternChanged(int index)
    {
        selectedPatternIndex = index;
        UpdatePreview();
        SavePlayerName();
    }

    void UpdatePreview()
    {
        string playerName = GetPlayerName();
        previewText.text = $"プレイヤー名: {playerName}";
    }

    void SavePlayerName()
    {
        PlayerPrefs.SetInt("PlayerColorIndex", selectedColorIndex);
        PlayerPrefs.SetInt("PlayerPatternIndex", selectedPatternIndex);
        PlayerPrefs.SetString("PlayerName", GetPlayerName());
        PlayerPrefs.Save();
    }

    public string GetPlayerName()
    {
        return $"{colors[selectedColorIndex]}の{patterns[selectedPatternIndex]}ネコ";
    }

    public static string GetCurrentPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "黒色のトラネコ");
    }
}