using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.DAL;
using GameX.Models;
using GameX.ViewModel;

namespace GameX.Infrastructure
{
    //public class UserManager : IUser
    //{
    //    private readonly StoreContext context;

    //    public UserManager(StoreContext context)
    //    {
    //        this.context = context;
    //    }

    //    public void Login(LoginViewModel User)
    //    {

    //        Users user = context.Users.FirstOrDefault(x => x.Username == User.Username);

    //        try
    //        {
                
    //        }

    //        catch(Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    public bool SignUp(SignUpViewModel SignUp)
    //    {
            
    //        if (context.Users.Any(x => (x.Username == SignUp.Username) == true))
    //        {
    //            return false;
    //        }
            
    //        Users User = new Users
    //        {
    //            Name = SignUp.Name,
    //            Surname = SignUp.Surname,
    //            Email = SignUp.Email,
    //            Username = SignUp.Username,
    //            Password = SignUp.Password
    //        };

    //        try { 
    //            context.Users.Add(User);
    //            context.SaveChanges();
    //            return true;
    //        }

    //        catch(Exception ex)
    //        {
    //            throw;
    //        }

    //        return false;
    //    }

    //    public void Delete(int UserId)
    //    {
    //        Users User = context.Users.FirstOrDefault(x => x.UserId == UserId);

    //        try
    //        {
    //            context.Users.Remove(User);
    //        }

    //        catch(Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    public bool Edit(SignUpViewModel User)
    //    {
    //        /*if (context.Users.Any(x => (x.UserId == User.UserId) == false))
    //        {
    //            return false;
    //        }*/
            

    //        Users Updated = new Users
    //        {
    //            Name = User.Name,
    //            Surname = User.Surname,
    //            Email = User.Email,
    //            Username = User.Username,
    //            Password = User.Password,
    //            UserId= User.UserId,
    //        };

    //        try
    //        {
    //            context.Users.Update(Updated);
    //            context.SaveChanges();
    //            return true;
    //        }

    //        catch (Exception ex)
    //        {
    //            return false;
    //            throw;
    //        }
    //    }




    }
