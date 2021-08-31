using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour
{
    [SerializeField]
    private float interactableDistance = 10f;

    private GameObject _gazeObject;
    private PointerEventData _eventData;

	private void OnEnable()
	{
        ReticleManager.ReticleFilled += OnClick;
	}

    private void OnDisable()
    {
        ReticleManager.ReticleFilled -= OnClick;
    }

    // Start is called before the first frame update
    void Start()
    {
        _eventData = new PointerEventData(EventSystem.current);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInteraction();
    }


    void UpdateInteraction()
	{
        if(Physics.Raycast(transform.position, transform.forward, out var hit, interactableDistance))
		{
           if(_gazeObject == null)
		    {
                _gazeObject = hit.transform.gameObject;
                _gazeObject.GetComponent<IPointerEnterHandler>()?.OnPointerEnter(_eventData);
            }
			else if (_gazeObject != hit.transform.gameObject)
			{
                if (_gazeObject)
				{
                    _gazeObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
                    _gazeObject = hit.transform.gameObject;
                    _gazeObject.GetComponent<IPointerEnterHandler>()?.OnPointerEnter(_eventData);
                }


            }

		}
        else if(_gazeObject)
		{
            _gazeObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
            _gazeObject = null;
        }


        if(_gazeObject !=null && Google.XR.Cardboard.Api.IsTriggerPressed)
		{
            ClickEvent();
		}
	}

    public void OnClick()
	{
        _gazeObject.GetComponent<IPointerClickHandler>()?.OnPointerClick(_eventData);
    }
}
