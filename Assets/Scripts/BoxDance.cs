using UnityEngine;
using System.Collections;

public class BoxDance
	: MonoBehaviour
{
	private float 		fSlerpValue 		= 0.0f;
	private Quaternion 	quatInitialRotation	= Quaternion.identity;
	private Quaternion 	quatTargetRotation 	= Quaternion.identity;
	
	// Use this for initialization
	void Start ()
	{
		InitializeNewTargetRotation();
	}
	
	// Update is called once per frame
	void Update ()
	{
		fSlerpValue += Time.deltaTime / 3.0f;
		if ( fSlerpValue > 1.0f )
		{
			fSlerpValue = 1.0f;
			transform.rotation = quatTargetRotation;
			InitializeNewTargetRotation();
		}
		else
		{
			transform.rotation = Quaternion.Lerp( quatInitialRotation, quatTargetRotation, fSlerpValue );
		}
	}
	
	public void InitializeNewTargetRotation()
	{
		fSlerpValue = 0.0f;
		quatInitialRotation = transform.rotation;
		quatTargetRotation = Random.rotation;
	}
}
