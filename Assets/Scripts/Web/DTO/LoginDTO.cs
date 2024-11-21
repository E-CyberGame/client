using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Web.DTO;

public class LoginDTO : DTO
{
    public string userid { get; set; }
    public string password { get; set; }

    public LoginDTO(string userid, string password)
    {
        this.userid = userid;
        this.password = password;
    }
}
