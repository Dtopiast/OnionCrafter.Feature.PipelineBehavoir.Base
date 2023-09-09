using OnionCrafter.Feature.PipelineBehavoir.Base.Handler;
using OnionCrafter.Feature.PipelineBehavoir.Base.Option;
using OnionCrafter.Service.Base;
using OnionCrafter.Service.Option.Base;
using OnionCrafter.Wrapper.Request.Base;
using OnionCrafter.Wrapper.Response.Base;

namespace OnionCrafter.Feature.PipelineBehavoir.Base
{
    /// <summary>
    /// Interface representing a Base Feature Pipeline Behavior.
    /// </summary>
    public interface IBasePipelineBehavior : IBasePipelineBehavoirExecutionHandler, IBaseService
    {
    }

    /// <summary>
    /// Interface representing a Base Feature Pipeline Behavior with specific request and response types .
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IBasePipelineBehavior<TRequest, TResponse> :
        IBasePipelineBehavior,
        IPipelineBehavoirExecutionHandler<TRequest, TResponse>
        where TRequest : IBaseRequestSchema
        where TResponse : IBaseResponseSchema
    {
    }

    /// <summary>
    /// Interface representing a Base Feature Pipeline Behavior with specific request, response types and options.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TBasePipelineBehaviorOptions">The type of the options.</typeparam>
    public interface IBasePipelineBehavior<TRequest, TResponse, TBasePipelineBehaviorOptions> :
        IBasePipelineBehavior<TRequest, TResponse>,
        IBaseServiceOptions
        where TRequest : IBaseRequestSchema
        where TResponse : IBaseResponseSchema
        where TBasePipelineBehaviorOptions : class, IBasePipelineBehaviorOptions
    {
    }
}