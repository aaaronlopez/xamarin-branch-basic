﻿using Android.App;
using Android.Widget;
using Android.OS;
using BranchXamarinSDK;
using System;
using System.Collections.Generic;
using Android.Content;
using Newtonsoft.Json;

namespace xamarintestvisual.Droid
{
	[Activity(Label = "TestAndroidApp", MainLauncher = true, Icon = "@mipmap/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleTask)]

	[IntentFilter(new[] { "android.intent.action.VIEW" },
	Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
	DataScheme = "aaron-xamarin",
	DataHost = "open")]

	[IntentFilter(new[] { "android.intent.action.VIEW" },
	Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
	DataScheme = "https",
	DataHost = "jpvd.app.link")]

	public class MainActivity : Activity, IBranchSessionInterface
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

            Console.WriteLine("INITINITINIT");
			BranchAndroid.Init(this, Resources.GetString(Resource.String.branch_key), this);
		}

		// Ensure we get the updated link identifier when the app becomes active
		// due to a Branch link click after having been in the background
		protected override void OnNewIntent(Intent intent)
		{
			this.Intent = intent;
		}

		public void InitSessionComplete(Dictionary<string, object> data)
		{
			var intent = new Intent(this, typeof(BranchActivity));
			intent.PutExtra("BranchData", JsonConvert.SerializeObject(data));

            Console.WriteLine("DATADATADATA: " + JsonConvert.SerializeObject(data));
            //LogMessage("DATATATATTATTA: ");

			StartActivity(intent);
		}

		public void SessionRequestError(BranchError error)
		{
			Console.WriteLine("Branch session initialization error: " + error.ErrorCode);
			Console.WriteLine(error.ErrorMessage);

			var intent = new Intent(this, typeof(BranchErrorActivity));
			intent.PutExtra("ErrorCode", error.ErrorCode);
			intent.PutExtra("ErrorMessage", error.ErrorMessage);

			StartActivity(intent);
		}
	}
}

