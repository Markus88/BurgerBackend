namespace CrossTools.ExtensionTools
{
    public interface IModelMapper<in TFrom, out TTo>
    {
        TTo MapFromDomain(TFrom model);
    }
}