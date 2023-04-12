using c971_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c971_project.Data
{
    public interface ITermProvider
    {
        Task<Term> GetTermAsync(int termId);
        Task<List<Term>> GetTermsAsync();
    }
}
