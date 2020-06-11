using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DiceCustomization : MonoBehaviour 
{
    private Renderer _renderer;
    public bool IsCreatingCharacter;

    [SerializeField]
    private Image[] _sliderHandles;

    [SerializeField, Tooltip("0=dice 1=values 2=natural1 3=natural20")]
    private Slider[] _customizationSliders;

    [SerializeField, Range(0, 1)]
    private float _diceColorGradient,
                  _valueColorGradient,
                  _natural1ColorGradient,
                  _natural20ColorGradient;

    private int _oldSkinColorValue,
                _oldEyeColorValue,
                _oldShirtColorValue,
                _oldShoeColorValue,
                _oldGloveColorValue,
                _oldPantsColorValue;

    private void Start() 
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _renderer.sharedMaterial.shader = Shader.Find("Shader Graphs/CharacterCustomization");
    }

    public void SkinColorControl(float _value)
    {
        _diceColorGradient = _value;
        _oldSkinColorValue = (int)(Mathf.Round(_diceColorGradient * 100f) / 100f);
        SetColor(gameObject, "Skin", _diceColorGradient);
    }

    public void EyeColorControl(float value) 
    {
        _valueColorGradient = value;
        _oldEyeColorValue = (int)(Mathf.Round(_valueColorGradient * 100f) / 100f);
        SetColor(gameObject, "Eyes", _valueColorGradient);
    }

    public void ShirtColorControl(float value)
    {
        _natural1ColorGradient = value;
        _oldShirtColorValue = (int)(Mathf.Round(_valueColorGradient * 100f) / 100f);
        SetColor(gameObject, "Shirt", _natural1ColorGradient);
    }

    public void ShoesColorControl(float value)
    {
        _natural20ColorGradient = value;
        _oldShoeColorValue = (int)(Mathf.Round(_valueColorGradient * 100f) / 100f);
        SetColor(gameObject, "Shoes", _natural20ColorGradient);
    }

    public void GlovesColorControl(float value)
    {
        _gloveColorGradient = value;
        _oldGloveColorValue = (int)(Mathf.Round(_valueColorGradient * 100f) / 100f);
        SetColor(gameObject, "Gloves", _gloveColorGradient);
    }

    public void PantsColorControl(float value)
    {
        _pantsColorGradient = value;
        _oldPantsColorValue = (int)(Mathf.Round(_valueColorGradient * 100f) / 100f);
        SetColor(gameObject, "Pants", _pantsColorGradient);
    }

    public void SetColor(GameObject _target, string _feature, float _value) 
    {
        Renderer _targetRenderer;
        Image _targetImage;

        _targetRenderer = _target.GetComponent<Renderer>();

        switch (_feature) {
            case "Skin":
                _targetImage = _sliderHandles[0].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 0);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("SkinGradientPos", new Vector2(_value, 0f));
                break;

            case "Eyes":
                _targetImage = _sliderHandles[1].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 1);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("EyeGradientPos", new Vector2(_value, 0f));
                break;

            case "Shirt":
                _targetImage = _sliderHandles[2].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 1);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("ShirtGradientPos", new Vector2(_value, 0f));
                break;

            case "Shoes":
                _targetImage = _sliderHandles[3].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 1);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("ShoesGradientPos", new Vector2(_value, 0f));
                break;

            case "Gloves":
                _targetImage = _sliderHandles[4].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 1);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("GlovesGradientPos", new Vector2(_value, 0f));
                break;

            case "Pants":
                _targetImage = _sliderHandles[5].GetComponent<Image>();
                _targetImage.material.SetFloat("Bool_IsRainbow", 1);
                _targetImage.material.SetVector("Vector2_Texture_Position", new Vector2(_value, 0f));

                _targetRenderer.sharedMaterial.SetVector("PantsGradientPos", new Vector2(_value, 0f));
                break;

            default:
                break;
        }
    }

    public void CreateCharacter() 
    {
        IsCreatingCharacter = false;

        PlayerPrefs.SetInt("hasCharacter", 1);
        PlayerPrefs.SetFloat("skincolor", _diceColorGradient);
        PlayerPrefs.SetFloat("eyecolor", _valueColorGradient);
        PlayerPrefs.SetFloat("shirtcolor", _natural1ColorGradient);
        PlayerPrefs.SetFloat("glovecolor", _gloveColorGradient);
        PlayerPrefs.SetFloat("pantscolor", _pantsColorGradient);
        PlayerPrefs.SetFloat("shoecolor", _natural20ColorGradient);
        PlayerPrefs.Save();
    }
}
