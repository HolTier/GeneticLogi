namespace GeneticLogi_CostService.Services.GeneticAlgorithm
{
    public abstract class GeneticAlgorithm
    {
        // Template method
        public double RunAlgorithm()
        {
            InitializePopulation();
            EvaluatePopulation();

            for (int i = 0; i < GetMaxIterations(); i++)
            {
                SelectPopulation();
                CrossoverPopulation();
                MutatePopulation();
                EvaluatePopulation();
            }

            return GetBestSolution();
        }

        protected abstract void InitializePopulation();
        protected abstract int GetMaxIterations();
        protected abstract void EvaluatePopulation();
        protected abstract void SelectPopulation();
        protected abstract void CrossoverPopulation();
        protected abstract void MutatePopulation();
        protected abstract double GetBestSolution();
    }
}
