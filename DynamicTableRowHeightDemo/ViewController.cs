using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace DynamicTableRowHeightDemo
{
    public partial class ViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate
    {
        private CellModel[] dataSource;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
	        base.ViewDidLoad();

            MyTableView.DataSource = this;
            MyTableView.Delegate = this;
            MyTableView.RegisterNibForCellReuse(MyTableViewCell.Nib, MyTableViewCell.Key);

            // make some data
            var models = new List<CellModel>();
            for (var i = 0; i < 50; i++)
            {
                models.Add(new CellModel { Notes = "No T.V. and no beer make Homer something something." });
            }
            dataSource = models.ToArray();
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(MyTableViewCell.Key, indexPath) as MyTableViewCell;

            cell.SetupCell(dataSource[indexPath.Row], () =>
                tableView.ReloadRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic));

            return cell;
        }

        [Export("tableView:heightForRowAtIndexPath:")]
        public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return dataSource[indexPath.Row].ShouldDisplayNotes
                ? MyTableViewCell.ExpandedHeight
                : MyTableViewCell.NormalHeight;
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return dataSource.Length;
        }
    }

    public class CellModel
    {
        public string Notes { get; set; }

        public bool ShouldDisplayNotes { get; set; }
    }
}
