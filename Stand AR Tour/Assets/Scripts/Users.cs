using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users : MonoBehaviour {

	public string firstname;
	public string lastname;
	public string email;
	
	public Users() {

	}

	public Users(string firstname, string lastname, string email) {
		this.firstname = firstname;
		this.lastname = lastname;
		this.email = email;
	}
}
