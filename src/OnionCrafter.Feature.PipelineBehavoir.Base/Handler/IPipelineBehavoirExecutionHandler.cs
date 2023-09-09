using MediatR;
using OnionCrafter.Util.Object.Pattern.TempleteMethod;
using OnionCrafter.Wrapper.Request.Base;
using OnionCrafter.Wrapper.Response.Base;

namespace OnionCrafter.Feature.PipelineBehavoir.Base.Handler
{
    /// <summary>
    /// Represents an interface for a pipeline behavior execution handler.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request schema.</typeparam>
    /// <typeparam name="TResponse">The type of the response schema.</typeparam>
    public interface IPipelineBehavoirExecutionHandler<TRequest, TResponse> :
        IExecutionHandler,
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseRequestSchema
        where TResponse : IBaseResponseSchema
    {
        /// <summary>
        /// Handles the pipeline behavior for a request.
        /// </summary>
        /// <param name="request">The request schema.</param>
        /// <param name="next">The delegate to invoke the next behavior in the pipeline.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response schema.</returns>
        public abstract new Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken);
    }
}