﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MVCHWpf.ViewModels;
using MVCHWpf.ViewModels.Persons.PatientViewModels;
using MVCHWpf.ViewModels.Persons.PhysicianViewModels;
using Servicelayer.AssociativeClassService;
using Servicelayer.BaseClassService;

namespace MVCHWpf.Views.PhysicianViews
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditPhysicianView : Window
    {
        private AddPhysicianViewModel _toAddPhysician;
        private string _patientType;
        public EditPhysicianView()
        {
            InitializeComponent();

        }

        public EditPhysicianView(PhysicianListViewModel physicianListViewModel,
            PhysicianService physicianService,
            PhysicianSpecialtyService physicianSpecialtyService,
            SpecialtyService specialtyService,
            FacilityService facilityService,
            FacilityPhysicianService facilityPhysicianService)
        {
            InitializeComponent();
            _toAddPhysician = new AddPhysicianViewModel(physicianListViewModel,
                physicianService,
                facilityService,
                specialtyService,
                physicianSpecialtyService,
                facilityPhysicianService);
            DataContext = _toAddPhysician;
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _toAddPhysician.Add();
            Close();
        }


    }
}
