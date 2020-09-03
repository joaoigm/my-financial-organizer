using api.Model;
using api.Repositories.Interfaces;

namespace api.Repositories.Repositories {
    public class ContaRepository : api.Repositories.Repository<Conta>, IContaRepository {
        public ContaRepository() : base("contas") {}
    }
}