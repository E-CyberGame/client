using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Web.DTO;

public class LoginDTO : DTO
{
    public string username { get; set; }
    public string password { get; set; }

    public LoginDTO(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}
