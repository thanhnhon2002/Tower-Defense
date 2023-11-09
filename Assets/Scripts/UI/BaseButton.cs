using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : AdminMonoBehaviour
{
    protected Button button;
    protected override void LoadComponent()
    {
        this.button = transform.GetComponent<Button>();
    }


}
