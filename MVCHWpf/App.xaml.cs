﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Datalayer.EFClasses;

namespace MVCHWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense($"MjI4MzM0QDMxMzcyZTM0MmUzMGErRUtwMUZYcFJmZDlqRk83TXlhdDNxVmM2ckNra2xnMml4QXZnSktpRHc9");
        }
        
    }
}
