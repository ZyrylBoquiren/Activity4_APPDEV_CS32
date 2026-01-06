using Microsoft.AspNetCore.Mvc;
using SimpleMvcFrontend.Data;
using SimpleMvcFrontend.Models;
using System.Linq;
using System;
public class ContactController : Controller
{
    private readonly AppDbContext _context;


    public ContactController(AppDbContext context)
    {
        _context = context;
    }


    // READ
    public IActionResult Index()
    {
        var contacts = _context.Contacts.ToList();
        return View(contacts);
    }


    // CREATE (GET)
    public IActionResult Create()
    {
        return View();
    }


    // CREATE (POST)
    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}