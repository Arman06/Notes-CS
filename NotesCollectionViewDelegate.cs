using System;
using UIKit;
using Foundation;
namespace NotesApp
{
    public class NotesCollectionViewDelegate : UICollectionViewDelegate
    {
        UIViewController currentContoller;

        public NotesCollectionViewDelegate(UIViewController vc)
        {
            currentContoller = vc;
        }

        [Export("collectionView:didSelectItemAtIndexPath:")]
        public void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var noteCell = (NoteCell)collectionView.DequeueReusableCell(NoteCell.NoteCellID, indexPath);
            var vc = new DetailViewController();
            var data = new DataService();
            vc.data = DataService.sharedInstance.notes[indexPath.Row];
            vc.indexPath = indexPath;
            vc.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;
            currentContoller.PresentViewController(vc, true, null);
        }
    }
}
