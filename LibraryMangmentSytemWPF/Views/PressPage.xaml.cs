﻿using LibraryMangmentSytemWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryMangmentSytemWPF.Views
{
	/// <summary>
	/// Interaction logic for PressPage.xaml
	/// </summary>
	public partial class PressPage : Page
	{
		public PressPage()
		{
			InitializeComponent();
			CurrentPage=this;
			CurrentPage.DataContext=new PressViewModel();
		}
		private Page currentPage;

		public Page CurrentPage { get => currentPage; set { currentPage = value; } }
	}
}
