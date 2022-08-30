namespace IWantApp.ViewModels;

public class ResultViewModel<T>
{
    public ResultViewModel(T data, IList<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public ResultViewModel(T data)
    {
        Data = data;
    }

    public ResultViewModel(IList<string> errors)
    {
        Errors = errors;
    }

    public ResultViewModel(string error)
    {
        Errors.Add(error);
    }

    public T Data { get; private set; }
    public IList<string> Errors { get; private set; } = new List<string>();
}