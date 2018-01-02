using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using BranchXamarinSDK;

namespace xamarintestvisual.Droid
{
	[Application(AllowBackup = true, Icon = "@mipmap/icon", Label = "@string/app_name")]
	[MetaData("io.branch.sdk.auto_link_disable", Value = "false")]
	[MetaData("io.branch.sdk.TestMode", Value = "true")]
    [MetaData("io.branch.sdk.BranchKey", Value = "key_live_bjrJcLZjIEXYHX61jgg4ZojlxygdIyWe")]

	public class TestAndroidApp : Application
	{
		public TestAndroidApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();
			BranchAndroid.GetAutoInstance(this.ApplicationContext);
		}
	}
}
