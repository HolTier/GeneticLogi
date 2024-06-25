namespace GeneticLogi_CostService.Services
{
    public interface ICostService
    {
        public Task<double> RunAlgorithmAsync(int maxIterations);
    }
}
