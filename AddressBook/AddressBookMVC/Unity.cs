using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBookMVC
{
    public class Unity
    {
        private static readonly IUnityContainer container = new UnityContainer().LoadConfiguration();

        private Unity() { }

        public static IUnityContainer Container
        {
            get { return container; }
        }
    }
}