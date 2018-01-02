using System;

using UIKit;

using BranchXamarinSDK;

namespace xamarintestvisual.iOS
{
    public partial class ViewController : UIViewController, IBranchLinkShareInterface
    {
        partial void Share_TouchUpInside(UIButton sender)
        {
            BranchUniversalObject universalObject = null;
            BranchLinkProperties linkProperties = null;
            string baseImageUrl = @"https://s3-us-west-2.amazonaws.com/triipmates-users-pictures/kazoku.jpg";

            if (universalObject == null)
            {
                universalObject = new BranchUniversalObject();
                universalObject.canonicalIdentifier = "1000";
                universalObject.title = "Kazoku";
                universalObject.contentDescription = "Food and Drinks";
                universalObject.imageUrl = baseImageUrl;
            }


            if (linkProperties == null)
            {

                linkProperties = new BranchLinkProperties();
                linkProperties.tags.Add("tag1");
                linkProperties.tags.Add("tag2");
                linkProperties.feature = "sharing";
                linkProperties.channel = "facebook";
                linkProperties.controlParams.Add("$desktop_url", "http://example.com");
                linkProperties.controlParams.Add("$uri_redirect_mode", "2");

            }

            BranchIOS.GetInstance().ShareLink(this, universalObject, linkProperties, "hello there with short url");
        }

        public void ChannelSelected(string channel)
        {
            //LogMessage ("Branch.shareLink channel selected: " + channel);
        }

        public void LinkShareResponse(string sharedLink, string sharedChannel)
        {
            //LogMessage ("Branch.shareLink response from: " + sharedChannel + " " + sharedLink);
        }

        public void LinkShareRequestError(BranchError error)
        {
            //LogMessage ("Branch.shareLink failed: " + error.ErrorCode);
            //LogMessage (error.ErrorMessage);

            UIAlertView errorAlert = new UIAlertView("Error in LinkShareRequestError", error.ErrorMessage, null, "OK", null);
            errorAlert.Show();

        }

        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
