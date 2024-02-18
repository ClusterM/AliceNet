namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Значение именованной сущности.
    /// </summary>
    public interface IEntityValue
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        public IEntity.EntityTypes EntityType { get; }
    }
}