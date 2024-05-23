namespace Susurri.Core.Exceptions;

public sealed class NullOptionsException() : CustomException("Options or Options.Value is not set.");