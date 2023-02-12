namespace SubUtilities;

public interface IAction
{
    Task Apply(ActionContext context);
}