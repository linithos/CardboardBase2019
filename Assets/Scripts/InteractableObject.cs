using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    public void ScaleObject(float scaleValue)
	{
		Vector3 newScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z) * scaleValue;
		transform.localScale = newScale;
	}

	public void ResetScale()
	{
		transform.localScale = Vector3.one;
	}

	public void ChangeMaterial()
	{
		
	}


}
