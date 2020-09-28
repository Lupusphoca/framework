namespace PierreARNAUDET.Core.Holders.Models
{
    using Reinitializers;

    public interface IHolder : IReinitializable
    {
        object DefaultValue { get; }
        object Value { get; }
    }
}