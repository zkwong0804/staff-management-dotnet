namespace StaffManagement.Web.Errors
{
    public class InvalidProcessException : Exception
    {
        public InvalidProcessException(string message) : base(message)
        {

        }
        public InvalidProcessException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
