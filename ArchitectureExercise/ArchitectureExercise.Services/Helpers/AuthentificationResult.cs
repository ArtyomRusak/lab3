using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureExercise.Services.Helpers
{
    /// <summary>
    /// This class give us an ability to know about wrong email or wrong password and show this information to user.
    /// </summary>
    public class AuthentificationResult
    {
        public bool Email { get; set; }
        public bool Password { get; set; }
        public bool Result { get; set; }

        public void Calculate()
        {
            Result = Email && Password;
        }
    }
}
