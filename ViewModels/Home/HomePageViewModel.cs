using aspnet_mvc_ef_codefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc_ef_codefirst.ViewModels.Home
{
    public class HomePageViewModel
    {
        public List <Kisiler> Kisiler {get; set;}
        public List<Adresler> Adresler { get; set; }
      }
}