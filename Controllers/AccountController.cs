using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Auktioner.Models;

public class Accountcontroller : Controller
{
   
    public IActionResult Login()
    {
        return View();
    }

     public IActionResult CreateAccount()
    {
        return View();
    }

}