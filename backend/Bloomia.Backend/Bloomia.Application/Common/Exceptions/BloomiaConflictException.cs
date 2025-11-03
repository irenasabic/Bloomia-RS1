namespace Bloomia.Application.Common.Exceptions;

public sealed class BloomiaConflictException : Exception
{
    public BloomiaConflictException(string message) : base(message) { }
}
