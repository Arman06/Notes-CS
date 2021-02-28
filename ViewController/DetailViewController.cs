using System;
using UIKit;
using Foundation;

namespace NotesApp
{
    public class DetailViewController: UIViewController
    {
        public Note data;
        public NSIndexPath indexPath;



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIButton backButton = new UIButton();
            View.BackgroundColor = UIColor.White;
            backButton.TranslatesAutoresizingMaskIntoConstraints = false;
            backButton.SetTitle("Back", UIControlState.Normal);
            backButton.SetTitleColor(UIColor.SystemBlueColor, UIControlState.Normal);
            backButton.TouchUpInside += (sender, e) =>
            {
                this.DismissViewController(true, null);
            };

            UIButton deleteButton = new UIButton();
            View.BackgroundColor = UIColor.White;
            deleteButton.TranslatesAutoresizingMaskIntoConstraints = false;
            deleteButton.SetTitle("Delete", UIControlState.Normal);
            deleteButton.SetTitleColor(UIColor.SystemRedColor, UIControlState.Normal);
            deleteButton.TouchUpInside += (sender, e) =>
            {
                DataService.DeleteNote(data, indexPath);
                this.DismissViewController(true, null);
            };

            UILabel titleLabel = new UILabel();
            titleLabel.Text = data.Title;
            titleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            titleLabel.Font = UIFont.BoldSystemFontOfSize(17);

            UITextView contentsTextView = new UITextView();
            contentsTextView.Text = data.Contents;
            contentsTextView.TranslatesAutoresizingMaskIntoConstraints = false;
            contentsTextView.TextAlignment = UITextAlignment.Left;

            View.AddSubview(backButton);
            View.AddSubview(titleLabel);
            View.AddSubview(contentsTextView);
            View.AddSubview(deleteButton);

            backButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            backButton.TopAnchor.ConstraintEqualTo(View.TopAnchor, 20).Active = true;
            backButton.WidthAnchor.ConstraintEqualTo(60).Active = true;
            backButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

            titleLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            titleLabel.TopAnchor.ConstraintEqualTo(backButton.TopAnchor, 30).Active = true;
            titleLabel.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            titleLabel.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
            titleLabel.HeightAnchor.ConstraintEqualTo(50).Active = true;

            contentsTextView.TopAnchor.ConstraintEqualTo(titleLabel.BottomAnchor, 5).Active = true;
            contentsTextView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            contentsTextView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
            contentsTextView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;

            deleteButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
            deleteButton.TopAnchor.ConstraintEqualTo(View.TopAnchor, 20).Active = true;
            deleteButton.WidthAnchor.ConstraintEqualTo(100).Active = true;
            deleteButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

        }


    }
}
