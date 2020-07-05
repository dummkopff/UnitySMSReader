using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitySMSSettings : MonoBehaviour {

	List<GameObject> _sms_blocks = new List<GameObject>();
	public GameObject _prefab;
	GameObject _parent, _object;
	public Text txt_1;

	/*void Start () {
		ReadSms.OnSMSReceiveHandler += Update;
		//_parent = GameObject.Find("Content");
	}

    private void Update(object o, ReadSms.SMSReceiveEventArgs arg)
    {
		txt_1.text = arg.Message;
    }*/

    /*void OnSMSReceive (object o, ReadSms.SMSReceiveEventArgs arg) {
		//if (arg.Message.Contains("Hello"))
		Debug.Log(arg.Message);
		txt_1.text = arg.Message;
	}*/

    /*void CreateNewBlock() {
		_object = Instantiate(_prefab, transform.position, Quaternion.identity);
		_sms_blocks.Add(_object);
		_object.transform.parent = _parent.transform;
		_object.transform.localScale = new Vector3(1f, 1f, 1f);
		_object.GetComponent<SMSBlock>().message.text = args.ToString();
		_object.GetComponent<SMSBlock>().date.text = System.DateTime.Now.ToString();
	}*/
}
