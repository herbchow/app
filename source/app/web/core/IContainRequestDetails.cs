namespace app.web.core
{
    public interface IContainRequestDetails
    {
        InputModel map<InputModel>();
        string get_view_name();
        string get_action();
        string get_parameter_by_name(string name);
    }
}