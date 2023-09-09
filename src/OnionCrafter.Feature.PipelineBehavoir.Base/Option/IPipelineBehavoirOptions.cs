namespace OnionCrafter.Feature.PipelineBehavoir.Base.Option
{
    /// <summary>
    /// Represents options for a pipeline behavior.
    /// </summary>
    public interface IPipelineBehaviorOptions : IBasePipelineBehaviorOptions
    {
        /// <summary>
        /// The pipeline name.
        /// </summary>
        public string PipelineName { get; set; }
    }
}