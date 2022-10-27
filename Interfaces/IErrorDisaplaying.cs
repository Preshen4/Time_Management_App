namespace Time_Management_App.Interfaces
{
    interface IErrorDisaplaying
    {
        void ClearErrors();
        void DisplayErrors(string propertyName, string errorMessage);
    }
}
