using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0");
        });
    }
    // Update is called once per frame
    void Update()
    {

    }
}
