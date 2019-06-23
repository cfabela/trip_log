using System.Collections.Generic;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace TripLog.Droid.Tools
{
    public static class PermissionTools
    {
        public static bool CheckPermission(this Context context, string[] permissions, int requestCode)
        {
            if (!permissions.Any()) return false;
            var activity = (Activity)Forms.Context;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var permissionCheck = context.CheckSelfPermission(permissions[0]);
                if (permissionCheck == Permission.Denied)
                {
                    activity.RequestPermissions(permissions, requestCode);
                    return false;
                }
            }

            return true;
        }
    }
}