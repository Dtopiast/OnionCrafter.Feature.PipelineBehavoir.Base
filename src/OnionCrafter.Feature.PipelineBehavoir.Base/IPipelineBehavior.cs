using OnionCrafter.Action.Request.Base;
using OnionCrafter.Action.Response.Base;
using OnionCrafter.Feature.PipelineBehavoir.Base.Option;
using OnionCrafter.Wrapper.Request.Base;
using OnionCrafter.Wrapper.Response.Base;

namespace OnionCrafter.Feature.PipelineBehavoir.Base
{
    /// <summary>
    /// Represents a feature pipeline behavior interface.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>

    public interface IPipelineBehavior<TRequest, TResponse, TResponseData, TRequestData> :
        IBasePipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseRequestSchema
        where TResponse : IBaseResponseSchema
        where TResponseData : class, IResponseData
        where TRequestData : class, IRequestData
    {

    }

    /// <summary>
    /// Represents a typed pipeline behavior with additional base pipeline behavior options.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    /// <typeparam name="TBasePipelineBehaviorOptions">The type of the base pipeline behavior options.</typeparam>

    public interface IPipelineBehavior<TRequest, TResponse, TResponseData, TRequestData, TBasePipelineBehaviorOptions> :
        IPipelineBehavior<TRequest, TResponse, TResponseData, TRequestData>,
        IBasePipelineBehavior<TRequest, TResponse, TBasePipelineBehaviorOptions>
        where TRequest : IBaseRequestSchema
        where TResponse : IBaseResponseSchema
        where TBasePipelineBehaviorOptions : class, IBasePipelineBehaviorOptions
        where TResponseData : class, IResponseData
        where TRequestData : class, IRequestData
    {

    }
}