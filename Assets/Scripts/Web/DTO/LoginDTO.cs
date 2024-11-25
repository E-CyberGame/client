using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Web.DTO;

public class LoginDTO : DTO
{
    public string userName { get; set; }
    public string password { get; set; }

    public LoginDTO(string userName, string password)
    {
        this.userName = userName;
        this.password = password;
    }
}
