namespace XmlParser.OperationResults;

public abstract record OperationExecutionResult
{
    public sealed record Success() : OperationExecutionResult;
    public sealed record Unsuccess(string FailReason) : OperationExecutionResult;
}