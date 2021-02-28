using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace NotesApp
{
    public partial class ViewController : UIViewController
    {
        UICollectionView notesCollectionView;



        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            UIButton addButton = new UIButton();
            View.BackgroundColor = UIColor.White;
            addButton.TranslatesAutoresizingMaskIntoConstraints = false;
            addButton.SetTitle("Add", UIControlState.Normal);
            addButton.SetTitleColor(UIColor.SystemBlueColor, UIControlState.Normal);
            addButton.TouchUpInside += (sender, e) =>
            {
                AddViewController vc = new AddViewController();
                vc.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
                this.PresentViewController(vc, true, null);
            };

            DataService.sharedInstance.DataBaseChanged += onDataBaseChanged;
            DataService.sharedInstance.ItemDeleted += onDeletedItem;
            DataService.sharedInstance.ItemAdded += onAddedItem;

            notesCollectionView = new UICollectionView(new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width - 30, 300),
                                                       new CollectionGridFlowLayout());
            notesCollectionView.TranslatesAutoresizingMaskIntoConstraints = false;
            notesCollectionView.RegisterClassForCell(typeof(NoteCell), NoteCell.NoteCellID);
            notesCollectionView.BackgroundColor = UIColor.White;
            notesCollectionView.AlwaysBounceVertical = true;

            DataService.DataAccess();

            notesCollectionView.DataSource = new NotesCollectionViewDataSource();
            notesCollectionView.Delegate = new NotesCollectionViewDelegate(this);
            notesCollectionView.ShowsHorizontalScrollIndicator = false;
            notesCollectionView.RegisterClassForSupplementaryView(typeof(NotesCollectionViewHeader), UICollectionElementKindSection.Header, NotesCollectionViewHeader.HeaderID);

            View.AddSubview(notesCollectionView);
            View.AddSubview(addButton);

            notesCollectionView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            notesCollectionView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            notesCollectionView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            notesCollectionView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;


            addButton.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor, -10).Active = true;
            addButton.TopAnchor.ConstraintEqualTo(View.TopAnchor, 30).Active = true;
            addButton.WidthAnchor.ConstraintEqualTo(100).Active = true;
            addButton.HeightAnchor.ConstraintEqualTo(30).Active = true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void onDataBaseChanged(object source, EventArgs e)
        {
            //TODO
        }

        public void onDeletedItem(object source, DataServiceArgs e)
        {
            notesCollectionView.ReloadData();
        }
        public void onAddedItem(object source, DataServiceArgs e)
        {
            notesCollectionView.ReloadData();
        }
    }    
}