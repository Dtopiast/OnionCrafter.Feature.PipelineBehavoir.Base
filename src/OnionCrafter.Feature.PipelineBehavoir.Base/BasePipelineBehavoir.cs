using MediatR;
using OnionCrafter.Action.Request.Base;
using OnionCrafter.Action.Response.Base;
using OnionCrafter.Wrapper.Request.Base;
using OnionCrafter.Wrapper.Response.Base;
using OnionCrafter.Feature.PipelineBehavoir.Base.Option;
using Microsoft.Extensions.Options;
using OnionCrafter.Service.Base;

namespace OnionCrafter.Feature.PipelineBehavoir.Base
{
    /// <summary>
    /// Represents a base typed pipeline behavior.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    public abstract class BasePipelineBehavior<TRequest, TResponse, TResponseData, TRequestData> :
        BaseService,
        IPipelineBehavior<TRequest, TResponse, TResponseData, TRequestData>
        where TRequest : IRequestSchema<string, TResponse, TResponseData, TRequestData>
        where TResponse : IResponseSchema<string, TResponseData>
        where TResponseData : class, IResponseData
        where TRequestData : class, IRequestData
    {
        /// <summary>
        /// Gets the name of the pipeline behavoir.
        /// </summary>
        public new string Name { get; protected set; }

        /// <summary>
        /// The response instance.
        /// </summary>
        protected TResponse _response;

        /// <summary>
        /// The request instance.
        /// </summary>
        protected TRequest _request;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePipelineBehavior{TRequest, TResponse, TResponseData, TRequestData}"/> class.
        /// </summary>
        protected BasePipelineBehavior() : base()
        {
            _response = Activator.CreateInstance<TResponse>();
            _request = Activator.CreateInstance<TRequest>();
            Name = GetType().Name;
        }

        /// <summary>
        /// Handles the request in the pipeline.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <param name="next">The delegate representing the next handler in the pipeline.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The response after handling the request.</returns>
        public virtual async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _request = request;
            await OnAfterExecuteAsync(cancellationToken);
            _response = await next();
            await OnBeforeExecuteAsync(cancellationToken);
            return _response;
        }

        /// <summary>
        /// Executes actions after request execution.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task OnAfterExecuteAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Executes actions before request execution.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        public virtual async Task OnBeforeExecuteAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Clones the current instance of the pipeline behavior.
        /// </summary>
        /// <typeparam name="TReturn">The type of the cloned instance.</typeparam>
        /// <returns>The cloned instance.</returns>
        public virtual new TReturn Clone<TReturn>() where TReturn : IBaseService
        {
            return (TReturn)MemberwiseClone();
        }
    }

    /// <summary>
    /// Represents a base feature pipeline behavior with additional options.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <typeparam name="TResponseData">The type of the response data.</typeparam>
    /// <typeparam name="TRequestData">The type of the request data.</typeparam>
    /// <typeparam name="TPipelineBehaviorOptions">The type of the pipeline behavior options.</typeparam>
    public abstract class BaseFeaturePipelineBehavior<TRequest, TResponse, TResponseData, TRequestData, TPipelineBehaviorOptions> :
        BasePipelineBehavior<TRequest, TResponse, TResponseData, TRequestData>,
        IPipelineBehavior<TRequest, TResponse, TResponseData, TRequestData, TPipelineBehaviorOptions>
        where TRequest : IRequestSchema<string, TResponse, TResponseData, TRequestData>
        where TPipelineBehaviorOptions : class, IPipelineBehaviorOptions
        where TResponse : IResponseSchema<string, TResponseData>
        where TResponseData : class, IResponseData
        where TRequestData : class, IRequestData
    {
        /// <summary>
        /// Stores the configuration for the service.
        /// </summary>
        protected readonly TPipelineBehaviorOptions _pipelineBehaviorOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFeaturePipelineBehavior{TRequest, TResponse, TResponseData, TRequestData, TPipelineBehaviorOptions}"/> class.
        /// </summary>
        /// <param name="options">The options for the pipeline behavior.</param>
        protected BaseFeaturePipelineBehavior(IOptionsMonitor<TPipelineBehaviorOptions> options)
        {
            _pipelineBehaviorOptions = options.Get(Name);
            // Name = _pipelineBehaviorOptions.PipelineName ?? Name;
        }
    }
}