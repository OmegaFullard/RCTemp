//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Microsoft.Owin.Security;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;


//namespace RCTemp
//{
//    public class ApplicationUser : IdentityUser, IUser<string>
//    {
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Address { get; set; }
//        public string Address2 { get; set; }
//        public string City { get; set; }
//        public string State { get; set; }
//        public string ZipCode { get; set; }

//        string IUser<string>.Id => throw new NotImplementedException();

//        string IUser<string>.UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        //public new string UserName { get; internal set; }
//        //public new string Email { get; internal set; }
//        //public new string PhoneNumber { get; internal set; }

//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
//        {
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            return userIdentity;
//        }
//    }

//    public class ApplicationDbContext : IdentityDbContext
//    {
//        public ApplicationDbContext()
//            : base("DefaultConnection")
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }

//    public class ApplicationUserManager : UserManager<ApplicationUser>
//    {
//        public ApplicationUserManager(IUserStore<ApplicationUser> store)
//            : base(store)
//        {
//        }

//        //    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
//        //    {
//        //        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

//        //        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
//        //        {
//        //            AllowOnlyAlphanumericUserNames = false,
//        //            RequireUniqueEmail = true
//        //        };

//        //        manager.PasswordValidator = new PasswordValidator
//        //        {
//        //            RequiredLength = 6,
//        //            RequireNonLetterOrDigit = false,
//        //            RequireDigit = false,
//        //            RequireLowercase = false,
//        //            RequireUppercase = false,
//        //        };

//        //        manager.UserLockoutEnabledByDefault = true;
//        //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
//        //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

//        //        return manager;
//        //    }
//        //}

//        public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
//        {
//            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
//                : base(userManager, authenticationManager)
//            {
//            }

//            public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
//            {
//                return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
//            }

//            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
//            {
//                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
//            }
//        }
//    }
//}