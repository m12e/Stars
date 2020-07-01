namespace Stars.Dal.DomainModels.Interfaces
{
	/// <summary>
	/// Доменная модель
	/// </summary>
	public interface IDomainModel
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		int Id { get; set; }
	}
}
