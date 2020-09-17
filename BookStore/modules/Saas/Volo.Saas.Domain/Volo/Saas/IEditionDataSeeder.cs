using System.Threading.Tasks;

namespace Volo.Saas
{
    public interface IEditionDataSeeder
	{
		Task CreateStandardEditionsAsync();
	}
}
