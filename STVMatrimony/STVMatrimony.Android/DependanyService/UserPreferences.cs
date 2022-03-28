using Android.App;
using Android.Content;
[assembly: Xamarin.Forms.Dependency(typeof(STVMatrimony.Droid.DependanyService.UserPreferences))]
namespace STVMatrimony.Droid.DependanyService
{
    public class UserPreferences : STVMatrimony.Interface.IUserPreferences
    {
        public UserPreferences()
        {

        }
        public void ClearPreferencesValueAndKey()
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("STVMatrimonyPreferences", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            //   edit.Remove(key);
            edit.Clear();
            edit.Commit();

        }

        public string GetValue(string key)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("STVMatrimonyPreferences", FileCreationMode.Private);
            string value = pref.GetString(key, string.Empty);
            return value;
        }

        public void SetValue(string key, string value)
        {
            ISharedPreferences pref = Application.Context.GetSharedPreferences("STVMatrimonyPreferences", FileCreationMode.Private);
            ISharedPreferencesEditor edit = pref.Edit();
            edit.PutString(key, value);
            edit.Apply();
            edit.Commit();
        }
    }
}