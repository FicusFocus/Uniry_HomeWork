using UnityEngine;


public class Fire : MonoBehaviour
{
	private float _time = 0;

	void OnEnable () 
	{
		_time = Time.time + 0.3f;
	}
	
	void FixedUpdate () 
	{
		if (_time < Time.time)
		 gameObject.SetActive(false);
	}
}
