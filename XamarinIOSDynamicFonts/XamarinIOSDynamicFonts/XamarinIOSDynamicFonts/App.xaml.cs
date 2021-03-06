﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinIOSDynamicFonts
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            DependencyService.Get<IFontLoader>()?.LoadFile("FontAwesome.ttf");
            DependencyService.Get<IFontLoader>()?.LoadFile("Mina-Regular.ttf");

            MainPage = new XamarinIOSDynamicFonts.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
