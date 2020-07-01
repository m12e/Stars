using Stars.Dal.DomainModels.Interfaces;

namespace Stars.Dal.DomainModels
{
	/// <summary>
	/// Базовый класс для доменной модели
	/// </summary>
	public abstract class BaseDomainModel : IDomainModel
	{
		public int Id { get; set; }
	}
}
