namespace Bloomia.Application.Common.Exceptions;

public sealed class BloomiaNotFoundException : Exception
{
    public BloomiaNotFoundException(string message) : base(message) { }
}
