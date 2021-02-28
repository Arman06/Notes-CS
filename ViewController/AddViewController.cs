using System;
using UIKit;
using Foundation;

namespace NotesApp
{
    public class AddViewController:UIViewController
    {
        UITextField titleTextField;
        UITextField contentsTextField;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            ResignFirstResponderOnTap(View);

            UIButton backButton = new UIButton();
            View.BackgroundColor = UIColor.White;
            backButton.TranslatesAutoresizingMaskIntoConstraints = false;
            backButton.SetTitle("Back", UIControlState.Normal);
            backButton.SetTitleColor(UIColor.SystemBlueColor, UIControlState.Normal);
            backButton.TouchUpInside += (sender, e) =>
            {
                this.DismissViewController(true, null);
            };

            UIButton addButton = new UIButton();
            View.BackgroundColor = UIColor.White;
            addButton.TranslatesAutoresizingMaskIntoConstraints = false;
            addButton.SetTitle("Add", UIControlState.Normal);
            addButton.SetTitleColor(UIColor.SystemBlueColor, UIControlState.Normal);
            addButton.TouchUpInside += (sender, e) =>
            {
                DataService.AddNote(new Note { Title = titleTextField.Text, Contents = contentsTextField.Text });
                Console.WriteLine(titleTextField.Text + " " + contentsTextField.Text);
                this.DismissViewController(true, null);
            };

            titleTextField = new UITextField();
            titleTextField.Delegate = new InputTextField();
            titleTextField.Placeholder = "Title";
            titleTextField.TranslatesAutoresizingMaskIntoConstraints = false;

            contentsTextField = new UITextField();
            contentsTextField.Delegate = new InputTextField();
            contentsTextField.Placeholder = "Write your note here";
            contentsTextField.TranslatesAutoresizingMaskIntoConstraints = false;

            View.AddSubview(backButton);
            View.AddSubview(titleTextField);
            View.AddSubview(addButton);
            View.AddSubview(contentsTextField);

            backButton.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            backButton.TopAnchor.ConstraintEqualTo(View.TopAnchor, 30).Active = true;
            backButton.WidthAnchor.ConstraintEqualTo(50).Active = true;
            backButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

            addButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
            addButton.TopAnchor.ConstraintEqualTo(View.TopAnchor, 30).Active = true;
            addButton.WidthAnchor.ConstraintEqualTo(50).Active = true;
            addButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

            titleTextField.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            titleTextField.HeightAnchor.ConstraintEqualTo(30).Active = true;
            titleTextField.TopAnchor.ConstraintEqualTo(backButton.BottomAnchor, 20).Active = true;
            titleTextField.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;

            contentsTextField.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor, 10).Active = true;
            contentsTextField.HeightAnchor.ConstraintEqualTo(30).Active = true;
            contentsTextField.TopAnchor.ConstraintEqualTo(titleTextField.BottomAnchor, 20).Active = true;
            contentsTextField.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
        }

        public void ResignFirstResponderOnTap(UIView view)
        {
            var gest = new UITapGestureRecognizer(() =>
            {
                view.EndEditing(true);
            });
            gest.CancelsTouchesInView = false;
            view.AddGestureRecognizer(gest);
        }
    }

    class InputTextField: UITextFieldDelegate
    {

    }
}
