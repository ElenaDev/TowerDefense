using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform panelAlly;
    public RaycastCharacter raycastCharacter;//script que controla la colocación de unidades aliadas
    public float fillSpeedImage;

    [Header ("Allies availables")]
    public int numHero;
    public int numLich;
    public Text _textNumHero;
    public Text _textNumLich;

    [Header("Slot Manager")]
    public Color colorA;//slot no relleno
    public Color colorB;//slot rellenado
    public Image[] slotsHero;//array donde van los 3 slots del Hero
    public Image[] slotsLich;//array donde van los 3 slots del Lich

    GameObject currentObject;

    int direction = 1;
    private void Awake()
    {
        
    }
    private void Start()
    {
        _textNumHero.text = "x " + numHero.ToString();
        //Reseta los slots de la unidad aliada que queramos, le pasamos el array de slots, que es de tipo Image
        ResetSlots(slotsHero);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            direction = direction * -1;
            panelAlly.DOAnchorPosX(direction * 100, 2).SetEase(Ease.OutElastic);
        }
    }
    //Función que van a llevar los botones para crear unidades aliadas
    public void CreateAllyCharacter(GameObject character)
    {
        //Creo un clone del prefab en la escena
        currentObject = Instantiate(character) as GameObject;

        raycastCharacter.currentObject = currentObject;
        raycastCharacter.objectToPlace = true;
    }
   //función para hacer no interactuable el botón durante un tiempo
    public void WaitForNextAlly(GameObject _button)
    {
        //Hacemos que el botón no sea interactuable
        _button.GetComponent<Button>().interactable = false;
        //pongo el fill amount de la imagen a cero para proceder ahora a hacer el "llenado de la imagen"
        _button.GetComponent<Image>().fillAmount = 0;

        //comprobamos si hay aliados disponibles
        if(CheckNumberAlly()!=0)
        {
            //llamada a la coroutina si SI hay aliados disponibles
            StartCoroutine("FillAmountButton", _button.GetComponent<Image>());
        } 
    }
    //Coroutina para hacer el llenado de la imagen
    IEnumerator FillAmountButton(Image _image)
    {
        while(_image.fillAmount < 1)
        {
            _image.fillAmount += fillSpeedImage * Time.deltaTime;

            yield return null;
        }
        //tengo que comprobar si vuelvo o no a habilitar el botón, dependiendo de si quedan unidades para instanciar

        _image.GetComponent<Button>().interactable = true;
    }
    int CheckNumberAlly()
    {
        int n;
        switch (currentObject.GetComponent<Hero>().ally)
        {
            case Hero.kindOfAlly.hero:
                numHero--;
                _textNumHero.text = "x "+numHero.ToString();
                n = numHero;
                break;
            case Hero.kindOfAlly.lich:
                numLich--;
               // _textNumLich.text = "x " + numLich.ToString();
                n = numLich;
                break;
            default:
                n = 0;
                break;
        }
        return n;
    }
    //Función publica que la voy a llamar desde el script del player cada vez que coja un recurso para aumentar unidades
    //alidas
    public void SelectCharacter(string tag)
    {
        switch (tag)
        {
            case "Hero":
                AddSlotToAlly(slotsHero, numHero, _textNumHero);
                break;
            case "Lich":
                AddSlotToAlly(slotsLich, numLich, _textNumLich);
                break;
            default:
                break;
        }
    }
    void AddSlotToAlly(Image[] slots, int n, Text _text)
    {
        int i;
        for (i=0; i< slots.Length;i++)
        {
            if (slots[i].color == colorA)
                break;
        }

        if(i == slots.Length)
        {
            n++;
            _text.text = "x " + n.ToString();
            //Resetar los slots
            ResetSlots(slots);
        }
        else
        {
            slots[i].color = colorB;
        }
    }
    void ResetSlots(Image[] slots)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].color = colorA;
        }
    }

}
