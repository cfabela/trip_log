using System;
using Foundation;
using TripLog.Controls;
using TripLog.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(DatePickerEntryCell),
                          typeof(DatePickerEntryCellRender))]
namespace TripLog.iOS.Renders
{
    public class DatePickerEntryCellRender : EntryCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var datepickerCell = (DatePickerEntryCell)item;
            UITextField textField = null;

            if (cell != null)
            {
                textField = (UITextField)cell.ContentView.Subviews[0];
            }

            var mode = UIDatePickerMode.Date;
            var displayFormat = "d";
            var date = NSDate.Now;
            var isLocalTime = false;

            if (datepickerCell != null)
            {
                if (datepickerCell.Date.Kind == DateTimeKind.Unspecified)
                {
                    var local = new DateTime(datepickerCell.Date.Ticks,
                        DateTimeKind.Local);
                    date = local.ToNSDate();
                }
                else
                {
                    date = datepickerCell.Date.ToNSDate();
                }

                isLocalTime = datepickerCell.Date.Kind == DateTimeKind.Local
                    || datepickerCell.Date.Kind == DateTimeKind.Unspecified;

                //Create ios datepicker
                var datepicker = new UIDatePicker
                {
                    Mode = mode,
                    BackgroundColor = UIColor.White,
                    Date = date,
                    TimeZone = isLocalTime
                    ? NSTimeZone.LocalTimeZone : new NSTimeZone("UTC")
                };

                var done = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
                    (s, e) =>
                    {
                        var pickedDate = (DateTime)datepicker.Date;
                        if (isLocalTime)
                        {
                            pickedDate = pickedDate.ToLocalTime();
                        }

                        if (textField != null)
                        {
                            textField.Text = pickedDate.ToString(displayFormat);
                            textField.ResignFirstResponder();
                        }

                        if (datepickerCell != null)
                        {
                            datepickerCell.Date = pickedDate;
                            datepickerCell.SendCompleted();
                        }
                    });

                var toolbar = new UIToolbar
                {
                    BarStyle = UIBarStyle.Default,
                    Translucent = false
                };

                toolbar.SizeToFit();
                toolbar.SetItems(new[] { done }, true);

                if (textField != null)
                {
                    textField.InputView = datepicker;
                    textField.InputAccessoryView = toolbar;

                    if (datepickerCell != null)
                    {
                        textField.Text = datepickerCell.Date.ToString(displayFormat);
                    }
                }
            }

            return cell;
        }
    }
}


public static class Extension
{
    public static DateTime ToDateTime(this NSDate nsDate)
    {
        // We loose granularity below millisecond range but that is probably ok
        return nsRef.AddSeconds(nsDate.SecondsSinceReferenceDate);
    }

    private static DateTime nsRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Local); // last zero is milliseconds
}
