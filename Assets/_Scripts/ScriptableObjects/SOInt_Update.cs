using TMPro;
using UnityEngine;

public class SOInt_Update : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private string extraText = "";
    public SOInt soInt;

    private void Start()
    {
        UpdateText(soInt.Value);
    }
    
    private void OnEnable()
    {
        soInt.OnValueChanged += UpdateText;
        UpdateText(soInt.Value);
    }
    private void OnDisable()
    {
        soInt.OnValueChanged -= UpdateText;
    }

    private void UpdateText(int newValue)
    {
        uiText.text = extraText + newValue.ToString();
    }

}
