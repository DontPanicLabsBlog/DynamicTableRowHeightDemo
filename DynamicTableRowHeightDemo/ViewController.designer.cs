// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace DynamicTableRowHeightDemo
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView MyTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MyTableView != null) {
				MyTableView.Dispose ();
				MyTableView = null;
			}
		}
	}
}
