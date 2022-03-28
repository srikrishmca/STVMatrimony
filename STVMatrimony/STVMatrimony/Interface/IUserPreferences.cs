namespace STVMatrimony.Interface
{
    public interface IUserPreferences
    {
        void SetValue(string key, string value);
        string GetValue(string key);
        void ClearPreferencesValueAndKey();
    }
}
