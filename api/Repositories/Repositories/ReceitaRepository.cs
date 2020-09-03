using api.Model;
using api.Repositories.Interfaces;

namespace api.Repositories.Repositories {
    public class ReceitaRepository : api.Repositories.Repository<Receita>, IReceitaRepository {
        public ReceitaRepository() : base("receitas") {}
    }
}