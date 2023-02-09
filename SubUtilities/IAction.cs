public interface IAction
{
    Task Apply(ActionContext context);
}