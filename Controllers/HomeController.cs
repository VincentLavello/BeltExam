﻿using System.Linq.Expressions;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security.Cryptography;
using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
// using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using BeltExam.Models;

namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
        private BeltExamContext dbContext;
        public HomeController(BeltExamContext context)
        {
            dbContext = context;
        }
    [HttpGet("")]
    public IActionResult Index() {
        if (!this.IsLoggedIn) {
            return RedirectToAction("Register");
        }
        else {
            return RedirectToAction("DojoActivities");
        }
    }
    [HttpGet("DojoActivities")]
    public IActionResult DojoActivities()
    { if (IsLoggedIn)
        {

            List<RecActivity> All = dbContext.Activities.OrderBy(r=>r.ActivityDate)
                                .Where(d => d.ActivityDate > DateTime.Now)
                                .Include(c=>c.Coordinator )
                                .Include(p=>p.Particpants)
                                    .ThenInclude(u=>u.Participant)
                                .ToList();

            ViewBag.UserId=this.LoggedInUserID;

            foreach (var rec in All) {
                System.Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                // Console.WriteLine(rec.Particpants.Any(u=>u.UserId==this.LoggedInUserID));
                // dbContext.Activities.Particpants.Add(new RSVP(rec.RecActivityID, this.LoggedInUserID));
                // dbContext.SaveChanges();
                System.Console.WriteLine($"{rec.ActivityDate} {rec.Description } {rec.Particpants.Count }" );
                Console.WriteLine(rec.Particpants.Any(u=>u.UserId==this.LoggedInUserID));

                System.Console.WriteLine(rec.Particpants.Count );
            }

            return View("DojoActivities", All);
        }
        else
        {
            return RedirectToAction("Register");
        }

    }
    [HttpPost("NewActivity")]
    public IActionResult NewActivity(RecActivity NewActivity) {
        int ActivityId = NewActivity.RecActivityID;
        bool flgProblemDate = (NewActivity.ActivityDate <= DateTime.Now);

        if ( ModelState.IsValid  && !flgProblemDate )  {
     
            NewActivity.UserId=this.LoggedInUserID;
            dbContext.Activities.Add(NewActivity);
            dbContext.SaveChanges();
        }
        else {
            if (flgProblemDate) {
                ModelState.AddModelError(string.Empty, "Future date required for events");
            }
            return View("NewActivity");
        }
    return RedirectToAction("ShowActivity",  new { ActivityId =(int) NewActivity.RecActivityID});

    }
    [HttpGet("Register")]
    public IActionResult Register() => View();
    [HttpGet("ViewNewActivity")]
    public IActionResult ViewNewActivity() => View("NewActivity");

    [HttpGet("ShowActivity/{ActivityId}")]
    public IActionResult ShowActivity(int ActivityId )
    {
        if(ActivityId>0) {
            ViewBag.UserId = this.LoggedInUserID;
            RecActivity One = dbContext.Activities.OrderBy(r=>r.ActivityDate)
            .Include(c=>c.Coordinator )
            .Include(p=>p.Particpants)
                .ThenInclude(u=>u.Participant)
                .FirstOrDefault(a => a.RecActivityID==ActivityId);

            return View("ShowActivity", One);

        }
        else {
            return View("DojoActivities");
        }
    }

    // [HttpGet("GetAllUsers")]
    // public string GetAllUsers()
    // {
    //     string[] AllUsers = dbContext.Users.Select(u=>u.FullName).ToArray();
    //     var json = JsonConvert.SerializeObject(AllUsers);
    //     // System.Console.WriteLine(json);
    //     return  json;

    // }

    [HttpGet("RSVP/{ActivityId}")]
    public IActionResult RSVP(int ActivityId) {

            RSVP rsvp=new RSVP(ActivityId, this.LoggedInUserID);

            dbContext.Participants.Add(rsvp);
            dbContext.SaveChanges();

            return RedirectToAction("DojoActivities");
        }
    [HttpGet("UNRSVP/{ActivityId}")]
    public IActionResult UNRSVP(int ActivityId) {
        

        RSVP rsvp = dbContext.Participants.FirstOrDefault(u=>u.RecActivityID==ActivityId && u.UserId==this.LoggedInUserID);
            dbContext.Participants.Remove(rsvp);
            dbContext.SaveChanges();
            return RedirectToAction("DojoActivities");

        }
    [HttpGet("CancelActivity/{ActivityId}")]
    public IActionResult CancelActivity(int ActivityId) {
            RecActivity dead = dbContext.Activities.FirstOrDefault(r=>r.RecActivityID==ActivityId);
            if (dead!=null)
            {
                dbContext.Activities.Remove(dead);
                dbContext.SaveChanges();
            }
            return RedirectToAction("DojoActivities");

        }

///@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
///
    [HttpPost]
    [Route("CreateUser")]
    public IActionResult CreateUser(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Register");
        }
        else
        {
            if (dbContext.Users.Any(u => u.Email == newUser.Email))
            {
                // Manually add a ModelState error to the Email field, with provided
                // error message
                ModelState.AddModelError("NewUser.Email", "Email already in use!");
                // return View("Register", newUser);
                return View("Register");
            }
            else
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                newUser.CreatedAt = DateTime.Now;
                dbContext.Add(newUser);
                // OR dbContext.Guests.Add(newUser);
                dbContext.SaveChanges();
                SetLoggedInStatus(newUser.UserId);
                // Console.WriteLine($"New User ID: {newUser.UserId.ToString()}");
            return RedirectToAction("DojoActivities");

            }
        }
    }
    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    //
    // L O G   I N
    [HttpGet("CheckLogin")]
    public string CheckLogin() => IsLoggedIn ? "Yes I am logged in" : "No Not logged in.";
    [HttpPost("Login")]
    public IActionResult Login(LoginReg user){
        PasswordVerificationResult hasherResult;
        if(ModelState.IsValid)
        {
            var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == user.LoginDetail.Email);

            // If no user exists with provided email
            if(userInDb == null) {
                System.Console.WriteLine("Not in database");
                ModelState.AddModelError("Email", "Invalid Email/Password");
                IncrementLogInattempts();
                Console.WriteLine($"attempts: {this.LoginAttempts.ToString()}");
                ViewBag.Attempts  = this.LoginAttempts.ToString();
            }
            else
            {
                // ModelState.AddModelError("Email", "Invalid Email/Password");
                var hasher = new PasswordHasher<Login>();
                // verify provided password against hash stored in db
                hasherResult = hasher.VerifyHashedPassword(user.LoginDetail, userInDb.Password, user.LoginDetail.Password);
                if(hasherResult != 0)
                {
                    SetLoggedInStatus(userInDb.UserId);
                    // ViewBag.Transactions = GetUserTransactions(); // for use with partial

                    ClearLoginAttempts();
                    return RedirectToAction("DojoActivities" ) ;
                }
                else {
                    ModelState.AddModelError("LoginDetail.Password", "Invalid Email/Password");
                    IncrementLogInattempts();
                    return View("Register");

                }
            }
        }
        ModelState.AddModelError("LoginDetail.Password", "Invalid Email/Password");
        IncrementLogInattempts();
        return View("Register");
        // return View("Register", user);
    }
    public  void SetLoggedInStatus(int SetUserID)
        {
            // Debug.Assert (SetUserID!=0);
            if (SetUserID>0) {
            HttpContext.Session.SetInt32("UserID", (int)SetUserID);
            }
        }
    private void IncrementLogInattempts() {
        int _LoginAttempts;
        _LoginAttempts=this.LoginAttempts;
        _LoginAttempts++;
        HttpContext.Session.SetInt32("LoginAttempts", (int)_LoginAttempts);

    }
    private void ClearLoginAttempts()
    {
        HttpContext.Session.Remove("LoginAttempts");
    }
    public int LoginAttempts {
        get {
                int? _LoginAttempts = HttpContext.Session.GetInt32("LoginAttempts");

            if (_LoginAttempts != null && _LoginAttempts >0)
            {
                return (int) _LoginAttempts;
            }
            return 0;
        }
    }
    public bool IsLoggedIn
    {  get {
            int? _UserID = HttpContext.Session.GetInt32("UserID");
            // Debug.Assert(_UserID!= null);
            if (_UserID == null) {return  false;}
            else  { return true;}
            }
    }
    //
    // L O G O U T
    [HttpGet("logout")]
    public string logout (){

        HttpContext.Session.Clear();
        return (IsLoggedIn ? "Still logged in..." : "Logged out");
    }
    /// G E T  L O G G E D   I N  U S E R
    public int LoggedInUserID
            {  get {
            int? _UserID = HttpContext.Session.GetInt32("UserID");
            // Debug.Assert(_UserID!= null);
            // Debug.Assert(_UserID!= 0);

            if (_UserID == null) {return  0;}
            else  { return (int) _UserID;}
            }
    }
    public IActionResult Privacy() => View();
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
// error///  crap
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
}
