using System.Linq;

namespace App.Repository.Interface
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retorna um IQuerable que é usado para trazer todas as entidades da tabela
        /// </summary>
        /// <returns>IQueryable usado para selecionar entidades do banco de dados</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Retorna uma entidade pelo ID passado.
        /// </summary>
        /// <param name="key">Chave primária de uma entidade para ser retornada</param>
        /// <returns>Entity</returns>
        TEntity Get(int key);

        /// <summary>
        /// Inseri uma entidade no banco de dados.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Atualiza uma entidade existente.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deleta a entidade.
        /// </summary>
        /// <param name="id">Id da entidade</param>
        void Delete(TEntity obj);
    }
}
