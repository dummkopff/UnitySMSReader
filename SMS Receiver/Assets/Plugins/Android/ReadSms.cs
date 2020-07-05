using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ReadSms : MonoBehaviour {

	AndroidJavaClass ajc;

	string[] sms;
	List<GameObject> _sms_blocks = new List<GameObject>();
	public GameObject _prefab;
	GameObject _parent, _object;

	string gameobject_name = "UnitySMSReader";

	public void Start () {
		this.gameObject.name = gameobject_name;
		ajc = new AndroidJavaClass("com.example.smsplugin.SmsListener");
		SendToAndroid("SMS.RU");
		_parent = GameObject.Find("Content");
	}

    #region SMSShow
    private void SendToAndroid(string message)
		{
			ajc.CallStatic("onReceive", message);
		}

		private void GetSMS(string output) {
			Debug.Log("Received message from toast plugin: " + output);
			sms = output.Split(Convert.ToChar("|")); 
			for(int i =0; i < sms.Length; i++)
			{
				CreateNewBlock(sms[i].Split(Convert.ToChar("&"))[0], sms[i].Split(Convert.ToChar("&"))[1]);
			}
		}
	#endregion

	void CreateNewBlock(string _output,string _date)
	{
		_object = Instantiate(_prefab, transform.position, Quaternion.identity);
		_sms_blocks.Add(_object);
		_object.transform.parent = _parent.transform;
		_object.transform.localScale = new Vector3(1f, 1f, 1f);
		_object.GetComponent<SMSBlock>().message_txt.text = _output;
		_object.GetComponent<SMSBlock>().date_txt.text = _date;
	}
}
