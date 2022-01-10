using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanvasEquipment : MonoBehaviour
{
    [SerializeField]
    Scrollbar bar;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        setSizeScrollBar(bar);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setSizeScrollBar(Scrollbar bar)
    {
        bar.value = 0.0001f;
        bar.size = 0.07f;
    }
}
