public interface ITransformation
{
    Task Apply(TransformationContext context);
}