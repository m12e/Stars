using Stars.Dal.DomainModels.Interfaces;

namespace Stars.Dal.DomainModels
{
	/// <summary>
	/// Базовый класс для доменной модели
	/// </summary>
	public abstract class BaseDomainModel : IDomainEntity
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		public int Id { get; set; }
	}
}
